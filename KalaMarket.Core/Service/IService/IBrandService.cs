using KalaMarket.DataLayer.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service.IService
{
    public interface IBrandService
    {
        List<Brand> ShowAllBrands();
        Brand FindBrandById(int id);
        bool UpdateBrand(Brand brand);
        bool DeleteBrand(Brand brand);
        bool IsBrandExists(string brandName, int brandId);
        int AddBrand(Brand brand);
    }
}
