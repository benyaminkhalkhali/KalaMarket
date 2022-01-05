using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalaMarket.Core.Service.IService;
using KalaMarket.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.Pages.Admin.Comments
{
    public class IndexModel : PageModel
    {

        private IProductService _productService;
        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public CommentListInAdminVM model { get; set; }
        public bool? Checked { get; set; }
        public void OnGet(bool? isActive, int take = 10, int pageId = 1)
        {
            model = _productService.GetAllCommentsInAdmin(isActive, take, pageId);
            Checked = isActive;
        }
    }
}
