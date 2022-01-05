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
    public class DeactiveUsersModel : PageModel
    {
        private IUserService US;
        public DeactiveUsersModel(IUserService _US)
        {
            US = _US;
        }

        public ShowUsersInAdminVM model { get; set; }

        public void OnGet(int PageId = 1, int Take = 10, string FilterByName = "", string FilterByMobile = "", string FilterByEmail = "")
        {
            ViewData["Take"] = Take;
            ViewData["FilterByName"] = FilterByName;
            ViewData["FilterByEmail"] = FilterByEmail;
            ViewData["FilterByMobile"] = FilterByMobile;

            model = US.DeactiveUsers(PageId, Take, FilterByName, FilterByMobile, FilterByEmail);
        }
    }
}
