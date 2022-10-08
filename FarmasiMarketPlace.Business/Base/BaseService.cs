using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace FarmasiMarketPlace.Business.Base
{
    public abstract class BaseService<T>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IMapper _mapper;

        protected BaseService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected HttpContext HttpContext => _httpContextAccessor.HttpContext;

        //  protected IMapper Mapper => _mapper ?? (_mapper = HttpContext.RequestServices.GetService<IMapper>());

    }


}
