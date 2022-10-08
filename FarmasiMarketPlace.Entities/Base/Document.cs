using System;
using System.Collections.Generic;
using System.Text;
using FarmasiMarketPlace.Core.Utilities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FarmasiMarketPlace.Entities.Base
{
    [BsonIgnoreExtraElements]
    public class Document :IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public EntityStatus Status { get; set; } = EntityStatus.Active;
    }
}
