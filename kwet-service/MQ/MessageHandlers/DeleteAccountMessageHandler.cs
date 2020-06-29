using System.Threading.Tasks;
using kwet_service.MQ.Messages;
using kwet_service.Repositories;
using MessageBroker;
using System;
using System.Text.Json;

namespace kwet_service.MQ.MessageHandlers
{
    public class DeleteAccountMessageHandler : IMessageHandler<DeleteAccountMessage>
    {
        private readonly IKweetRepository _repository;

        public DeleteAccountMessageHandler(IKweetRepository repository)
        {
            _repository = repository;
        }

        public Task HandleMessageAsync(string messageType, DeleteAccountMessage message)
        {
            _repository.RemoveKweetsFromUser(message.Id);

            return Task.CompletedTask;
        }

        public Task HandleMessageAsync(string messageType, byte[] obj)
        {
            return HandleMessageAsync(messageType,
                JsonSerializer.Deserialize<DeleteAccountMessage>((ReadOnlySpan<byte>) obj,
                    (JsonSerializerOptions) null));
        }
    }
}