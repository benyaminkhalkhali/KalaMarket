using KalaMarket.DataLayer.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service.IService
{
    public interface ICategoryService
    {
        List<Category> ShowAllCategory(int page);
        int AddCategory(Category category);
        bool UpdateCategory(Category category);
        List<Category> ShowAllSubCategory(int categoryId, int page);
        Category FindCategoryById(int categoryId);
        bool IsCategoryExists(string faTitle, string enTitle, int cateId);
        List<Category> ShowSubCategory();
        bool DeleteCategory(int categoryId);
        int CategoryCount();
        List<Category> GetAllCategoryForMenu();
    }
}
