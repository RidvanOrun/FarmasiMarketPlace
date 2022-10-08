using AutoMapper;
using FarmasiMarketPlace.Business.Base;
using FarmasiMarketPlace.Business.Interfcae;
using FarmasiMarketPlace.Business.Model;
using FarmasiMarketPlace.Core.Responses;
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
        private readonly IMongoRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public CategoryService(IMongoRepository<Product> productRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public ServiceResponse<CategoryModel> CreateCategory(CategoryModel product)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<List<CategoryModel>> GetCategories(CategoryModel product)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<CategoryModel> RemoveCategories(CategoryModel product)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<CategoryModel> UpdateCategories(CategoryModel product)
        {
            throw new NotImplementedException();
        }
    }
}
