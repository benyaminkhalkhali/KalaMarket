using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class ShowAddressForUserVM
    {
        public int AddressId { get; set; }


        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(11, ErrorMessage = "تلفن همراه نمی تواند کمتر از 11 کاراکتر داشته باشد")]
        [MaxLength(11, ErrorMessage = "تلفن همراه نمی تواند بیشتر از 11 کاراکتر داشته باشد")]
        public string PhoneNumber { get; set; }


        [Display(Name = "کدپستی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int PostalCode { get; set; }

        [Display(Name = "آدرس کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(20, ErrorMessage = "آدرس کامل نمی تواند کمتر از 20 کاراکتر داشته باشد")]
        [MaxLength(400, ErrorMessage = "آدرس کامل نمی تواند بیشتر از 400 کاراکتر داشته باشد")]
        public string FullAddress { get; set; }


        [Display(Name = "شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CityName { get; set; }

        [Display(Name = "استان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ProvinceName { get; set; }
        public int UserId { get; set; }

    }
}
