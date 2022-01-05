using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class ShowDetailsProductVM
    {
        public int ProductId { get; set; }
        public string ProductFaTitle { get; set; }
        public string ProductEnTitle { get; set; }
        public int ProductSell { get; set; }
        public int ProductStar { get; set; }
        public string ProductTag { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public string GuaranteeName { get; set; }
        public int MainPrice { get; set; }
        public int? SpecialPrice { get; set; }
        public DateTime? EndDateDiscount { get; set; }
        public string ProductImage { get; set; }
        public int ProductPriceId { get; set; }
        public string CategoryName { get; set; }
    }
}
