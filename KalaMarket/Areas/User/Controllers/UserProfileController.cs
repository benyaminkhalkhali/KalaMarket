using KalaMarket.Core.Service.IService;
using KalaMarket.Core.ViewModel;
using KalaMarket.DataLayer.Entities.Address;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalaMarket.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]

    public class UserProfileController : Controller
    {
        private IAddressService _addressService;
        private IUserService _userService;
        public UserProfileController(IAddressService addressService, IUserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }


        public IActionResult Index()
        {
            int userId = int.Parse(User.FindFirst("userid").Value);
            return View(_userService.InformationAccount(userId));
        }

        public IActionResult Address()
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            ViewBag.information = _userService.InformationAccount(userid);
            return View(_addressService.FindAddressForUser(userid));
        }

        [HttpGet]
        public IActionResult AddAddress()
        {
            int userId = int.Parse(User.FindFirst("userid").Value);
            ViewBag.information = _userService.InformationAccount(userId);
            return View();
        }

        [HttpPost]
        public IActionResult AddAddress(UserAddress model)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            model.UserId = userid;
            if (!ModelState.IsValid)
            {
                ViewBag.information = _userService.InformationAccount(userid);
                return View();
            }
            ViewBag.information = _userService.InformationAccount(userid);
            int addressid = _addressService.AddUserAddress(model);
            TempData["Result"] = addressid > 0 ? "true" : "false";
            return RedirectToAction(nameof(Address));
        }

        

        [HttpGet]
        public IActionResult UpdateAddress()
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            ShowAddressForUserVM useraddress = _addressService.FindAddressForUser(userid);
            //ViewBag.province = _addressService.ShowAllProvince();
            //ViewBag.city = _addressService.ShowAllCityForProvince(useraddress.ProvinceId);
            ViewBag.information = _userService.InformationAccount(userid);
            return View(useraddress);

        }

        [HttpPost]
        public IActionResult UpdateAddress(ShowAddressForUserVM viewmodel)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            if (!ModelState.IsValid)
            {
                ViewBag.information = _userService.InformationAccount(userid);
                return View(viewmodel);
            }
            UserAddress useraddress = new UserAddress
            {
                AddressId = viewmodel.AddressId,
                FullAddress = viewmodel.FullAddress,
                IsDelete = false,
                PhoneNumber = viewmodel.PhoneNumber, 
                City = viewmodel.CityName,
                Province = viewmodel.ProvinceName,
                UserId = userid
            };
            bool updateaddress = _addressService.UpdateAddress(useraddress);
            TempData["Result"] = updateaddress ? "true" : "false";
            return RedirectToAction(nameof(Address));
        }


        [HttpGet]
        [Route("EditUser")]
        public IActionResult EditUser()
        {
            int userId = int.Parse(User.FindFirst("userid").Value);
            ViewBag.information = _userService.InformationAccount(userId);
            return View(_userService.FindUserById(userId));
        }

        [HttpPost]
        [Route("EditUser")]
        public IActionResult EditUser(EditUserVM edituser)
        {
            int userId = int.Parse(User.FindFirst("userid").Value);
            var model = _userService.FindEditUserBuId(userId);
            model.FirstAndLastName = edituser.UserNameAndFamily;
            model.Email = edituser.Email;
            model.PhoneNumber = edituser.Phone;
            _userService.UpdateUser(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("Favourite")]
        public IActionResult Favourite()
        {
            int userId = int.Parse(User.FindFirst("userid").Value);
            ViewBag.information = _userService.InformationAccount(userId);
            return View(_userService.ShowFavouriteUser(userId));
        }

        [HttpGet]
        [Route("ShowOrder")]
        public IActionResult ShowOrder()
        {
            int userId = int.Parse(User.FindFirst("userid").Value);
            ViewBag.information = _userService.InformationAccount(userId);
            return View(_userService.ShowOrderForUsers(userId));
        }


        [HttpGet]
        [Route("ShowOrderDetail/{id}")]
        public IActionResult ShowOrderDetail(int id)
        {
            int userId = int.Parse(User.FindFirst("userid").Value);
            ViewBag.information = _userService.InformationAccount(userId);
            return View(_userService.showDetailOrderForUsers(userId, id));
        }




    }
}
