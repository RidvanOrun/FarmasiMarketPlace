using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FarmasiMarketPlace.DAL.RedisConnection
{
    public class RedisConnectionHelper
    {
        static RedisConnectionHelper()
        {
            RedisConnectionHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
                return ConnectionMultiplexer.Connect("127.0.0.1:6379");
            });
        }
        private static Lazy<ConnectionMultiplexer> lazyConnection;
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
