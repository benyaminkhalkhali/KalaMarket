using KalaMarket.DataLayer.Entities;
using KalaMarket.DataLayer.Entities.ProductEntities;
using KalaMarket.DataLayer.Entities.ProductEntities.FAQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service.IService
{
    public interface ISiteSettingService
    {
        int GetCountOfUsers();
        int GetCountOfProducts();
        int GetIncomeIn30DaysAgo();
        int GetAllIncome();
        int GetCountOfOrders();
        int GetCountOfDeliveries();
        List<Cart> GetNotConfirmOrders(int take = 5);
        List<Comment> GetNotConfirmedComments(int take = 5);
        List<Product> GetBestSellerProducts(int take = 5);
    }
}
