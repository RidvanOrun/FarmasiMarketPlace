using FarmasiMarketPlace.Business.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmasiMarketPlace.Business.Model
{
    public class UserModel: BaseModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string IdentityNumber { get; set; } //TC 

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
