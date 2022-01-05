using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalaMarket.Core.Service.IService;
using KalaMarket.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.Pages.Admin.Users
{
    public class EditUserModel : PageModel
    {
        private IRoleService _roleService;
        private IUserService _userService;
        public EditUserModel(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }


        [BindProperty]
        public EditUserByAdminVM EditUser { get; set; }
        public string message { get; set; }
        public void OnGet(int id)
        {
            ViewData["Roles"] = _roleService.GetAllRoles();
            EditUser = _userService.GetUserDataForEditInAdminPanel(id);
        }

        public IActionResult OnPost(List<int> selectedRoles)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Roles"] = _roleService.GetAllRoles();
                EditUser = _userService.GetUserDataForEditInAdminPanel(EditUser.UserId);
                message = "لطفا ورودی هارا بررسی کنید!";
                return Page();
            }

            var user = _userService.GetUserById(EditUser.UserId);

            if (user.Email != EditUser.Email)
            {
                if (_userService.IsEmailExists(EditUser.Email))
                {
                    ModelState.AddModelError("EditUser.Email", "ایمیل وارد شده تکراری است");
                    ViewData["Roles"] = _roleService.GetAllRoles();
                    EditUser = _userService.GetUserDataForEditInAdminPanel(EditUser.UserId);
                    message = "لطفا ورودی هارا بررسی کنید!";
                    return Page();
                }
                

            }
            if (user.Email != EditUser.PhoneNumber)
            {
                if (_userService.IsMobileExists(EditUser.PhoneNumber))
                {
                    ModelState.AddModelError("EditUser.PhoneNumber", "موبایل وارد شده تکراری است");
                    ViewData["Roles"] = _roleService.GetAllRoles();
                    EditUser = _userService.GetUserDataForEditInAdminPanel(EditUser.UserId);
                    message = "لطفا ورودی هارا بررسی کنید!";
                    return Page();
                }
            }

            _roleService.RemoveUserFromAllRoles(EditUser.UserId);
            if (_userService.EditUserByAdmin(EditUser) == true && 
                _roleService.AddUserToRole(EditUser.UserId, selectedRoles) == true)
            {
                ViewData["Roles"] = _roleService.GetAllRoles();
                EditUser = _userService.GetUserDataForEditInAdminPanel(EditUser.UserId);
                message = "تغییرات باموفقیت ذخیره شد!";
                return Page();
            }
            else
            {
                ViewData["Roles"] = _roleService.GetAllRoles();
                EditUser = _userService.GetUserDataForEditInAdminPanel(EditUser.UserId);
                message = "خطایی رخ داد مجددا تلاش کنید!";
                return Page();
            }
        }
    }
}
