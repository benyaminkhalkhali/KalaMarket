using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalaMarket.Core.Security;
using KalaMarket.Core.Service.IService;
using KalaMarket.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.Pages.Admin.Users
{
    [MyAuthorize("Admin")]
    public class IndexModel : PageModel
    {
        private IUserService _userService;
        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }


        public ShowUsersInAdminVM model { get; set; }
        public void OnGet(int pageId = 1, int take = 10, string filterByName = "", string filterByMobile = "", string filterByEmail = "")
        {
            @ViewData["Take"] = take;
            ViewData["FilterByName"] = filterByName;
            ViewData["FilterByMobile"] = filterByMobile;
            ViewData["FilterByEmail"] = filterByEmail;
            model = _userService.ShowUserInAdmin(pageId, take, filterByName, filterByMobile, filterByEmail);
        }
    }
}
