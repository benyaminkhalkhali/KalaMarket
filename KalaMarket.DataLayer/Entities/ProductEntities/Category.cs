using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.ProductEntities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "عنوان دسته بندی به فارسی")]
        [Required(ErrorMessage = "وارد کردن نام دسته اجباری است")]
        [MinLength(3, ErrorMessage = "نام دسته نمی تواند کمتر از 3 کاراکتر باشد ")]
        [MaxLength(100, ErrorMessage = "نام دسته نمی تواند بیشتر از 100 کاراکتر باشد")]
        public string CategoryFaTitle { get; set; }

        [Display(Name = "عنوان دسته بندی به انگلیسی")]
        [Required(ErrorMessage = "وارد کردن نام دسته اجباری است")]
        [MinLength(3, ErrorMessage = "نام دسته نمی تواند کمتر از 3 کاراکتر باشد ")]
        [MaxLength(100, ErrorMessage = "نام دسته نمی تواند بیشتر از 100 کاراکتر باشد")]
        public string CategoryEnTitle { get; set; }
        public bool IsDelete { get; set; }
        public int? SubCategory { get; set; }


        #region Relations
        public List<Product> products { get; set; }
        public List<PropertyName_Category> propertyNames { get; set; }

        [ForeignKey("SubCategory")]
        public Category categoryy { get; set; }
        #endregion


    }
}
