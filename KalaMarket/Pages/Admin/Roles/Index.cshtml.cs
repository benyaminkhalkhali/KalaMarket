using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalaMarket.Core.Security;
using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Entities.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.Pages.Admin.Roles
{
    [MyAuthorize("Admin")]
    public class IndexModel : PageModel
    {
        private IRoleService _roleService;
        public IndexModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public List<Role> AllRoles { get; set; }
        public void OnGet()
        {
            AllRoles = _roleService.GetAllRoles();
        }
    }
}
