

using FarmasiMarketPlace.Entities.Base;

namespace FarmasiMarketPlace.Entities.Model
{
    [BsonCollection("testcategories")]
    public class Category : Document
    {
        public string Name { get; set; }
    }

}
