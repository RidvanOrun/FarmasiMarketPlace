using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmasiMarketPlace.Core.Responses
{
    public class ServiceResponse
    {
        public bool Successed { get; set; } = true;

        public short Code { get; set; } = StatusCodes.Status200OK;

        public string Message { get; set; }

        public dynamic Errors { get; set; }

        public bool? SpecialBoolean { get; set; }
    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public T Result { get; set; }

        public int TotalItems { get; set; } = 0;

        public int TotalUnSeenItems { get; set; } = 0;

    }
}
