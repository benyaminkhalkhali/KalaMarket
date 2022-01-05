using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class AddOrUpdateProductPriceVM
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
        public DateTime CreateDate { get; set; }
        public string EndDateDiscount { get; set; }

        public int ColorId { get; set; }
        public int ProductGuaranteeId { get; set; }
        public int ProductId { get; set; }
    }
}
