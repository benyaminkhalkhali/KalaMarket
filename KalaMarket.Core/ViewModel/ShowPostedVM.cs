using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class ShowPostedVM
    {
        public int CartId { get; set; }
        public string Email { get; set; }
        public DateTime DateTime { get; set; }
        public int TotalPrice { get; set; }
    }

    public class DetailPostedVM
    {
        public string RecipientName { get; set; }
        public int ProductId { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string GuaranteeName { get; set; }
        public string ColorName { get; set; }
        public string Address { get; set; }
        public string RefId { get; set; }
        public bool IsPaid { get; set; }
    }
}
