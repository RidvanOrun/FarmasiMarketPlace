

using FarmasiMarketPlace.Entities.Base;

namespace FarmasiMarketPlace.Entities.Model
{
    [BsonCollection("categories")]
    public class Category : Document
    {
        public string Name { get; set; }
    }

}
