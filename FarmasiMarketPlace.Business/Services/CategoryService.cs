using AutoMapper;
using FarmasiMarketPlace.Business.Base;
using FarmasiMarketPlace.Business.Interfcae;
using FarmasiMarketPlace.Business.Model;
using FarmasiMarketPlace.Core.Responses;
using FarmasiMarketPlace.Core.Utilities;
using FarmasiMarketPlace.DAL.Interface;
using FarmasiMarketPlace.Entities.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmasiMarketPlace.Business.Services
{
    public class CategoryService : BaseService<CategoryService>, ICategoryService
    {
        private readonly IMongoRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IMongoRepository<Category> categoryRepository,IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public ServiceResponse<CategoryModel> CreateCategory(CategoryModel model)
        {
            var res = new ServiceResponse<CategoryModel> { };

            var category = _mapper.Map<Category>(model);
            category.Id = null;

            var resCategory = _categoryRepository.InsertOne(category);

            if (!resCategory.Successed)
            {
                res.Successed = false;
                res.Code = StatusCodes.Status500InternalServerError;
                res.Message = "Beklenmeyen bir hata oluştu, lütfen daha sonra yeniden deneyiniz.";
                res.Errors = resCategory.Message;

                return res;
            }

            res.Result = _mapper.Map<CategoryModel>(resCategory.Result);

            return res;
        }

        public ServiceResponse<List<CategoryModel>> GetCategories()
        {
            var res = new ServiceResponse<List<CategoryModel>> { };

            var resCategories = _categoryRepository.FilterBy(x => x.Status == EntityStatus.Active);

            res.Result = _mapper.Map<List<CategoryModel>>(resCategories.Result);

            return res;
        }

        public ServiceResponse<CategoryModel> RemoveCategory(string id)
        {
            var res = new ServiceResponse<CategoryModel> { };

            var categories = _categoryRepository.FindOne(x => x.Id == id);

            categories.Result.Status = EntityStatus.Passive;

            var resCategories = _categoryRepository.ReplaceOne(categories.Result);

            res.Result = _mapper.Map<CategoryModel>(resCategories.Result);

            return res;
        }

        public ServiceResponse<CategoryModel> UpdateCategories(CategoryModel model)
        {
            var res = new ServiceResponse<CategoryModel> { };

            var categories = _categoryRepository.FindOne(x => x.Id == model.Id).Result;

            categories.Name = model.Name != categories.Name ? model.Name : categories.Name;
            categories.UpdatedAt = DateTime.Now;

            var resCategories = _categoryRepository.ReplaceOne(categories);

            res.Result = _mapper.Map<CategoryModel>(resCategories.Result);

            return res;
        }
    }
}
