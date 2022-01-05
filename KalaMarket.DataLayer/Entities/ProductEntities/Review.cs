using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.ProductEntities
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Display(Name = "توضیحات محصول")]
        [MaxLength(10000, ErrorMessage = "{0} نمی تواند بیشتر از {1} باشد")]
        public string ReviewDescription { get; set; }

        [Display(Name = "نقاط ضعف")]
        [MaxLength(1000, ErrorMessage = "{0} نمی تواند بیشتر از {1} باشد")]
        public string ReviewNegative { get; set; }

        [Display(Name = "نقاط قوت")]
        [MaxLength(1000, ErrorMessage = "{0} نمی تواند بیشتر از {1} باشد")]
        public string ReviewPositive { get; set; }

        [Display(Name = "عنوان مقاله")]
        [MaxLength(1000, ErrorMessage = "{0} نمی تواند بیشتر از {1} باشد")]
        public string ArticleTitle { get; set; }

        [Display(Name = "توضیحات مقاله")]
        public string ArticleDescription { get; set; }


        public int ProductId { get; set; }
        #region Relations
        [ForeignKey("ProductId")]
        public Product product { get; set; }
        #endregion

    }
}
