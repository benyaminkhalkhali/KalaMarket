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
    public class DeletedCommentsModel : PageModel
    {
        private IProductService _productService;
        public DeletedCommentsModel(IProductService productService)
        {
            _productService = productService;
        }

        public CommentListInAdminVM model { get; set; }

        public bool? Checked { get; set; }

        public void OnGet(bool? isActive, int Take = 10, int PageId = 1)
        {
            model = _productService.GetAllDeletedComments(isActive, Take, PageId);

            Checked = isActive;
            ViewData["Take"] = Take;
        }
    }
}

