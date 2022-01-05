using KalaMarket.Core.ExtensionMethod;
using KalaMarket.Core.Service.IService;
using KalaMarket.Core.ViewModel;
using KalaMarket.DataLayer.Context;
using KalaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service
{
    public class CartService : ICartService
    {
        private KalaMarketContext _context;
        public CartService(KalaMarketContext context)
        {
            _context = context;
        }
        public int AddCart(int userId, int productId, int ordercount)
        {
            Cart cart = _context.carts.SingleOrDefault(c => !c.IsPaid && c.UserId == userId);
            var product = _context.productPrices.FirstOrDefault(c => c.ProductPriceId == productId);
            if (cart == null)
            {
                cart = new Cart
                {
                    CreateDate = DateTime.Now.Date,
                    IsPaid = false,
                    RefId = "",
                    UserId = userId,
                    TotalPrice = product.SpecialPrice < product.MainPrice &&
                        Convert.ToDateTime(product.EndDateDiscount).Date >= DateTime.Now.Date ? (product.SpecialPrice.Value * ordercount) : (product.MainPrice * ordercount),
                    cartDetails = new List<CartDetail>
                    {
                        new CartDetail
                        {
                            OrderCount = ordercount,
                            CreateDate = DateTime.Now.Date,
                            Product_PriceID = product.ProductPriceId,
                            Product_ID = product.ProductId,
                            Price = (product.SpecialPrice < product.MainPrice &&
                                Convert.ToDateTime(product.EndDateDiscount).Date >= DateTime.Now.Date) ? product.SpecialPrice.Value : product.MainPrice
                        }
                    }
                };
                _context.Add(cart);
                _context.SaveChanges();
                return 2;
            }
            else
            {
                CartDetail cartDetail = _context.cartDetails.
                    FirstOrDefault(c => c.CartId == cart.CartId && c.Product_PriceID == productId);
                if (cartDetail != null  && (cartDetail.OrderCount + ordercount) <= product.MaxOrderCount)
                {
                    MinusPrice(cartDetail.CartId, cartDetail.CartDetailId);
                    _context.cartDetails.Update(cartDetail);
                    SumPrice(cartDetail.CartId, cartDetail.CartDetailId);
                    return 2;
                }
                else if (cartDetail == null)
                {
                    cartDetail = new CartDetail
                    {
                        CartId = cart.CartId,
                        OrderCount = ordercount,
                        CreateDate = DateTime.Now.Date,
                        Price = (product.SpecialPrice < product.MainPrice &&
                                Convert.ToDateTime(product.EndDateDiscount).Date >= DateTime.Now.Date) ? product.SpecialPrice.Value : product.MainPrice,
                        Product_PriceID = product.ProductPriceId,
                        Product_ID = product.ProductId
                    };
                    _context.Add(cartDetail);
                    _context.SaveChanges();
                    SumPrice(cartDetail.CartId, cartDetail.CartDetailId);
                    return 2;
                }
            }
            return 3;
        }
        public int ChangeBasket(int userId, int productId, int count)
        {
            Cart cart = _context.carts.SingleOrDefault(c => !c.IsPaid && c.UserId == userId);
            var product = _context.productPrices.FirstOrDefault(c => c.ProductPriceId == productId);
            if (cart == null)
            {
                cart = new Cart
                {
                    CreateDate = DateTime.Now.Date,
                    IsPaid = false,
                    RefId = "",
                    UserId = userId,
                    TotalPrice = product.SpecialPrice < product.MainPrice &&
                        Convert.ToDateTime(product.EndDateDiscount).Date >= DateTime.Now.Date ? product.SpecialPrice.Value : product.MainPrice,
                    cartDetails = new List<CartDetail>
                    {
                        new CartDetail
                        {
                            OrderCount = count,
                            CreateDate = DateTime.Now.Date,
                            Product_PriceID = product.ProductPriceId,
                            Product_ID = product.ProductId,
                            Price = product.SpecialPrice < product.MainPrice &&
                                Convert.ToDateTime(product.EndDateDiscount).Date < DateTime.Now.Date ? product.SpecialPrice.Value : product.MainPrice
                        }
                    }
                };
                _context.Add(cart);
                _context.SaveChanges();
                return 2;
            }
            else
            {
                CartDetail cartDetail = _context.cartDetails.FirstOrDefault(c => c.CartId == cart.CartId);
                if (cartDetail != null && cartDetail.OrderCount <= product.MaxOrderCount)
                {
                    MinusPrice(cartDetail.CartId, cartDetail.CartDetailId);
                    cartDetail.OrderCount = count;
                    _context.cartDetails.Update(cartDetail);
                    SumPrice(cartDetail.CartId, cartDetail.CartDetailId);
                    return 2;
                }
                else if (cartDetail == null)
                {
                    cartDetail = new CartDetail
                    {
                        CartId = cart.CartId,
                        OrderCount = count,
                        CreateDate = DateTime.Now.Date,
                        Price = product.SpecialPrice < product.MainPrice &&
                                Convert.ToDateTime(product.EndDateDiscount).Date < DateTime.Now.Date ? product.SpecialPrice.Value : product.MainPrice,
                        Product_PriceID = product.ProductPriceId,
                        Product_ID = product.ProductId
                    };
                    _context.Add(cartDetail);
                    _context.SaveChanges();
                    SumPrice(cartDetail.CartId, cartDetail.CartDetailId);
                    return 2;
                }
            }
            return 3;
        }
        public List<CartVM> CartDetail(int userId)
        {
            List<CartVM> cart = (from c in _context.carts
                                 join cd in _context.cartDetails on c.CartId equals cd.CartId
                                 join pr in _context.productPrices on cd.Product_PriceID equals pr.ProductPriceId
                                 join p in _context.products on pr.ProductId equals p.ProductId
                                 join color in _context.productColors on pr.ColorId equals color.ColorId
                                 join g in _context.productGuarantees on pr.ProductGuaranteeId equals g.GuaranteeId
                                 where (c.UserId == userId && !c.IsPaid)
                                 select new CartVM
                                 { 
                                    ColorName = color.ColorName,
                                    GuaranteeName = g.GuaranteeName,
                                    OrderCount = cd.OrderCount,
                                    ProductFaTitle = p.ProductFaTitle,
                                    ProductId = p.ProductId,
                                    ProductPrice = cd.Price,
                                    ProductPriceId = pr.ProductPriceId,
                                    ProductImage = p.ProductImage,
                                    TotalPrice = c.TotalPrice,
                                    MaxOrderCount = pr.MaxOrderCount,
                                    ProductCount = pr.Count,
                                    CartId = cd.CartId,
                                    ColorCode = color.ColorCode
                                 }).ToList();
            return cart;
        }
        public void RemoveProductForBasket(int productpriceid, int cartId)
        {
            var basket = _context.cartDetails.Where(c => c.Product_PriceID == productpriceid && c.CartId == cartId).FirstOrDefault();
            MinusPrice(basket.CartId, basket.CartDetailId);
            _context.Remove(basket);
            _context.SaveChanges();
        }
        public void SumPrice(int cartId, int detailId)
        {
            var cart = _context.carts.Find(cartId);
            var detail = _context.cartDetails.Where(c => c.CartId == cartId && c.CartDetailId == detailId).FirstOrDefault();
            cart.TotalPrice += detail.OrderCount * detail.Price;
            _context.Update(cart);
            _context.SaveChanges();
        }
        public void MinusPrice(int cartId, int detailId)
        {
            var cart = _context.carts.Find(cartId);
            var detail = _context.cartDetails.Where(c => c.CartId == cartId && c.CartDetailId == detailId).FirstOrDefault();
            cart.TotalPrice -= detail.OrderCount * detail.Price;
            _context.Update(cart);
            _context.SaveChanges();
        }
        public void UpdateCart(Cart cart)
        {
            _context.Update(cart);
            _context.SaveChanges();
        }
        public Cart FindCartByUserId(int userId)
        {
            return _context.carts.Where(c => !c.IsPaid && c.UserId == userId).FirstOrDefault();
        }
        public Cart FindCartById(int cartId)
        {
            return _context.carts.Find(cartId);
        }
        public List<HighChartVM> HighChart()
        {
            var chart = _context.carts.Where(c => c.IsPaid).GroupBy(c => c.CreateDate.Date).OrderByDescending(c => c.Key).Take(7).Select(c => new HighChartVM
            {
                name = c.Key.ToShamsi(),
                y = c.Count()
            }).ToList();
            return chart.OrderBy(c => c.name).ToList();
        }
        public List<ShowBasketVM> ShowAllProductForBasket(int userId)
        {
            return(from c in _context.carts
                     where (c.UserId == userId && !c.IsPaid)
                     join cd in _context.cartDetails on c.CartId equals cd.CartId
                     join pr in _context.productPrices on cd.Product_PriceID equals pr.ProductPriceId
                     join p in _context.products on pr.ProductId equals p.ProductId
                     select new ShowBasketVM
                     {
                        MainPrice = (pr.MainPrice > pr.SpecialPrice && pr.EndDateDiscount >= DateTime.Now.Date)
                            ? pr.SpecialPrice : pr.MainPrice,

                        ProductFaTitle = p.ProductFaTitle,
                        ProductId = p.ProductId,
                        ProductImage = p.ProductImage,
                        TotalBasket = c.TotalPrice
                     
                     }).ToList();
        }
        public List<ShowPostedVM> ShowPosteds(int page, string filterByEmail = "")
        {
            IQueryable<User> result = _context.users.Where(c => !c.IsDelete);
            if (!string.IsNullOrEmpty(filterByEmail))
            {
                result = result.Where(c => c.Email.Contains(filterByEmail));
            }
            int skip = (page - 1) * 2;
            return _context.carts.Where(x => !x.Posted)
                .Include(c => c.user).Select(x => new ShowPostedVM 
                {
                    CartId = x.CartId,
                    DateTime = x.CreateDate,
                    Email = x.user.Email,
                    TotalPrice = x.TotalPrice
                }).Skip(skip).Take(6).ToList();

        }
        public List<DetailPostedVM> DetailPosteds(int cartId, int page, string filterByRefId = "")
        {
            IQueryable<Cart> result = _context.carts;
            if (!string.IsNullOrEmpty(filterByRefId))
            {
                result = result.Where(c => c.RefId.Contains(filterByRefId));
            }
            int skip = (page - 1) * 2;
            var detail = (from ct in _context.carts
                          join cd in _context.cartDetails on ct.CartId equals cd.CartId
                          join pr in _context.productPrices on cd.Product_PriceID equals pr.ProductPriceId
                          join p in _context.products on pr.ProductId equals p.ProductId
                          join c in _context.productColors on pr.ColorId equals c.ColorId
                          join g in _context.productGuarantees on pr.ProductGuaranteeId equals g.GuaranteeId
                          join u in _context.users on ct.UserId equals u.UserId
                          join ua in _context.userAddresses on u.UserId equals ua.UserId
                          where (ct.CartId == cartId && (!ua.IsDelete && ua.UserId == ct.UserId))
                          select new DetailPostedVM
                          {
                            Address = ua.Province + "-" + ua.City + "-" + ua.FullAddress,
                            ColorName = c.ColorName,
                            GuaranteeName = g.GuaranteeName,
                            ProductId = p.ProductId,
                            ProductImage = p.ProductImage,
                            ProductName = p.ProductFaTitle,
                            ProductPrice = cd.Price,
                            RecipientName = u.FirstAndLastName,
                            RefId = ct.RefId,
                            IsPaid = ct.IsPaid,
                          }).Skip(skip).Take(6).ToList();
            return detail;
        }
        public void Accepts(int cartId)
        {
            var cart = _context.carts.Find(cartId);
            cart.Posted = true;
            _context.SaveChanges();
        }
        public bool IsAddressExists(int userId)
        {
            return _context.userAddresses.Any(x => x.UserId == userId && !x.IsDelete);
        }
        public void UpdateSell(int cartId)
        {
            List<int> productId = new();

            var cartDetail = _context.cartDetails.Where(c => c.CartId == cartId).ToList();
            foreach (var item in cartDetail)
                productId.Add(item.Product_ID);

            var products = _context.products.Where(x => productId.Contains(x.ProductId));
            foreach (var item in products)
            {
                var c = cartDetail.Where(x => x.Product_ID == item.ProductId);
                foreach (var item2 in c)
                    item.ProductSell += item2.OrderCount;

                _context.UpdateRange(products);
            }
            _context.SaveChanges();
        }
    }
}
