using FarmasiMarketPlace.Core.Responses;
using FarmasiMarketPlace.Entities.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmasiMarketPlace.DAL.Interface
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        RepositoryResponse<TDocument> InsertOne(TDocument document);

        IAggregateFluent<TDocument> Aggregate(AggregateOptions options = null);

    }
}
