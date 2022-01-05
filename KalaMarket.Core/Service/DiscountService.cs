using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Context;
using KalaMarket.DataLayer.Entities.Discount;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service
{
    public class DiscountService : IDiscountService
    {
        private KalaMarketContext _context;
        private ICartService _cartService;
        public DiscountService(KalaMarketContext context, ICartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }
        public int CheckDiscount(int cartId, string discountCode)
        {
            var discount = _context.discounts.FirstOrDefault(c => c.DiscountCode == discountCode);
            if (discount == null)
                return 1; //کد تخفیف وارد شده نامعتبر می باشد

            if (discount.StartDate != null && discount.StartDate > DateTime.Now.Date)
                return 2; // تاریخ کدتخفیف به پایان رسیده است

            if (discount.EndDate != null && discount.EndDate < DateTime.Now.Date)
                return 3; //تاریخ کدتخفیف به پایان رسیده است

            if (discount.UsableCount != null && discount.UsableCount <= 0)
                return 4;// تعداد کدتخفیف به پایان رسیده است

            var cart = _context.carts.Find(cartId);
            if (_context.userDiscounts.Any(c => c.UserId == cart.UserId && c.DiscountId == discount.DiscountId))
                return 5;// شما قبلا این کدتخفیف را استفاده کرده اید

            int percent = (cart.TotalPrice * discount.DiscountPercent) / 100;
            cart.TotalPrice = cart.TotalPrice - percent;
            _cartService.UpdateCart(cart);

            if (discount.UsableCount != null)
                discount.UsableCount -= 1;

            _context.Update(discount);
            _context.userDiscounts.Add(new DataLayer.Entities.Discount.UserDiscount
            { 
                DiscountId = discount.DiscountId,
                UserId = cart.UserId
            });
            _context.SaveChanges();
            return 6; // کدتخفیف با موفقیت اعمال شد
        }

        public int AddDiscounts(Discount discount)
        {
            try
            {
                _context.discounts.Add(discount);
                _context.SaveChanges();
                return discount.DiscountId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool UpdateDiscounts(Discount discount)
        {
            try
            {
                _context.discounts.Update(discount);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public List<Discount> ShowAllDiscounts(int page)
        {
            int skip = (page - 1) * 2;
            return _context.discounts.Where(c => !c.IsDelete).Skip(skip).Take(6).ToList();
        }

        public Discount FindDiscountById(int discountId)
        {
            return _context.discounts.Find(discountId);
        }

        public bool DeleteDiscount(int discountId)
        {
            try
            {
                Discount discount = _context.discounts.Find(discountId);
                if (discount.IsDelete == true)
                    return false;

                discount.IsDelete = true;
                _context.Entry(discount).State = EntityState.Modified;
                return Convert.ToBoolean(_context.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int DiscountCount()
        {
            int discountCounts = _context.discounts.Count();
            if (discountCounts % 2 != 0)
                discountCounts++;

            discountCounts = discountCounts / 2;
            return discountCounts;
        }
    }
}
