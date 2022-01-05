using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    #region Products

    public class ProductInfosVM
    {
        public int ProductId { get; set; }
        public string ProductFaTitle { get; set; }
        public string CategoryName { get; set; }
        public string ProductBrand { get; set; }
        public string ProductTag { get; set; }
        public string ProductImage { get; set; }
        public int MainPrice { get; set; }
        public int? SpecialPrice { get; set; }
        public byte ProductStar { get; set; }
        public int ProductSell { get; set; }
        public DateTime CreateDate { get; set; }

    }

    public class ProductInfosForShowInWebVM
    {
        public List<ProductInfosVM> products { get; set; }
        public int Currentpage { get; set; }
        public int PageCount { get; set; }
        public int Count { get; set; }
    }

    #endregion
}
