using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class ShowFavouriteVM
    {
        public int ProductId { get; set; }
        public string ProductFaTitle { get; set; }
        public int? ProductPrice { get; set; }
        public byte ProductStar { get; set; }
        public string ProductImage { get; set; }
    }
}
