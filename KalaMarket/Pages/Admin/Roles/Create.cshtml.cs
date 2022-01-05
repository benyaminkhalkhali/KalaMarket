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
    public class CreateModel : PageModel
    {
        private IRoleService _roleService;
        public CreateModel(IRoleService roleService)
        {
            _roleService = roleService;
        }


        [BindProperty]
        public Role role { get; set; }
        public string message { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            if (_roleService.IsRoleExists(role.RoleTitle))
            {
                message = "عنوان نقش تکراری است!";
                ModelState.AddModelError("role.RoleTitle", "عنوان نقش تکراری است");
                return Page();
            }
            if (_roleService.AddRole(role))
            {
                return Redirect("/Admin/Roles");
            }
            message = "خطایی رخ داد!";
            return Page();
        }
    }
}
