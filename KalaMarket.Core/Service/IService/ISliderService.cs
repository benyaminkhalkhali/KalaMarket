using KalaMarket.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service.IService
{
    public interface ISliderService
    {
        List<MainSlider> ShowAllSlider(int page);
        MainSlider FindSliderById(int sliderId);
        int AddSlider(MainSlider mainSlider);
        bool UpdateSlider(MainSlider mainSlider);
        bool DeleteSlider(MainSlider mainSlider);
        int SliderCount();
        List<MainSlider> ShowSliderForUser();
    }
}
