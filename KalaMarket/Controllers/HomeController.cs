using KalaMarket.Core.Security;
using KalaMarket.Core.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalaMarket.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        
        public IActionResult Index()
        {
            ViewBag.bestsellers = _productService.GetBestSellerProducts(6);
            ViewBag.latest = _productService.GetLatestProducts(8);
            ViewBag.specialprice = _productService.ShowAllSpecialProduct();
            ViewBag.randomproduct = _productService.RandomProduct();
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
