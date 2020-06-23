using System;
using System.Text.Json;
using System.Threading.Tasks;
using kwet_service.MQ.Messages;
using kwet_service.Repositories;
using MessageBroker;

namespace kwet_service.MQ.MessageHandlers
{
    public class UpdateAccountMessageHandler : IMessageHandler<UpdateUserMessage>
    {
        private readonly IKweetRepository _repository;

        public UpdateAccountMessageHandler(IKweetRepository repository)
        {
            _repository = repository;
        }

        public Task HandleMessageAsync(string messageType, UpdateUserMessage message)
        {
            Console.WriteLine(message.NewUsername);
            _repository.UpdateKweetsByUser(message.Id, message.NewUsername);

            return Task.CompletedTask;
        }

        public Task HandleMessageAsync(string messageType, byte[] obj)
        {
            return HandleMessageAsync(messageType,
                JsonSerializer.Deserialize<UpdateUserMessage>((ReadOnlySpan<byte>) obj,
                    (JsonSerializerOptions) null));
        }
    }
}