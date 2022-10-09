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
        private readonly IMongoRepository<User> _userCartRepository;
        private readonly IMongoRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        private readonly IRedisService _redisService;

        public ShoppingCartService(IRedisService redisService, IMongoRepository<ShoppingCart> shoppingCartRepository, IMapper mapper, IMongoRepository<User> userCartRepository, IMongoRepository<Product> productRepository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _mapper = mapper;
            _userCartRepository = userCartRepository;
            _productRepository = productRepository;
            _redisService = redisService;
        }

        public ServiceResponse<ShoppingCart> AddCart(ShoppingCartModel model)
        {
            var res = new ServiceResponse<ShoppingCart> { };

            //var user = _userCartRepository.FindOne(x => x.Id == model.UserId).Result;

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
            //cart.User = user;
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


            return res;
        }

        public ServiceResponse<ShoppingCart> RemoveCart(ShoppingCartModel model)
        {
            throw new NotImplementedException();
        }

        //public ServiceResponse<ShoppingCart> RemoveItemFromCart(ShoppingCartModel model)
        //{
        //    var res = new ServiceResponse<ShoppingCart> { };

        //    return res;
        //}
    }
}
