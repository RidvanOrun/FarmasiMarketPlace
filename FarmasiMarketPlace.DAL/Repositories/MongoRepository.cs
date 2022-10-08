using FarmasiMarketPlace.Core.Responses;
using FarmasiMarketPlace.DAL.Interface;
using FarmasiMarketPlace.DAL.MongoDbSettings;
using FarmasiMarketPlace.Entities.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmasiMarketPlace.DAL.Repositories
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }


        public RepositoryResponse<TDocument> InsertOne(TDocument document)
        {
            var response = new RepositoryResponse<TDocument> { };

            try
            {
                _collection.InsertOne(document);
                response.Result = document;
            }
            catch (Exception ex)
            {
                response.Successed = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
