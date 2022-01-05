using KalaMarket.Core.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalaMarket.Components
{
    [ViewComponent(Name = "sliderforlatest")]
    public class LatestViewComponent : ViewComponent
    {
        private IProductService _productService;
        public LatestViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("Latest", _productService.ShowLatestProductForWeb()));
        }
    }
}
