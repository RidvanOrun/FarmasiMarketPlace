using FarmasiMarketPlace.Business.Model;
using FarmasiMarketPlace.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmasiMarketPlace.Business.Interfcae
{
    public interface IProductService
    {
        ServiceResponse<ProductModel> CreateProduct(ProductModel model);

        ServiceResponse<List<ProductModel>> GetProducts();
    }
}
