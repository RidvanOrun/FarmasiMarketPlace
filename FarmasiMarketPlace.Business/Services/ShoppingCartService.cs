using AutoMapper;
using FarmasiMarketPlace.Business.Interfcae;
using FarmasiMarketPlace.Business.Model;
using FarmasiMarketPlace.Core.Responses;
using FarmasiMarketPlace.DAL.Interface;
using FarmasiMarketPlace.Entities.Model;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text;
using FarmasiMarketPlace.Business.Base;
using LinqKit;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace FarmasiMarketPlace.Business.Services
{
    public class ShoppingCartService : BaseService<ShoppingCartService>, IShoppingCartService
    {
        private readonly IMongoRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IMongoRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        private readonly IRedisService _redisService;

        public ShoppingCartService(IRedisService redisService, IMongoRepository<ShoppingCart> shoppingCartRepository, IMapper mapper, IMongoRepository<Product> productRepository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _mapper = mapper;
            _productRepository = productRepository;
            _redisService = redisService;
        }

        public ServiceResponse<ShoppingCart> AddCart(ShoppingCartModel model)
        {
            var res = new ServiceResponse<ShoppingCart> { };

            Expression<Func<Product, bool>> filterPredicate = PredicateBuilder.New<Product>(true);

            filterPredicate = filterPredicate.And(x => x.Id == model.ProductId);

            AggregateUnwindOptions<ProductLookedUp> unwindOptions = new AggregateUnwindOptions<ProductLookedUp>() { PreserveNullAndEmptyArrays = true };

            var lookedUp = _productRepository.Aggregate()
                .Match(filterPredicate)
                .Lookup<Product, ProductLookedUp>("categories", "CategoryId", "Id", "Category")
                .Unwind(x => x.Category, unwindOptions)
                .As<ProductLookedUp>()
                .FirstOrDefault();

            var cart = new ShoppingCart();
            cart.Product = lookedUp;
            cart.Count = model.Count;

            var cartItem = _redisService.SetData<ShoppingCart>("shoppingCart", cart, DateTimeOffset.Now.AddMinutes(5.0));

            if (cartItem == true)
            {
                res.Successed = true;
                res.Result = cart;
            }

            res.Successed = false;

            return res;
        }

        public ServiceResponse<ShoppingCart> GetCart()
        {
            var res = new ServiceResponse<ShoppingCart> { };

            var cartItem = _redisService.GetData<ShoppingCart>("shoppingCart");

            if (cartItem != null)
            {
                res.Successed = false;
            }

            res.Result = cartItem;

            return res;
        }

        public ServiceResponse<object> RemoveCart()
        {
            var res = new ServiceResponse<object> { };

            var cartItem = _redisService.RemoveData("shoppingCart");

            res.Result = cartItem;

            return res;
        }
    }
}
