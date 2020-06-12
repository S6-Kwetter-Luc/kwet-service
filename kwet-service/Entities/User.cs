using System;
using MongoDB.Bson.Serialization.Attributes;

namespace kwet_service.Entities
{
    public class User
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}