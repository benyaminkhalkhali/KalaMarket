using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class CompareVM
    {
        public int ProductId { get; set; }
        public string ProductFaTitle { get; set; }
        public int ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public int CategoryId { get; set; }

        public List<PropertyProductCompareVM> CompareVm { get; set; }
    }

    public class PropertyProductCompareVM
    {
        public int PropertyNameId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public int ProductId { get; set; }
    }

    public class GetProductForCompare
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductFaTitle { get; set; }
    }
}
