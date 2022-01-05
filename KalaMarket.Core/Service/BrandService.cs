using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Context;
using KalaMarket.DataLayer.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service
{
    public class BrandService : IBrandService
    {
        private KalaMarketContext _context;
        public BrandService(KalaMarketContext Context)
        {
            _context = Context;
        }

        public List<Brand> ShowAllBrands()
        { 
            return _context.brands.Where(c => !c.IsDelete).ToList();
        }
        public int AddBrand(Brand brand)
        {
            try
            {
                _context.brands.Add(brand);
                _context.SaveChanges();
                return brand.BrandId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool DeleteBrand(Brand brand)
        {
            try
            {
                brand.IsDelete = true;
                _context.brands.Update(brand);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Brand FindBrandById(int id)
        {
            return _context.brands.Find(id);
        }

        public bool IsBrandExists(string brandName, int brandId)
        {
            return _context.brands.Any(b => b.BrandName == brandName && b.BrandId != brandId && !b.IsDelete);
        }

        public bool UpdateBrand(Brand brand)
        {
            try
            {
                _context.brands.Update(brand);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
