using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class ShowPriceForProductVM
    {
        public int ProductPriceId { get; set; }

        [Display(Name = "قیمت اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int MainPrice { get; set; }

        [Display(Name = "قیمت ویژه")]
        public int? SpecialPrice { get; set; }

        [Display(Name = "تعداد کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int Count { get; set; }

        [Display(Name = "حداکثر خرید کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int MaxOrderCount { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "تاریخ پایان تخفیف")]
        public DateTime? EndDateDiscount { get; set; }


        public string ColorName { get; set; }
        public string GuaranteeName { get; set; }
        public int ProductId { get; set; }
    }
}
