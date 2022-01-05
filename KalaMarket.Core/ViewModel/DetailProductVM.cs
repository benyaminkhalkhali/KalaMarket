using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class DetailProductVM
    {
        public int ProductId { get; set; }
        public string ProductFaTitle { get; set; }
        public string ProductEnTitle { get; set; }
        public int ProductSell { get; set; }
        public string CategoryName { get; set; }
        public string ProductTag { get; set; }
        public string ProductBrand { get; set; }
        public string ProductImage { get; set; }
        public byte ProductStar { get; set; }
    }

    public class ProductPriceVM
    {
        public int ProductPriceId { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public string GuaranteeName { get; set; }
        public int MainPrice { get; set; }
        public int? SpecialPrice { get; set; }
        public int Count { get; set; }
        public int MaxOrderCount { get; set; }
        public DateTime? EndDiscount { get; set; }
    }
}
