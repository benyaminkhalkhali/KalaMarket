using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class SpecialProductVM
    {
        public int ProductId { get; set; }
        public string ProductFaTitle { get; set; }
        public string ProductImage { get; set; }
        public int MainPrice { get; set; }
        public int? SpecialPrice { get; set; }
        public List<ValueVM> ValuesList { get; set; }
        public DateTime? EndSpecialPrice { get; set; }
        public int ProductPriceId { get; set; }
    }
    public class ValueVM
    {
        public string PropName { get; set; }
        public string Value { get; set; }
    }
}
