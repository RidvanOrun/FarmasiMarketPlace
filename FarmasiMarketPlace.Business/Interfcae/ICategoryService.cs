using FarmasiMarketPlace.Business.Model;
using FarmasiMarketPlace.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmasiMarketPlace.Business.Interfcae
{
    public interface ICategoryService
    {
        ServiceResponse<CategoryModel> CreateCategory(CategoryModel model);

        ServiceResponse<CategoryModel> RemoveCategory(string id);

        ServiceResponse<CategoryModel> UpdateCategories(CategoryModel model);

        ServiceResponse<List<CategoryModel>> GetCategories();        
    }
}
