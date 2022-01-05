using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Context;
using KalaMarket.DataLayer.Entities.ProductEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service
{
    public class CategoryService : ICategoryService
    {
        private KalaMarketContext _context;
        public CategoryService(KalaMarketContext Context)
        {
            _context = Context;
        }
        public int AddCategory(Category category)
        {
            try
            {
                _context.categories.Add(category);
                _context.SaveChanges();
                return category.CategoryId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                _context.categories.Update(category);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Category FindCategoryById(int categoryId)
        {
            return _context.categories.Where(c => !c.IsDelete && c.CategoryId == categoryId).FirstOrDefault();
        }

        public List<Category> ShowAllCategory(int page)
        {
            int skip = (page - 1) * 2;
            return _context.categories.Where(c => !c.IsDelete && c.SubCategory == null).Skip(skip).Take(6).ToList();
        }

        public List<Category> ShowAllSubCategory(int categoryId, int page)
        {
            int skip = (page - 1) * 2;
            return _context.categories.Where(c => !c.IsDelete && c.SubCategory == categoryId).Skip(skip).Take(6).ToList();
        }

        public bool IsCategoryExists(string faTitle, string enTitle, int cateId)
        {
            return _context.categories.Any(c => c.CategoryFaTitle == faTitle && c.CategoryEnTitle == enTitle && c.CategoryId != cateId);
        }

        public List<Category> ShowSubCategory()
        {
            return _context.categories.Where(c => !c.IsDelete && c.SubCategory != null).ToList();
        }
        public bool DeleteCategory(int categoryId)
        {
            try
            {
                Category category = _context.categories.Find(categoryId);
                if (category.IsDelete == true)
                    return false;

                category.IsDelete = true;
                _context.Entry(category).State = EntityState.Modified;
                return Convert.ToBoolean(_context.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int CategoryCount()
        {
            int categoryCounts = _context.categories.Count();
            if (categoryCounts % 2 != 0)
                categoryCounts++;

            categoryCounts = categoryCounts / 2;
            return categoryCounts;
        }
        public List<Category> GetAllCategoryForMenu()
        {
            return _context.categories.Where(c => !c.IsDelete).ToList();
        }

    }
}
