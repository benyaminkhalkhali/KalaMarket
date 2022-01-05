using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Context;
using KalaMarket.DataLayer.Entities;
using KalaMarket.DataLayer.Entities.ProductEntities;
using KalaMarket.DataLayer.Entities.ProductEntities.FAQ;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service
{
    public class SiteSettingService : ISiteSettingService
    {
        private KalaMarketContext _context;
        public SiteSettingService(KalaMarketContext context)
        {
            _context = context;
        }

        public int GetCountOfUsers()
        {
            return _context.users.Where(c => !c.IsDelete).Count();
        }
        public int GetCountOfProducts()
        {
            return _context.products.Where(c => !c.IsDelete).Count();
        }
        public int GetIncomeIn30DaysAgo()
        {
            return _context.carts.Where(c => c.CreateDate > DateTime.Now.AddDays(-30) && c.IsPaid == true).Sum(c => c.TotalPrice);
        }
        public int GetAllIncome()
        {
            return _context.carts.Where(c => c.IsPaid == true).Sum(c => c.TotalPrice);
        }
        public int GetCountOfOrders()
        {
            return _context.carts.Where(c => c.IsPaid == true).Count();
        }
        public int GetCountOfDeliveries()
        {
            return _context.carts.Where(c => c.Posted == true).Count();
        }
        public List<Product> GetBestSellerProducts(int take = 5)
        {
            return _context.products.Where(c => !c.IsDelete).OrderByDescending(c => c.ProductSell).Take(take).ToList();
        }
        public List<Cart> GetNotConfirmOrders(int take = 5)
        {
            return _context.carts.Include(c => c.cartDetails).Include(c => c.address)
                .Where(c => !c.Posted).OrderByDescending(c => c.CartId).ToList();
        }
        public List<Comment> GetNotConfirmedComments(int take = 5)
        {
            return _context.comments.Include(c => c.product).Include(c => c.user)
                .Where(c => !c.IsActive && !c.IsDelete).OrderByDescending(c => c.CommentId).ToList();
        }

    }
}
