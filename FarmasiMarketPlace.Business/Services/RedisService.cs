using FarmasiMarketPlace.Business.Interfcae;
using FarmasiMarketPlace.DAL.RedisConnection;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmasiMarketPlace.Business.Services
{
    public class RedisService : IRedisService
    {
        private IDatabase _db;
        public RedisService()
        {
            ConfigureRedis();
        }

        private void ConfigureRedis()
        {
            _db = RedisConnectionHelper.Connection.GetDatabase();
        }

        public T GetData<T>(string key)
        {
            var value = _db.StringGet(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }
        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            var isSet = _db.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
        }
        public object RemoveData(string key)
        {
            bool _isKeyExist = _db.KeyExists(key);
            if (_isKeyExist == true)
            {
                return _db.KeyDelete(key);
            }
            return false;
        }
    }
}
