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

        //[HttpGet, Route("")]
        //public IActionResult GetCart()
        //{
        //    var redisData = _redisService.GetData<ShoppingCart>("shppingCarts");

        //    if (redisData != null)
        //    {
        //        return Ok(redisData);
        //    }

        //    var response = _productService.GetProducts();

        //    if (!response.Successed)
        //    {
        //        return APIResponse(response);
        //    }

        //    return Ok(response);
        //}

        [HttpPost, Route("")]
        public IActionResult AddCart([FromBody] ShoppingCartModel model)
        {

            var response = _shoppingCartService.AddCart(model);
                

            //var redisData = _redisService.GetData<ShoppingCart>("shppingCarts");

            //if (redisData != null)
            //{
            //    return Ok(redisData);
            //}

            //var response = _productService.GetProducts();

            //if (!response.Successed)
            //{
            //    return APIResponse(response);
            //}

            return Ok(response);
        }


        [HttpGet, Route("")]
        public IActionResult Cart()
        {

            var response = _shoppingCartService.


            //var redisData = _redisService.GetData<ShoppingCart>("shppingCarts");

            //if (redisData != null)
            //{
            //    return Ok(redisData);
            //}

            //var response = _productService.GetProducts();

            //if (!response.Successed)
            //{
            //    return APIResponse(response);
            //}

            return Ok(response);
        }


    }
}
