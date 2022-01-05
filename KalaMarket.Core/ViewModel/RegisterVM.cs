using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class RegisterVM
    {

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        public string FirstAndLastName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار رمزعبور")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        [Compare(nameof(Password), ErrorMessage = "رمزهای عبور باهم مطابقت ندارند")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }



        [Range(typeof(bool), "true", "true", ErrorMessage = "لطفا با قوانین سایت موافقت کنید")]
        public bool IsAccept { get; set; }
    }
}
