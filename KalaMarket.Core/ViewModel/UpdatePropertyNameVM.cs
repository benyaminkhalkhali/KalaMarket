using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class UpdatePropertyNameVM
    {
        public int PropertyNameId { get; set; }

        [Display(Name = "عنوان خصوصیات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MinLength(5, ErrorMessage = "{0} نمی تواند کمتر از {1} باشد")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند کمتر از {1} باشد")]
        public string PropertyTitle { get; set; }

        public int pcId { get; set; }
        public int CategoryId { get; set; }
    }
}
