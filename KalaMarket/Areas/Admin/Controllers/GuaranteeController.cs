using KalaMarket.Core.Security;
using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Entities.ProductEntities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalaMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    [MyAuthorize("Admin")]
    public class GuaranteeController : Controller
    {
        private IGuaranteeService _guaranteeService;
        public GuaranteeController(IGuaranteeService guaranteeService)
        {
            _guaranteeService = guaranteeService;
        }
        public IActionResult ShowAllGuarantees()
        {
            return View(_guaranteeService.ShowAllGuarantee());
        }

        [HttpGet]
        public IActionResult AddGuarantees()
        {
            return PartialView("_AddGuarantee");
        }

        [HttpPost]
        public IActionResult AddGuarantees(ProductGuarantee productGuarantee)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(ShowAllGuarantees));
            if (_guaranteeService.IsGuaranteeExists(productGuarantee.GuaranteeName, 0))
            {
                return Json(5);
            }
            int guaranteeid = _guaranteeService.AddGuarantee(productGuarantee);
            int sendJson = guaranteeid > 0 ? 1 : 4;
            return Json(sendJson);
        }

        [HttpGet]
        public IActionResult UpdateGuarantees(int id)
        {

            return PartialView("_UpdateGuarantee",_guaranteeService.FindGuaranteeById(id));
        }

        [HttpPost]
        public IActionResult UpdateGuarantees(ProductGuarantee productGuarantee)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(ShowAllGuarantees));
            if (_guaranteeService.IsGuaranteeExists(productGuarantee.GuaranteeName, productGuarantee.GuaranteeId))
            {
                return RedirectToAction(nameof(ShowAllGuarantees));
            }
            bool guaranteeid = _guaranteeService.UpdateGuarantee(productGuarantee);
            int sendJson = guaranteeid ? 2 : 4;
            return Json(sendJson);
        }

        [HttpGet]
        public IActionResult DeleteGuarantees(int id)
        {
            return PartialView("_DeleteGuarantee", _guaranteeService.FindGuaranteeById(id));
        }

        [HttpPost]
        public IActionResult DeleteGuarantees(ProductGuarantee productGuarantee)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(ShowAllGuarantees));
  
            bool guaranteeid = _guaranteeService.DeleteGuarantee(productGuarantee);
            int sendJson = guaranteeid ? 3 : 4;
            return Json(sendJson);
        }
    }
}
