using FarmasiMarketPlace.Business.Interfcae;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmasiMarketPlace.API.Controllers
{
    public class CategoryController :BaseController<CategoryController>
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService productService)
        {
            _categoryService = productService;
        }

        [HttpGet, Route("")]
        public IActionResult GetCategories()
        {

            var response = _categoryService.

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
