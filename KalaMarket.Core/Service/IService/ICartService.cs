using KalaMarket.Core.ViewModel;
using KalaMarket.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service.IService
{
    public interface ICartService
    {
        int AddCart(int userId, int productId, int ordercount);
        List<CartVM> CartDetail(int userId);
        int ChangeBasket(int userId, int productId, int count);
        Cart FindCartByUserId(int userId);
        Cart FindCartById(int cartId);
        void RemoveProductForBasket(int productpriceid, int cartId);
        void SumPrice(int cartId, int detailId);
        void MinusPrice(int cartId, int detailId);
        void UpdateCart(Cart cart);
        List<HighChartVM> HighChart();
        List<ShowBasketVM> ShowAllProductForBasket(int userId);
        List<ShowPostedVM> ShowPosteds(int page, string filterByEmail = "");
        List<DetailPostedVM> DetailPosteds(int cartId, int page, string filterByRefId = "");
        void Accepts(int cartId);
        void UpdateSell(int cartId);
    }
}
