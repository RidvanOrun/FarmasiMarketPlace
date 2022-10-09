using FarmasiMarketPlace.Business.Interfcae;
using FarmasiMarketPlace.Business.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmasiMarketPlace.API.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductController : BaseController<ProductController>
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet, Route("")]
        public IActionResult GetProducts()
        {

            var response = _productService.GetProducts();

            if (!response.Successed)
            {
                return APIResponse(response);
            }

            return Ok(response);
        }

        [HttpPost, Route("")]
        public IActionResult CreateProducts([FromBody] ProductModel model)
        {

            var response = _productService.CreateProduct(model);

            if (!response.Successed)
            {
                return APIResponse(response);
            }

            return Ok(response);
        }
    }
}
