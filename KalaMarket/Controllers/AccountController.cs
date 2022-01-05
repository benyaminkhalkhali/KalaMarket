using KalaMarket.Core.ExtensionMethod;
using KalaMarket.Core.GoogleRecaptcha;
using KalaMarket.Core.Security;
using KalaMarket.Core.Service.IService;
using KalaMarket.Core.ViewModel;
using KalaMarket.DataLayer.Entities;
using KalaMarket.DataLayer.Entities.Address;
using KalaMarket.DataLayer.Entities.ProductEntities;
using KalaMarket.DataLayer.Entities.Role;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static Kalamarket.Core.ExtentionMethod.RenderEmail;

namespace KalaMarket.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IRoleService _roleService;
        private readonly IGoogleRecaptcha _recaptcha;
        private IViewRenderService _renderEmail;
        public AccountController(IUserService userService, IViewRenderService renderEmail,
            IRoleService roleService, IGoogleRecaptcha recaptcha)
        {
            _userService = userService;
            _renderEmail = renderEmail;
            _roleService = roleService;
            _recaptcha = recaptcha;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!await _recaptcha.IsSatisfy())
            {
                ModelState.AddModelError("", "اعتبارسنجی recaptcha انجام نشد");
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (_userService.IsEmailExists(model.Email))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده تکراری است");
                return View(model);
            }
            User user = new User
            {
                FirstAndLastName = model.FirstAndLastName,
                CreateAccount = DateTime.Now,
                Email = model.Email.Replace(" ",""),
                IsActive = false,
                IsDelete = false,
                Password = model.Password.EncodePasswordMd5(),
                ActiveCode = GenerateCode.GuidCode(),
            };
            int userId = _userService.AddUser(user);
            if (userId > 0)
            {
                var renderView = _renderEmail.RenderToStringAsync("_ActiveEmail", user);
                sendEmail.Send(user.Email, "فعالسازی", renderView);
                return View("Welcome", user.Email);
            }
            return View(model);
        }


        [Route("Account/ActiveAccount/{userId}/{code}")]
        public IActionResult ActiveAccount(int userId, string code)
        {
            User user = _userService.FindUser(userId, code);
            if (user == null)
                return NotFound();

            user.IsActive = true;
            user.ActiveCode = GenerateCode.GuidCode();
            _userService.UpdateUser(user);
            return RedirectToAction("Login", "Account");
            
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordVM model)
        {
            User user = _userService.FindUserByEmail(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "کاربری با این مشخصات یافت نشد");
                return View(model);
            }
            var renderView = _renderEmail.RenderToStringAsync("_RecoveryPassword", user);
            sendEmail.Send(user.Email, "بازیابی کلمه عبور", renderView);
            return View("RecoveryMessage", user.Email);
            
        }


        [Route("Account/Recovery/{userId}/{code}")]
        public IActionResult Recovery(int userId, string code)
        {
            User user = _userService.FindUser(userId, code);
            ForgotPasswordVM viewmodel = new ForgotPasswordVM
            {
                UserId = user.UserId,
                Email = user.Email
            };

            if (user != null)
            {
                return View("Recovery", viewmodel);
            }
            return View();
        }

        [HttpPost]
        [Route("Account/Recovery/{userId}/{code}")]
        public IActionResult Recovery(ForgotPasswordVM model)
        {
            if (!ModelState.IsValid)
                return View("Recovery", model);

            User user = _userService.FindUserByEmail(model.Email);
            if (user != null)
            {
                user.ActiveCode = GenerateCode.GuidCode();
                user.Password = model.Password.EncodePasswordMd5();
            }
            
            bool updateUser = _userService.UpdateUser(user);
            TempData["Result"] = updateUser ? "true" : "false";
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Login()
        {
            return View();
        } 
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!await _recaptcha.IsSatisfy())
            {
                ModelState.AddModelError("", "اعتبارسنجی recaptcha انجام نشد");
                return View(model);
            }
            if (!ModelState.IsValid)
                return View(model);
            
            User user = _userService.LoginUser(model.Email, model.Password.EncodePasswordMd5());
            if (user != null)
            {
                if (user.IsActive)
                {
                    var claim = new List<Claim>
                    {
                        new Claim("userid", user.UserId.ToString()),
                        new Claim("useremail", user.Email)
                    };
                    var option = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe
                    };
                    await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claim, "Cookies")), option);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("RememberMe", "حساب کاربری شما فعال نمی باشد");
                    return View(model);
                }
                
            }
           
            ModelState.AddModelError("RememberMe", "کاربری بااین مشخصات یافت نشد");
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult DeleteUserByAdmin([FromBody] User model)
        {
            string result = "";
            if (_userService.DeleteUser(model.UserId) == true)
            {
                result = "OK";
            }
            else
            {
                result = "NOK";
            }
            return Json(result);
        }


        [HttpPost]
        public JsonResult DeleteRole([FromBody] Role model)
        {
            string result = "";

            var role = _roleService.GetRoleById(model.RoleId);
            if (role.RoleTitle == "Admin" || role.RoleTitle == "Default")
                result = "NOK";
            else
            {
                if (_roleService.DeleteRole(model.RoleId) == true)
                    result = "OK";
                else
                    result = "NOK";
            }

            return Json(result);
        }


        [HttpGet]
        [Route("CheckAuthorize")]
        public IActionResult CheckAuthorize()
        {
            return Json(User.Identity.IsAuthenticated);
        }

        



    }
}
