using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace FarmasiMarketPlace.Business.Base
{
    public abstract class BaseService<T>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected HttpContext HttpContext => _httpContextAccessor.HttpContext;


    }


}
