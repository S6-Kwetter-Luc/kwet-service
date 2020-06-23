using System;

namespace kwet_service.MQ.Messages
{
    public class UpdateUserMessage
    {
        public Guid Id { get; set; }
        public string NewUsername { get; set; }
    }
}