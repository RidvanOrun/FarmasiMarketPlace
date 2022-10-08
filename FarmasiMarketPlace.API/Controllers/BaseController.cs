using FarmasiMarketPlace.Core.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmasiMarketPlace.API.Controllers
{
    public abstract class BaseController<T> : ControllerBase
    {
        protected IActionResult APIResponse(ServiceResponse response)
        {
            switch (response.Code)
            {
                case StatusCodes.Status200OK:
                    return Ok(response);
                case StatusCodes.Status400BadRequest:
                    return BadRequest(new { Message = response.Message });
                case StatusCodes.Status401Unauthorized:
                    return Unauthorized(new { Message = response.Message });
                case StatusCodes.Status403Forbidden:
                    return StatusCode(StatusCodes.Status403Forbidden, new { Message = response.Message });
                case StatusCodes.Status404NotFound:
                    return NotFound(new { Message = response.Message });
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Errors = response.Errors, Message = response.Message });
            }
        }

    }
}
