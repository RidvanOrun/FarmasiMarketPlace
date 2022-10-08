using FarmasiMarketPlace.Business.Model;
using FarmasiMarketPlace.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmasiMarketPlace.Business.Interfcae
{
    public interface ICategoryService
    {
        ServiceResponse<CategoryModel> CreateCategory(CategoryModel product);

        ServiceResponse<CategoryModel> RemoveCategories(CategoryModel product);

        ServiceResponse<CategoryModel> UpdateCategories(CategoryModel product);

        ServiceResponse<List<CategoryModel>> GetCategories(CategoryModel product);        
    }
}
