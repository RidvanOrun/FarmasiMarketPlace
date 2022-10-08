using FarmasiMarketPlace.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmasiMarketPlace.Entities.Model
{
    [BsonCollection("users")]
    public class User : Document
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string IdentityNumber { get; set; } //TC 

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
