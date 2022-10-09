using FarmasiMarketPlace.Core.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmasiMarketPlace.Business.Base
{
    public class BaseModel
    {

        [JsonProperty]
        public string Id { get; set; }

        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //public DateTime? UpdatedAt { get; set; }

        //public DateTime? DeletedAt { get; set; }

        //public EntityStatus Status { get; set; } = EntityStatus.Active;

    }
}
