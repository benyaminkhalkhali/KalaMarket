using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Entities.ProductEntities.FAQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.Pages.Admin.Comments
{
    public class DetailsModel : PageModel
    {
        private IProductService _productService;
        public DetailsModel(IProductService productService)
        {
            _productService = productService;
        }

        public Comment model { get; set; }

        public void OnGet(int Id)
        {
            model = _productService.GetCommentById(Id);
        }
    }
}
