using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.ProductEntities
{
    public  class ProductColor
    {
        [Key]
        public int ColorId { get; set; }

        [Display(Name = "نام رنگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MinLength(3, ErrorMessage = "{0} نمی تواند کمتر از {1} باشد")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند کمتر از {1} باشد")]
        public string ColorName { get; set; }

        [Display(Name = "کد رنگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(20, ErrorMessage = "{0} نمی تواند کمتر از {1} باشد")]
        public string ColorCode { get; set; }

        public bool IsDelete { get; set; }

        #region Relations
        public List<ProductPrice> productPrices { get; set; }
        #endregion
    }
}
