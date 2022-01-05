using KalaMarket.DataLayer.Entities.ProductEntities.FAQ;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.ProductEntities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "عنوان فارسی")]
        [Required(ErrorMessage = "لطفا عنوان خود را به فارسی وارد نمایید")]
        [MinLength(3, ErrorMessage = "عنوان نمی تواند کمتر از 3 کاراکتر باشد")]
        [MaxLength(500, ErrorMessage = "عنوان نمی تواند بیشتر از 500 کاراکتر باشد")]
        public string ProductFaTitle { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [Required(ErrorMessage = "لطفا عنوان خود را به انگلیسی وارد نمایید")]
        [MinLength(3, ErrorMessage = "عنوان نمی تواند کمتر از 3 کاراکتر باشد")]
        [MaxLength(500, ErrorMessage = "عنوان نمی تواند بیشتر از 500 کاراکتر باشد")]
        public string ProductEnTitle { get; set; }

        [Display(Name = "تعداد فروش")]
        public int ProductSell { get; set; }

        [Display(Name = "امتیاز محصول")]
        public byte ProductStar { get; set; }

        [Display(Name = "تصویر محصول")]
        public string ProductImage { get; set; }

        [Display(Name = "برچسب های محصول")]
        public string ProductTag { get; set; }
        public DateTime ProductCreate { get; set; }
        public DateTime ProductUpdate { get; set; }

        [Display(Name = "وزن محصول")]
        public int ProductWeight { get; set; }

        [Display(Name = "فعال شود؟!")]
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool IsOriginal { get; set; }



        [NotMapped]
        public int MainPrice { get; set; }

        [NotMapped]
        public int? SpecialPrice { get; set; }

        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        #region Relations
        [ForeignKey("CategoryId")]
        public Category category { get; set; }

        [ForeignKey("BrandId")]
        public Brand brand { get; set; }

        public List<Review> reviews { get; set; }
        public List<Question> questions { get; set; }
        public List<Comment> comments { get; set; }
        public List<ProductGallery> productGalleries { get; set; }
        public List<ProductPrice> productPrices { get; set; }
        public List<Favourite> favourites { get; set; }
        #endregion
    }
}
