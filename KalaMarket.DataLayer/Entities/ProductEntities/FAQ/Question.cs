using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.ProductEntities.FAQ
{
    public  class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Display(Name = "متن سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MinLength(5, ErrorMessage = "{0} نمی تواند کمتر از {1} باشد")]
        [MaxLength(150, ErrorMessage = "{0} نمی تواند کمتر از {1} باشد")]
        public string QuestionDescription { get; set; }
        public DateTime CreateDate { get; set; }

        public int UserId { get; set; }
        public int ProductId { get; set; }

        #region Relations
        [ForeignKey("UserId")]
        public User user { get; set; }

        [ForeignKey("ProductId")]
        public Product product { get; set; }
        public List<Answer> answers { get; set; }
        #endregion
    }
}
