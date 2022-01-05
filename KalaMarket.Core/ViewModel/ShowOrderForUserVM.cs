using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class ShowOrderForUserVM
    {
        public int CartId { get; set; }
        public string CreateDate { get; set; }
        public bool IsPay { get; set; }
        public int TotalPrice { get; set; }
    }
}
