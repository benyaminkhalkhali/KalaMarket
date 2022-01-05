using KalaMarket.DataLayer.Entities.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service.IService
{
    public interface IDiscountService
    {
        int CheckDiscount(int cartId, string discountCode);
        public int AddDiscounts(Discount discount);
        public bool UpdateDiscounts(Discount discount);
        public List<Discount> ShowAllDiscounts(int page);
        public Discount FindDiscountById(int discountId);
        bool DeleteDiscount(int discountId);
        int DiscountCount();
    }
}
