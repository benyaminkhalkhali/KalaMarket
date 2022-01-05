using KalaMarket.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class ShowUsersInAdminVM
    {
        public List<User> users { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public int Count { get; set; }
    }

    public class AddUserByAdminVM
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار رمزعبور")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        [Compare(nameof(Password), ErrorMessage = "رمزهای عبور باهم مطابقت ندارند")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "نامو نام خانوادگی کاربر ")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        public string UserNameAndFamily { get; set; }

        public bool IsActive { get; set; }
    }

    public class EditUserByAdminVM
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار رمزعبور")]
        [Compare(nameof(Password), ErrorMessage = "رمزهای عبور باهم مطابقت ندارند")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "نام و نام خانوادگی کاربر")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        public string UserNameAndFamily { get; set; }


        public bool IsActive { get; set; }

        public int UserId { get; set; }
        public List<int> UserRolesID { get; set; }
    }
}
