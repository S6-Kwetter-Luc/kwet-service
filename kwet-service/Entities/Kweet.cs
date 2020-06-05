using System;
using MongoDB.Bson.Serialization.Attributes;

namespace kwet_service.Entities
{
    public class Kweet
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}