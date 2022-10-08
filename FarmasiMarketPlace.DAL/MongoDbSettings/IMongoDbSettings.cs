using System;
using System.Collections.Generic;
using System.Text;

namespace FarmasiMarketPlace.DAL.MongoDbSettings
{
    public interface IMongoDbSettings
    {
        //string Host { get; set; }
        //int Port { get; set; }

        //string UserName { get; set; }
        //string Password { get; set; }

        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
