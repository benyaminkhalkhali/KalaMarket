using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.ProductEntities.FAQ
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Display(Name = "عنوان نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MinLength(4, ErrorMessage = "{0} نمی تواند کمتر از {1} باشد")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند کمتر از {1} باشد")]
        public string CommentTitle { get; set; }

        [Display(Name = "توضیحات نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MinLength(10, ErrorMessage = "{0} نمی تواند کمتر از {1} باشد")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند کمتر از {1} باشد")]
        public string CommentDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int Score { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }

        #region Relation
        [ForeignKey("ProductId")]
        public Product product { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }
        #endregion

    }
}
