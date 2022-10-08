using FarmasiMarketPlace.Entities.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FarmasiMarketPlace.Entities.Model
{
    [BsonCollection("product")]
    public class Product : Document
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }

    public class ProductLookedUp : Product
    {
        public Category Category { get; set; }

    }
}
