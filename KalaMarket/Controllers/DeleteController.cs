using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Entities.Discount;
using KalaMarket.DataLayer.Entities.ProductEntities;
using KalaMarket.DataLayer.Entities.ProductEntities.FAQ;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalaMarket.Controllers
{
    public class DeleteController : Controller
    {

        private IProductService _productService;
        private IDiscountService _discountService;
        private ICategoryService _categoryService;
        public DeleteController(IProductService productService, IDiscountService discountService
            , ICategoryService categoryService)
        {
            _productService = productService;
            _discountService = discountService;
            _categoryService = categoryService;
        }

        [HttpPost]
        public JsonResult DeleteColor([FromBody] ProductColor model)
        {
            string result = "";
            if (_productService.DeleteColor(model.ColorId) == true)
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
        public JsonResult DeletePrice([FromBody] ProductPrice model)
        {
            string result = "";
            if (_productService.DeletePrice(model.ProductPriceId) == true)
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
        public JsonResult DeleteProduct([FromBody] Product model)
        {
            string result = "";
            if (_productService.DeleteProduct(model.ProductId) == true)
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
        public JsonResult DeleteDiscount([FromBody] Discount model)
        {
            string result = "";
            if (_discountService.DeleteDiscount(model.DiscountId) == true)
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
        public JsonResult DeleteComment([FromBody] Comment model)
        {
            string result = "";
            if (_productService.DeleteComment(model.CommentId))
                result = "OK";
            else
                result = "NOK";

            return Json(result);
        }

        [HttpPost]
        public JsonResult DeleteCategory([FromBody] Category model)
        {
            string result = "";
            if (_categoryService.DeleteCategory(model.CategoryId) == true)
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
        public JsonResult DeleteProperties([FromBody] PropertyName model)
        {
            string result = "";
            if (_productService.DeleteProperty(model.PropertyNameId) == true)
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
        public JsonResult DeleteGallery([FromBody] ProductGallery model)
        {
            string result = "";
            if (_productService.DeleteGallery(model.GalleryId) == true)
            {
                result = "OK";
            }
            else
            {
                result = "NOK";
            }
            return Json(result);
        }
    }
}
