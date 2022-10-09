using System;
using System.Collections.Generic;
using System.Text;

namespace FarmasiMarketPlace.Business.Interfcae
{
    public interface IRedisService
    {
        T GetData<T>(string key);

        bool SetData<T>(string key, T value, DateTimeOffset expirationTime);

        object RemoveData(string key);
    }
}
