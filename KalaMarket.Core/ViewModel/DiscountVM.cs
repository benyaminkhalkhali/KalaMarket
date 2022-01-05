using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class DiscountVM
    {
        public int DiscountId { get; set; }

        [Display(Name = "کدتخفیف")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string DiscountCode { get; set; }

        [Display(Name = "درصد کدتخفیف")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int DiscountPercent { get; set; }


        [Display(Name = "حداکثر استفاده")]
        public int? UsableCount { get; set; }


        [Display(Name = "شروع کدتخفیف")]
        public string StartDate { get; set; }


        [Display(Name = "پایان کدتخفیف")]
        public string EndDate { get; set; }


        public int UserDiscountId { get; set; }
    }
}
