using KalaMarket.Core.ExtensionMethod;
using KalaMarket.Core.Security;
using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalaMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    [MyAuthorize("Admin")]
    public class SliderController : Controller
    {
        private ISliderService _sliderService;
        public SliderController(ISliderService SliderService)
        {
            _sliderService = SliderService;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.page = page;
            ViewBag.CountSlider = _sliderService.SliderCount();
            return View(_sliderService.ShowAllSlider(page));
        }

        [HttpGet]
        public IActionResult AddSlider()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSlider(MainSlider mainSlider, IFormFile file)
        {
            if (mainSlider.SliderSort <= 0 )
            {
                ModelState.AddModelError("ErrorSort", "لطفا ترتیبی برای اسلایدر خود انتخاب کنید");
                return View(mainSlider);
            }

            if (!ModelState.IsValid)
                return View(mainSlider);
            if(file == null)
            {
                ModelState.AddModelError("SliderImage", "لطفا برای اسلاید خود تصویری را انتخاب نمایید");
                return View(mainSlider);
            }
            string imageName = UploadImage.CreateImage(file);
            if (imageName == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(Index));
            }
            mainSlider.SliderImage = imageName;
            int res = _sliderService.AddSlider(mainSlider);
            TempData["Result"] = res > 0 ? "true" : "false";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult UpdateSlider(int id)
        {
            MainSlider mainSlider = _sliderService.FindSliderById(id);
            if (mainSlider == null)
            {
                TempData["NotFoundSlider"] = "true";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(mainSlider);
            }
        }

        [HttpPost]
        public IActionResult UpdateSlider(MainSlider mainSlider, IFormFile file)
        {
            if (!ModelState.IsValid)
                return View(mainSlider);

            if (file != null)
            {
                string imageName = UploadImage.CreateImage(file);
                if (imageName == "false")
                {
                    TempData["Result"] = "false";
                    return RedirectToAction(nameof(Index));
                }
                bool deleteImage = UploadImage.DeleteImage("ImageSite", mainSlider.SliderImage);
                if (!deleteImage)
                {
                    TempData["Result"] = "false";
                    return RedirectToAction(nameof(Index));
                }
                mainSlider.SliderImage = imageName;
            }

            bool res = _sliderService.UpdateSlider(mainSlider);
            TempData["Result"] = res ? "true" : "false";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult DeleteSlider(int id)
        {
            MainSlider mainSlider = _sliderService.FindSliderById(id);
            if (mainSlider == null)
            {
                TempData["NotFoundSlider"] = "true";
                return RedirectToAction(nameof(Index));
            }
            return View(mainSlider);
        }

        [HttpPost]
        public IActionResult DeleteSlider(MainSlider mainSlider)
        {
            bool deleteImage = UploadImage.DeleteImage("ImageSite", mainSlider.SliderImage);
            if (!deleteImage)
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(Index));
            }
            bool res = _sliderService.DeleteSlider(mainSlider);
            TempData["Result"] = res ? "true" : "false";
            return RedirectToAction(nameof(Index));
        }
    }
}
