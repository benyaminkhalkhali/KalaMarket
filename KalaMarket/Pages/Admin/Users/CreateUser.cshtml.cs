using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalaMarket.Core.Service.IService;
using KalaMarket.Core.ViewModel;
using KalaMarket.DataLayer.Entities.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.Pages.Admin.Users
{
    public class CreateUserModel : PageModel
    {
        private IRoleService _roleService;
        private IUserService _userService;
        public CreateUserModel(IRoleService roleService , IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }


        [BindProperty]
        public AddUserByAdminVM AddUser { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            ViewData["Roles"] = _roleService.GetAllRoles();
        }


        public IActionResult OnPost(List<int> selectedRoles)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Roles"] = _roleService.GetAllRoles();
                Message = "ورودی های خود را بررسی کنید!";
                return Page();
            }
            if (_userService.IsEmailExists(AddUser.Email))
            {
                ViewData["Roles"] = _roleService.GetAllRoles();
                ModelState.AddModelError("AddUser.Email", "ایمیل وارد شده تکراری است");
                return Page();
            }
            if (_userService.IsMobileExists(AddUser.PhoneNumber))
            {
                ViewData["Roles"] = _roleService.GetAllRoles();
                ModelState.AddModelError("AddUser.PhoneNumber", "موبایل وارد شده تکراری است");
                return Page();
            }

            int userId = _userService.AddUserByAdmin(AddUser);
            if(userId <= 0)
            {
                ViewData["Roles"] = _roleService.GetAllRoles();
                Message = "خطایی رخ داد!";
                return Page();
            }
            if (_roleService.AddUserToRole(userId, selectedRoles))
            {
                return Redirect("/Admin/Users");
            }
            else
            {
                ViewData["Roles"] = _roleService.GetAllRoles();
                Message = "در هنگام افزودن کاربر به نقش خطایی رخ داد!";
                return Page();
            }
        }
    }
}
