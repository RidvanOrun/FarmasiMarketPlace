using FarmasiMarketPlace.Business.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmasiMarketPlace.Business.Model
{
    public class ProductModel : BaseModel
    {
        public string CategoryId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        #region [ LookedUp Fields ]

        public CategoryModel Category { get; set; }

        #endregion
    }
}
