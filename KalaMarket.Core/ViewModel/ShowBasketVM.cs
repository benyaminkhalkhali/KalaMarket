using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class ShowBasketVM
    {
        public int ProductId { get; set; }
        public string ProductFaTitle { get; set; }
        public int? MainPrice { get; set; }
        public string ProductImage { get; set; }
        public int TotalBasket { get; set; }
    }
}
