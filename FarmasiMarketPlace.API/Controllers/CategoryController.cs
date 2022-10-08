using FarmasiMarketPlace.Business.Interfcae;
using FarmasiMarketPlace.Business.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmasiMarketPlace.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : BaseController<CategoryController>
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService , IDistributedCache distributedCache)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var response = _categoryService.GetCategories();

            if (!response.Successed)
            {
                return APIResponse(response);
            }

            return Ok(response);
        }

        [HttpPost, Route("")]
        public IActionResult CreateCategory([FromBody] CategoryModel model)
        {
            var response = _categoryService.CreateCategory(model);

            if (!response.Successed)
            {
                return APIResponse(response);
            }

            return Ok(response);
        }

        [HttpPost, Route("delete/{id}")]
        public IActionResult RemoveCategory([FromRoute] string id)
        {
            var response = _categoryService.RemoveCategory(id);

            if (!response.Successed)
            {
                return APIResponse(response);
            }

            return Ok(response);
        }

    }
}
