using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class CartVM
    {
        public int ProductId { get; set; }
        public int ProductPriceId { get; set; }
        public string ProductFaTitle { get; set; }
        public string ColorName { get; set; }
        public string GuaranteeName { get; set; }
        public int OrderCount { get; set; }
        public int ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public int TotalPrice { get; set; }
        public int MaxOrderCount { get; set; }
        public int ProductCount { get; set; }
        public int CartId { get; set; }
        public string ColorCode { get; set; }
    }
}
