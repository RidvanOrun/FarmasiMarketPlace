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
    public class ShoppingCartService : BaseService<ShoppingCartService>/*, IShoppingCartService*/
    {
        private readonly IMongoRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IMongoRepository<User> _userCartRepository;
        private readonly IMongoRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ShoppingCartService(IMongoRepository<ShoppingCart> shoppingCartRepository, IMapper mapper, IMongoRepository<User> userCartRepository, IMongoRepository<Product> productRepository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _mapper = mapper;
            _userCartRepository = userCartRepository;
            _productRepository = productRepository;
        }


        //public ServiceResponse<ShoppingCart> AddCart(ShoppingCartModel model)
        //{
        //    var res = new ServiceResponse<ShoppingCart> { };

        //    var user = _userCartRepository.FindOne(x => x.Id == model.UserId).Result;

        //    Expression<Func<Product, bool>> filterPredicate = PredicateBuilder.New<Product>(true);

        //    filterPredicate = filterPredicate.And(x => x.Id == model.ProductId);

        //    var lookedUp = _productRepository.Aggregate()
        //        .Match(filterPredicate)
        //        .Lookup<Product, ProductLookedUp>("categories", "CategoryIds", "Id", "Categories")
        //        .FirstOrDefault();

        //    var cart = new ShoppingCart();
        //    cart.User = user;
        //    cart.Product = lookedUp;
        //    cart.Count = model.Count;

        //    var resCart = _shoppingCartRepository.InsertOne(cart);

        //    res.Result = _mapper.Map<ShoppingCart>(resCart.Result);

        //    return res;
        //}

        //public ServiceResponse<ShoppingCart> RemoveItemFromCart(ShoppingCartModel model)
        //{
        //    var res = new ServiceResponse<ShoppingCart> { };

        //    return res;
        //}
    }
}
