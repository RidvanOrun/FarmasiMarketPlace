using FarmasiMarketPlace.Core.Utilities;
using FarmasiMarketPlace.Entities.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmasiMarketPlace.Entities.Model
{
    [BsonCollection("shoppnigCarts")]
    public class ShoppingCart : Document
    {
        public User User { get; set; }

        public ProductLookedUp Product { get; set; }

        public int Count { get; set; } = 1;

        public CartStatus CartStatus { get; set; } = CartStatus.Active;
    }
}
