using KalaMarket.Core.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Security
{
    public class MyAuthorize : AuthorizeAttribute, IAuthorizationFilter
    {

        private string _roleTitle;
        private IRoleService _roleService;
        public MyAuthorize(string roleTitle)
        {
            _roleTitle = roleTitle;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _roleService = (IRoleService)context.HttpContext.RequestServices.GetService(typeof(IRoleService));
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string email = context.HttpContext.User.Identity.GetEmail();
                if (_roleTitle.Contains(","))
                {
                    string[] Titles = _roleTitle.Split(",");
                    int countAccess = 0;
                    foreach (var role in Titles)
                    {
                        if (_roleService.Authorize(role, email))
                        {
                            countAccess++;
                        }
                    }
                    if (countAccess <= 0)
                    {
                        context.Result = new RedirectResult("/Account/AccessDenied?Message=شما دسترسی برای مشاهدهه این صفحه را ندارید");
                    }
                    else
                    {
                            
                    }
                }
                else
                {
                    if (_roleService.Authorize(_roleTitle, email) == false)
                    {
                        context.Result = new RedirectResult("/Account/AccessDenied?Message=شما دسترسی برای مشاهده این صفحه را ندارید");
                    }
                    else
                    {
                            
                    }
                }
            }
            else
            {
                context.Result = new RedirectResult("/Account/Login?ReturnUrl=" + context.HttpContext.Request.Path.Value);
            }
        }
    }
}
