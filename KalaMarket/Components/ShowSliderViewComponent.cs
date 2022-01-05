using KalaMarket.Core.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalaMarket.Components
{
    [ViewComponent(Name = "showslideruser")]
    public class ShowSliderViewComponent : ViewComponent
    {
        private ISliderService _sliderService;
        public ShowSliderViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("ShowSliderForUser", _sliderService.ShowSliderForUser()));
        }
    }
}
