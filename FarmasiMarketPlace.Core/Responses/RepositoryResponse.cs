using System;
using System.Collections.Generic;
using System.Text;

namespace FarmasiMarketPlace.Core.Responses
{
    public class RepositoryResponse
    {
        public bool Successed { get; set; } = true;
        public string Message { get; set; }

    }

    public class RepositoryResponse<T> : RepositoryResponse
    {
        public T Result { get; set; }

        public int TotalDocuments { get; set; } = 0;
    }
}
