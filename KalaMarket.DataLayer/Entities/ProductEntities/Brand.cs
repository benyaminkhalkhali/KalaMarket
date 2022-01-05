using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.ProductEntities
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        [Display(Name = "عنوان برند")]
        [Required(ErrorMessage = "لطفا عنوان برند را وارد نمایید")]
        [MinLength(5, ErrorMessage = "عنوان برند نمی تواند کمتر از 5 کاراکتر باشد")]
        [MaxLength(50, ErrorMessage = "عنوان برند نمی تواند بیشتر از 50 کاراکتر باشد")]
        public string BrandName { get; set; }

        public bool IsDelete { get; set; }

        #region Relations
        public List<Product> products { get; set; }
        #endregion
    }
}
