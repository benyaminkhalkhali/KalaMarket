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
    public class BrandController : Controller
    {
        private IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        public IActionResult ShowAllBrand()
        {
            return View(_brandService.ShowAllBrands());
        }

        [HttpGet]
        public IActionResult AddBrands()
        {
            return PartialView("_AddBrand");
        }

        [HttpPost]
        public IActionResult AddBrands(Brand brand)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(ShowAllBrand));
            if (_brandService.IsBrandExists(brand.BrandName, 0))
            {
                return Json(5);
            }
            int brandid = _brandService.AddBrand(brand);
            int sendJson = brandid > 0 ? 1 : 4;
            return Json(sendJson);
        }

        [HttpGet]
        public IActionResult UpdateBrands(int id)
        {

            return PartialView("_UpdateBrand", _brandService.FindBrandById(id));
        }

        [HttpPost]
        public IActionResult UpdateBrands(Brand brand)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(ShowAllBrand));
            if (_brandService.IsBrandExists(brand.BrandName, brand.BrandId))
            {
                return RedirectToAction(nameof(ShowAllBrand));
            }
            bool brandid = _brandService.UpdateBrand(brand);
            int sendJson = brandid ? 2 : 4;
            return Json(sendJson);
        }

        [HttpGet]
        public IActionResult DeleteBrands(int id)
        {
            return PartialView("_DeleteBrand", _brandService.FindBrandById(id));
        }

        [HttpPost]
        public IActionResult DeleteBrands(Brand brand)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(ShowAllBrand));

            bool brandid = _brandService.DeleteBrand(brand);
            int sendJson = brandid ? 3 : 4;
            return Json(sendJson);
        }
    }
}
