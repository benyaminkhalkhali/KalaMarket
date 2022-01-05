using KalaMarket.Core.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalaMarket.Components
{
    [ViewComponent(Name = "ShowMenuViewComponent")]
    public class ShowMenuViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;
        public ShowMenuViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("ShowMenu", _categoryService.GetAllCategoryForMenu()));
        }
    }
}
