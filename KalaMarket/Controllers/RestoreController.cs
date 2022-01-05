using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Entities.ProductEntities.FAQ;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalaMarket.Controllers
{
    public class RestoreController : Controller
    {
        private IProductService _productService;
        public RestoreController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        public JsonResult RestoreComment([FromBody] Comment model)
        {
            string result = "";
            if (_productService.RestoreComment(model.CommentId))
                result = "OK";
            else
                result = "NOK";

            return Json(result);
        }
    }
}
