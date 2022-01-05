using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Entities.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.Pages.Admin.Roles
{
    public class EditModel : PageModel
    {
        private IRoleService _roleService;
        public EditModel(IRoleService roleService)
        {
            _roleService = roleService;
        }


        [BindProperty]
        public Role model { get; set; }
        public string message { get; set; }
        public void OnGet(int id)
        {
            model = _roleService.GetRoleById(id);
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                model = _roleService.GetRoleById(model.RoleId);
                message = "لطفا ورودی های خود را بررسی کنید";
                return Page();
            }

            var role = _roleService.GetRoleById(model.RoleId);
            if (role.RoleTitle == "Admin" || role.RoleTitle == "Default")
            {
                model = _roleService.GetRoleById(model.RoleId);
                message = "لطفا ورودی های خود را بررسی کنید";
                ModelState.AddModelError("model.RoleTitle", "این نقش قابل ویرایش نیست");
                return Page();
            }

            if (role.RoleTitle != model.RoleTitle)
            {
                if (_roleService.IsRoleExists(model.RoleTitle))
                {
                    model = _roleService.GetRoleById(model.RoleId);
                    message = "لطفا ورودی های خود را بررسی کنید";
                    ModelState.AddModelError("model.RoleTitle", "عنوان نقش تکراری است");
                    return Page();
                }
            }
            message = _roleService.EditRole(model);
            model = _roleService.GetRoleById(model.RoleId);
            return Page();

        }
    }
}
