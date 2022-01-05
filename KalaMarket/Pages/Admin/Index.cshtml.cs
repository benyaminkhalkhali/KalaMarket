using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalaMarket.Core.Security;
using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Entities;
using KalaMarket.DataLayer.Entities.ProductEntities;
using KalaMarket.DataLayer.Entities.ProductEntities.FAQ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace KalaMarket.Pages.Admin
{
    [MyAuthorize("Admin")]
    public class IndexModel : PageModel
    {
        private ISiteSettingService _siteSettingService;
        private IProductService _productService;

        public IndexModel(ISiteSettingService siteSettingService, IProductService productService)
        {
            _siteSettingService = siteSettingService;
            _productService = productService;
        }

        public List<Cart> Orders { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Product> Products { get; set; }

        public void OnGet()
        {
            Orders = _siteSettingService.GetNotConfirmOrders(5);
            Comments = _siteSettingService.GetNotConfirmedComments(5);
           Products = _siteSettingService.GetBestSellerProducts(5);
        }
    }
}