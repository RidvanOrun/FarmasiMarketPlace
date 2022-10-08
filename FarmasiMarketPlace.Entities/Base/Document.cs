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

        private DateTime _createDate = DateTime.Now;
        public DateTime CreatedAt { get => _createDate; set => _createDate = value; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public EntityStatus Status { get; set; } = EntityStatus.Active;

    }
}
