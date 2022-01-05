using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Entities.Discount;
using KalaMarket.Core.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalaMarket.Core.ViewModel;
using KalaMarket.Core.Security;

namespace KalaMarket.Areas.Admin.Controllers
{

    [Area("Admin")]
    [MyAuthorize("Admin")]
    public class DiscountController : Controller
    {
        private IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public IActionResult ShowAllDiscount(int page = 1)
        {
            ViewBag.page = page;
            ViewBag.CountDiscount = _discountService.DiscountCount();
            return View(_discountService.ShowAllDiscounts(page));
        }

        [HttpGet]
        public IActionResult AddDiscount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDiscount(DiscountVM discount)
        {
            if (!ModelState.IsValid)
                return View(discount);

            Discount allDiscounts = new Discount
            {
                DiscountCode = discount.DiscountCode,
                DiscountPercent = discount.DiscountPercent,
                StartDate = discount.StartDate?.ToMiladi(),
                EndDate = discount.EndDate?.ToMiladi(),
                UsableCount = discount.UsableCount,
                DiscountId = discount.DiscountId,
            };
            int discountid = _discountService.AddDiscounts(allDiscounts);
            TempData["Result"] = discountid > 0 ? "true" : "false";
            return RedirectToAction(nameof(ShowAllDiscount));
        }

    }
}
