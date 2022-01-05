using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class EditUserVM
    {

        [Display(Name = "نام و نام خانوادگی")]
        public string UserNameAndFamily { get; set; }

        [Display(Name = "شماره تماس")]
        public string Phone { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        
    }
}
