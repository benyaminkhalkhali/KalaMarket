using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class ForgotPasswordVM
    {
        public int UserId { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = " تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        [Compare(nameof(Password), ErrorMessage = "رمزهای عبور باهم مطابقت ندارند")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        
    }
}
