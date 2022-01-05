using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class ShowDetailOrderForUserVM
    {
        public int ProductId { get; set; }
        public int ProductPrice { get; set; }
        public int TotalPrice { get; set; }
        public int Count { get; set; }
        public string ProductFaTitle { get; set; }
        public string RefId { get; set; }
        public bool IsPaid { get; set; }
    }
}
