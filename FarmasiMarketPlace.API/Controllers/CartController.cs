using FarmasiMarketPlace.Business.Interfcae;
using FarmasiMarketPlace.Business.Model;
using FarmasiMarketPlace.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmasiMarketPlace.API.Controllers
{
    [Route("api/v1/carts")]
    [ApiController]
    public class CartController : BaseController<CartController>
    {
        private readonly IShoppingCartService _shoppingCartService;

        public CartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpPost, Route("")]
        public IActionResult AddCart([FromBody] ShoppingCartModel model)
        {
            var response = _shoppingCartService.AddCart(model);

            if (!response.Successed)
            {
                return APIResponse(response);
            }

            return Ok(response);
        }


        [HttpGet, Route("")]
        public IActionResult Cart()
        {
            var response = _shoppingCartService.GetCart();

            if (!response.Successed)
            {
                return APIResponse(response);
            }

            return Ok(response);
        }

        [HttpDelete, Route("")]
        public IActionResult RemoveCart()
        {
            var response = _shoppingCartService.RemoveCart();

            if (!response.Successed)
            {
                return APIResponse(response);
            }

            return Ok(response);
        }


    }
}
