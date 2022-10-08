using AutoMapper;
using FarmasiMarketPlace.Business.Model;
using FarmasiMarketPlace.Entities.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmasiMarketPlace.Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateUserMappings();
            CreateProductMappings();
            CreateCategoryMappings();

            CreateMap<string, ObjectId?>().ConvertUsing(s => StringToObjectTypeConverter(s));
        }

        public ObjectId? StringToObjectTypeConverter(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return null;
            }
            return ObjectId.Parse(source);
        }

        public void CreateUserMappings()
        {
            CreateMap<UserModel, User>().ReverseMap();
        }

        public void CreateProductMappings()
        {
            CreateMap<ProductModel, User>().ReverseMap();
        }

        public void CreateCategoryMappings()
        {
            CreateMap<CategoryModel, User>().ReverseMap();
        }

    }
}
