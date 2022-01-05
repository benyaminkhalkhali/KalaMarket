using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.ProductEntities.FAQ
{
    public class Answer
    {
        public int AnswerId { get; set; }

        [Display(Name = "متن پاسخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MinLength(5, ErrorMessage = "{0} نمی تواند کمتر از {1} باشد")]
        [MaxLength(150, ErrorMessage = "{0} نمی تواند کمتر از {1} باشد")]
        public string AnswerDescription { get; set; }
        public DateTime CreateDate { get; set; }

        public int QuestionId { get; set; }
        public int UserId { get; set; }

        #region Relation

        [ForeignKey("QuestionId")]
        public Question question { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }
        #endregion
    }
}
