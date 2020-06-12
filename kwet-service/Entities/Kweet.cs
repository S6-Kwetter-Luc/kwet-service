using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace kwet_service.Entities
{
    public class Kweet
    {
        [BsonId] public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public User Writer { get; set; }
        public string Content { get; set; }
        public List<User> Likes { get; set; }
    }
}