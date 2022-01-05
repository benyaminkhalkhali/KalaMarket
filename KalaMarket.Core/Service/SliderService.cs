using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Context;
using KalaMarket.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service
{
    public class SliderService : ISliderService
    {
        private KalaMarketContext _context;
        public SliderService(KalaMarketContext Context)
        {
            _context = Context;
        }


        public int AddSlider(MainSlider mainSlider)
        {
           try
            {
                _context.mainSliders.Add(mainSlider);
                _context.SaveChanges();
                return mainSlider.SliderId;
            }
            catch
            {
                return 0;
            }
        }

        public bool DeleteSlider(MainSlider mainSlider)
        {
            try
            {
                _context.mainSliders.Remove(mainSlider);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public MainSlider FindSliderById(int sliderId)
        {
            return _context.mainSliders.Find(sliderId);
        }

        public List<MainSlider> ShowAllSlider(int page)
        {
            int skip = (page - 1) * 2;
            return _context.mainSliders.OrderBy(s=>s.SliderSort).Skip(skip).Take(6).ToList();
        }

        public bool UpdateSlider(MainSlider mainSlider)
        {
            try
            {
                _context.mainSliders.Update(mainSlider);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int SliderCount()
        {
            int sliderCounts = _context.mainSliders.Count();
            if (sliderCounts % 2 != 0)
                sliderCounts++;

            sliderCounts = sliderCounts / 2;
            return sliderCounts;
        }
        public List<MainSlider> ShowSliderForUser()
        {
            return _context.mainSliders.Where(c => c.IsActive).ToList();
        }
    }
}
