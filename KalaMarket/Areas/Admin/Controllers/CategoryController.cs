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
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            _categoryService = CategoryService;
        }

        public IActionResult ShowAllCategories(int page = 1)
        {
            ViewBag.page = page;
            ViewBag.CountCategory = _categoryService.CategoryCount();
            return View(_categoryService.ShowAllCategory(page));
        }

        [HttpGet]
        public IActionResult AddCategories(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddCategories(Category category)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.id = category.SubCategory;
                return View(category);
            }
                
            if (_categoryService.IsCategoryExists(category.CategoryFaTitle, category.CategoryEnTitle, 0))
            {
                ModelState.AddModelError("CategoryEnTitle", "دسته بندی تکراری است");
                ViewBag.id = category.SubCategory;
                return View(category);
            }
            int cateid = _categoryService.AddCategory(category);
            TempData["Result"] = cateid > 0 ? "true" : "false";
            return RedirectToAction(nameof(ShowAllCategories));
        }

        [HttpGet]
        public IActionResult UpdateCategories(int id)
        {
            Category update = _categoryService.FindCategoryById(id);
            if (update == null)
            {
                return NotFound();
            }
            ViewBag.id = id;
            return View(update);
        }

        [HttpPost]
        public IActionResult UpdateCategories(Category category)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.id = category.SubCategory;
                return View(category);
            }

            if (_categoryService.IsCategoryExists(category.CategoryFaTitle, category.CategoryEnTitle, 0))
            {
                ModelState.AddModelError("CategoryEnTitle", "دسته بندی تکراری است");
                ViewBag.id = category.SubCategory;
                return View(category);
            }
            bool res = _categoryService.UpdateCategory(category);
            TempData["Result"] = res ? "true" : "false";
            return RedirectToAction(nameof(ShowAllCategories));
        }

        [HttpGet]
        public IActionResult ShowAllSubCategories(int id, int page = 1)
        {
            ViewBag.page = page;
            ViewBag.id = id;
            ViewBag.CountCategory = _categoryService.CategoryCount();
            return View(_categoryService.ShowAllSubCategory(id, page));
        }

        [HttpGet]
        public IActionResult ShowAllSubCategoriesTree(int id, int page = 1)
        {
            ViewBag.page = page;
            ViewBag.id = id;
            ViewBag.CountCategory = _categoryService.CategoryCount();
            return View(_categoryService.ShowAllSubCategory(id, page));
        }


    }
}
