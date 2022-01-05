using KalaMarket.Core.ExtensionMethod;
using KalaMarket.Core.Service.IService;
using KalaMarket.Core.ViewModel;
using KalaMarket.DataLayer.Context;
using KalaMarket.DataLayer.Entities.Address;
using KalaMarket.DataLayer.Entities.ProductEntities;
using KalaMarket.DataLayer.Entities.ProductEntities.FAQ;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service
{
    public class ProductService : IProductService
    {
        private KalaMarketContext _context;
        private IHostingEnvironment _hosting;
        public ProductService(KalaMarketContext Context, IHostingEnvironment hosting)
        {
            _context = Context;
            _hosting = hosting;
        }

        #region PropertyColors
        public int AddColor(ProductColor productColor)
        {
            try
            {
                _context.productColors.Add(productColor);
                _context.SaveChanges();
                return productColor.ColorId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int ColorCount()
        {
            int colorCounts = _context.productColors.Count();
            if (colorCounts % 2 != 0)
                colorCounts++;

            colorCounts = colorCounts / 2;
            return colorCounts;
        }

        public ProductColor FindColorById(int colorId)
        {
            return _context.productColors.Find(colorId);
        }

        public bool IsColorExists(string nameColor, string codeColor, int colorId)
        {
            return _context.productColors.Any(c => c.ColorName == nameColor && c.ColorCode == codeColor && c.ColorId != colorId);
        }

        public List<ProductColor> ShowAllColor()
        {
            return _context.productColors.Where(c => !c.IsDelete).ToList();
        }

        public bool UpdateColor(ProductColor productColor)
        {
            try
            {
                _context.productColors.Update(productColor);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteColor(int colorId)
        {
            try
            {
                ProductColor color = _context.productColors.Find(colorId);
                if (color.IsDelete == true)
                    return false;

                color.IsDelete = true;
                _context.Entry(color).State = EntityState.Modified;
                return Convert.ToBoolean(_context.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region PropertyNames
        public List<PropertyName> ShowAllProperties(int page)
        {
            int skip = (page - 1) * 2;
            return _context.propertyNames.Where(c => !c.IsDelete).Skip(skip).Take(6).ToList();
        }
        public int AddPropertyName(PropertyName propertyName)
        {
            try
            {
                _context.propertyNames.Add(propertyName);
                _context.SaveChanges();
                return propertyName.PropertyNameId;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool IsPropertyNameExists(string name, int id)
        {
            return _context.propertyNames.Any(p => p.PropertyTitle == name && p.PropertyNameId != id);
        }
        public bool AddPropertyForCategory(List<PropertyName_Category> categories)
        {
            try
            {
                _context.propertyName_Categories.AddRange(categories);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<UpdatePropertyNameVM> ShowPropertyNameForUpdate(int propertyNameId)
        {
            List<UpdatePropertyNameVM> updates = (from pc in _context.propertyName_Categories
                                                  join p in _context.propertyNames on pc.PropertyNameId equals p.PropertyNameId
                                                  where (pc.PropertyNameId == propertyNameId)
                                                  select new UpdatePropertyNameVM
                                                  {
                                                      pcId = pc.pcId,
                                                      CategoryId = pc.CategoryId,
                                                      PropertyNameId = p.PropertyNameId,
                                                      PropertyTitle = p.PropertyTitle
                                                  }).ToList();
            return updates;
        }
        public bool UpdatePropertyName(PropertyName propertyName)
        {
            try
            {
                _context.propertyNames.Update(propertyName);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeletePropertyForCategory(int propId)
        {
            try
            {
                List<PropertyName_Category> categories = _context.propertyName_Categories.Where(c => c.PropertyNameId == propId).ToList();
                _context.propertyName_Categories.RemoveRange(categories);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        public PropertyName FindPropById(int id)
        {
            return _context.propertyNames.Find(id);
        }
        public int PropertyCount()
        {
            int propertyCounts = _context.propertyNames.Count();
            if (propertyCounts % 2 != 0)
                propertyCounts++;

            propertyCounts = propertyCounts / 2;
            return propertyCounts;
        }
        public bool DeleteProperty(int propId)
        {
            try
            {
                PropertyName prop = _context.propertyNames.Find(propId);
                if (prop.IsDelete == true)
                    return false;

                prop.IsDelete = true;
                _context.Entry(prop).State = EntityState.Modified;
                return Convert.ToBoolean(_context.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Product
        public List<Product> ShowAllProduct(int page, string filterByName = "")
        {
            IQueryable<Product> result = _context.products.Where(c => !c.IsDelete);
            if (!string.IsNullOrEmpty(filterByName))
            {
                result = result.Where(c => c.ProductFaTitle.Contains(filterByName));
            }
            int skip = (page - 1) * 2;
            return _context.products.Where(p => !p.IsDelete).Skip(skip).Take(6).ToList();
        }
        public int AddProduct(Product product)
        {
            try
            {
                _context.products.Add(product);
                _context.SaveChanges();
                return product.ProductId;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public Product FindProductById(int productId)
        {
            return _context.products.Find(productId);
        }
        public bool UpdateProduct(Product product)
        {
            try
            {
                _context.products.Update(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int FindCategoryForProduct(int productId)
        {
            return _context.products.Where(p => p.ProductId == productId).Select(p => p.CategoryId).SingleOrDefault();
        }
        public List<PropertyName> ShowAllPropertyForCategory(int categoryId)
        {
            List<PropertyName> propertyName = (from pc in _context.propertyName_Categories
                                               join pn in _context.propertyNames on pc.PropertyNameId equals pn.PropertyNameId
                                               where (pc.CategoryId == categoryId)
                                               select new PropertyName
                                               {
                                                   PropertyNameId = pn.PropertyNameId,
                                                   PropertyTitle = pn.PropertyTitle
                                               }).ToList();
            return propertyName;
        }
        public bool AddOrUpdatePropertyNameForProduct(List<PropertyValue> propertyValues, int productId)
        {
            try
            {
                if (DeletePropertyValueForProduct(productId))
                {
                    _context.propertyValues.AddRange(propertyValues);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeletePropertyValueForProduct(int productId)
        {
            try
            {
                List<PropertyValue> propertyValues = _context.propertyValues.Where(p => p.ProductId == productId).ToList();
                _context.propertyValues.RemoveRange(propertyValues);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<PropertyValue> ShowPropertyValueForProduct(int productId)
        {
            return _context.propertyValues.Where(p => p.ProductId == productId).ToList();
        }
        public List<ShowPriceForProductVM> ShowAllPriceForProduct(int productId)
        {
            List<ShowPriceForProductVM> price = (from pr in _context.productPrices
                                                 join p in _context.products on pr.ProductId equals p.ProductId
                                                 join g in _context.productGuarantees on pr.ProductGuaranteeId equals g.GuaranteeId
                                                 join c in _context.productColors on pr.ColorId equals c.ColorId
                                                 where(pr.ProductId == productId && !pr.IsDelete)
                                                 select new ShowPriceForProductVM
                                                 {
                                                     ColorName = c.ColorName,
                                                     Count = pr.Count,
                                                     CreateDate = pr.CreateDate,
                                                     EndDateDiscount = pr.EndDateDiscount,
                                                     GuaranteeName = g.GuaranteeName,
                                                     MainPrice = pr.MainPrice,
                                                     MaxOrderCount = pr.MaxOrderCount,
                                                     ProductId = p.ProductId,
                                                     ProductPriceId = pr.ProductPriceId,
                                                     SpecialPrice = pr.SpecialPrice
                                                 }).ToList();
            return price;
        }
        public int AddPriceForProduct(ProductPrice productPrice)
        {
            try
            {
                _context.productPrices.Add(productPrice);
                _context.SaveChanges();
                return productPrice.ProductPriceId;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public ProductPrice FindPriceForProductById(int priceId)
        {
            return _context.productPrices.Find(priceId);
        }
        public List<SpecialProductVM> ShowAllSpecialProduct()
        {
            List<SpecialProductVM> specials = (from pr in _context.productPrices
                                               join p in _context.products on pr.ProductId equals p.ProductId
                                               where (pr.SpecialPrice < pr.MainPrice && pr.EndDateDiscount >= DateTime.Now.Date)
                                               select new SpecialProductVM
                                               {
                                                   EndSpecialPrice = pr.EndDateDiscount,
                                                   MainPrice = pr.MainPrice,
                                                   ProductFaTitle = p.ProductFaTitle,
                                                   ProductId = p.ProductId,
                                                   ProductImage = p.ProductImage,
                                                   SpecialPrice = pr.SpecialPrice,
                                                   ValuesList = (from pv in _context.propertyValues
                                                                 join pn in _context.propertyNames on pv.PropertyNameId equals pn.PropertyNameId
                                                                 where (pv.ProductId == pr.ProductId)
                                                                 select new ValueVM
                                                                 {
                                                                     PropName = pn.PropertyTitle,
                                                                     Value = pv.Propertyvalue
                                                                 }).Take(3).ToList()
                                               }).ToList();
            return specials;
        }
        public List<SliderForShowProductsInWebVM> ShowLatestProductForWeb()
        {
            List<SliderForShowProductsInWebVM> sliders = (from pr in _context.productPrices
                                                 join p in _context.products on pr.ProductId equals p.ProductId
                                                 select new SliderForShowProductsInWebVM
                                                 {
                                                     MainPrice = pr.MainPrice,
                                                     ProductFaTitle = p.ProductFaTitle,
                                                     ProductId = p.ProductId,
                                                     ProductSell = p.ProductSell,
                                                     ProductImage = p.ProductImage,
                                                     SpecialPrice = pr.EndDateDiscount >= DateTime.Now.Date && 
                                                     pr.SpecialPrice < pr.MainPrice ? pr.SpecialPrice : pr.MainPrice
                                                 }).OrderByDescending(c => c.ProductId).ToList();
            return sliders;
        }
        public List<SliderForShowProductsInWebVM> ShowBestSellerProductForWeb()
        {
            List<SliderForShowProductsInWebVM> sliders = (from pr in _context.productPrices
                                                          join p in _context.products on pr.ProductId equals p.ProductId
                                                          select new SliderForShowProductsInWebVM
                                                          {
                                                              MainPrice = pr.MainPrice,
                                                              ProductFaTitle = p.ProductFaTitle,
                                                              ProductId = p.ProductId,
                                                              ProductSell = p.ProductSell,
                                                              ProductImage = p.ProductImage,
                                                              SpecialPrice = pr.EndDateDiscount >= DateTime.Now.Date &&
                                                              pr.SpecialPrice < pr.MainPrice ? pr.SpecialPrice : pr.MainPrice
                                                          }).OrderByDescending(c => c.ProductSell).ToList();
            return sliders;
        }
        public List<ValueVM> ShowValueForProduct(int productId)
        {
            List<ValueVM> value = (from pv in _context.propertyValues
                                   join pn in _context.propertyNames on pv.PropertyNameId equals pn.PropertyNameId
                                   select new ValueVM 
                                   {
                                        PropName = pn.PropertyTitle,
                                        Value = pv.Propertyvalue
                                   }).Take(5).ToList();
            return value;
        }
        public List<ValueVM> ShowAllPropertyForProduct(int productId)
        {
            List<ValueVM> value = (from pv in _context.propertyValues
                                   join pn in _context.propertyNames on pv.PropertyNameId equals pn.PropertyNameId
                                   where (pv.ProductId == productId)
                                   select new ValueVM
                                   { 
                                        PropName = pn.PropertyTitle,
                                        Value = pv.Propertyvalue
                                   }).ToList();
            return value;
        }
        public List<CompareVM> ShowCompareProduct(List<int?> productId)
        {
            var compare = (from p in _context.products.Where(p => productId.Contains(p.ProductId))
                           join pr in _context.productPrices on p.ProductId equals pr.ProductId into pp
                           from pr in pp.DefaultIfEmpty()
                           select new CompareVM
                           {
                               CategoryId = p.CategoryId,
                               ProductFaTitle = p.ProductFaTitle,
                               ProductId = p.ProductId,
                               ProductImage = p.ProductImage,
                               ProductPrice = pr.MainPrice,
                               CompareVm = (from pn in _context.propertyNames
                                            join pv in _context.propertyValues on pn.PropertyNameId equals pv.PropertyNameId
                                             where (pv.ProductId == p.ProductId)
                                            select new PropertyProductCompareVM
                                            {
                                                ProductId = p.ProductId,
                                                PropertyName = pn.PropertyTitle,
                                                PropertyValue = pv.Propertyvalue,
                                            }).ToList()
                           }).ToList();
            return compare;
        }
        public List<PropertyProductCompareVM> ShowPropertyCompare(int categoryId)
        {
            var compare = (from pg in _context.propertyName_Categories
                           join pn in _context.propertyNames on pg.PropertyNameId equals pn.PropertyNameId
                           join pv in _context.propertyValues on pn.PropertyNameId equals pv.PropertyNameId
                           where (pg.CategoryId == categoryId)
                           select new PropertyProductCompareVM
                           {
                               ProductId = pv.ProductId,
                               PropertyName = pn.PropertyTitle,
                               PropertyNameId = pn.PropertyNameId,
                               PropertyValue = pv.Propertyvalue
                           }).ToList();
            return compare;
        }
        public List<GetProductForCompare> GetProductForCompare(int categoryId, List<int?> productId)
        {
            var product = (from p in _context.products
                           join c in _context.categories on p.CategoryId equals c.CategoryId
                           where (p.CategoryId == categoryId && !productId.Contains(p.ProductId))
                           select new GetProductForCompare 
                           {
                                CategoryId = c.CategoryId,
                                ProductFaTitle = p.ProductFaTitle,
                                ProductId = p.ProductId
                           }).ToList();
            return product;
        }
        public List<Product> SearchAllProduct(string text, List<int> categoryId, List<int> brandId,
            int minPrice = 0, int maxPrice = 0, int sort = 1)
        {
            IQueryable<Product> products = _context.products.Where
                (c => c.ProductFaTitle.Contains(text) || c.ProductEnTitle.Contains(text));

            switch (sort)
            {
                case 1:
                    products = products.OrderByDescending(c => c.ProductSell);
                    break;
                case 2:
                    products = products.OrderByDescending(c => c.ProductCreate);
                    break;
            }
            if (categoryId.Count > 0)
            {
                products = products.Where(c => categoryId.Contains(c.CategoryId));
            }
            if (brandId.Count > 0)
            {
                products = products.Where(c => brandId.Contains(c.BrandId));
            }
            var query = (from p in products
                         join pr in _context.productPrices on p.ProductId equals pr.ProductId
                         select new Product
                         {
                             ProductStar = p.ProductStar,
                             ProductImage = p.ProductImage,
                             ProductFaTitle = p.ProductFaTitle,
                             MainPrice = pr.MainPrice,
                             SpecialPrice = pr.SpecialPrice,
                             ProductId = p.ProductId
                         }).ToList();
            List<Product> productList = new List<Product>();
            foreach (var item in query)
            {
                productList.Add(new Product
                {
                    ProductStar = item.ProductStar,
                    ProductImage = item.ProductImage,
                    ProductFaTitle = item.ProductFaTitle,
                    MainPrice = query.Where(p => p.ProductId == item.ProductId)
                        .OrderBy(c => c.MainPrice).Select(c => c.MainPrice).FirstOrDefault(),
                    SpecialPrice = query.Where(p => p.ProductId == item.ProductId)
                        .OrderBy(c => c.SpecialPrice).Select(c => c.SpecialPrice).FirstOrDefault(),
                    ProductId = item.ProductId
                });
            }
            if (minPrice > 0)
            {
                productList = productList.Where(c => c.MainPrice >= minPrice && c.MainPrice > 0).ToList();
            }
            if (maxPrice > 0)
            {
                productList = productList.Where(c => c.MainPrice <= maxPrice && c.MainPrice > 0).ToList();
            }
            return productList;
        }

        public List<RandomProductVM> RandomProduct()
        {
            return (from p in _context.products
                    join pr in _context.productPrices on p.ProductId equals pr.ProductId
                    orderby Guid.NewGuid()
                    select new RandomProductVM
                    { 
                        MainPrice = (pr.SpecialPrice < pr.MainPrice && pr.EndDateDiscount >= DateTime.Now.Date)
                            ? pr.SpecialPrice : pr.MainPrice,
                        ProductFaTitle = p.ProductFaTitle,
                        ProductId = p.ProductId,
                        ProductImage = p.ProductImage
                    }).Take(3).ToList();
        }
        public DetailProductVM DetailProduct(int productId)
        {
            return (from p in _context.products
                    join b in _context.brands on p.BrandId equals b.BrandId
                    join c in _context.categories on p.CategoryId equals c.CategoryId
                    where (p.ProductId == productId)
                    select new DetailProductVM
                    { 
                        CategoryName = c.CategoryFaTitle,
                        ProductBrand = b.BrandName,
                        ProductEnTitle = p.ProductEnTitle,
                        ProductFaTitle = p.ProductFaTitle,
                        ProductId = p.ProductId,
                        ProductImage = p.ProductImage,
                        ProductSell = p.ProductSell,
                        ProductTag = p.ProductTag,
                        ProductStar = p.ProductStar
                    }).FirstOrDefault();
        }
        public List<ProductPriceVM> GetProductPrice(int productId)
        {
            return (from pr in _context.productPrices
                    join g in _context.productGuarantees on pr.ProductGuaranteeId equals g.GuaranteeId
                    join c in _context.productColors on pr.ColorId equals c.ColorId
                    where (pr.ProductId == productId && pr.Count > 0)
                    select new ProductPriceVM
                    {
                        ColorCode = c.ColorCode,
                        ColorName = c.ColorName,
                        Count = pr.Count,
                        EndDiscount = pr.EndDateDiscount,
                        GuaranteeName = g.GuaranteeName,
                        MainPrice = pr.MainPrice,
                        MaxOrderCount = pr.MaxOrderCount,
                        ProductPriceId = pr.ProductPriceId,
                        SpecialPrice = pr.SpecialPrice,
                    }).ToList();
        }
        public bool DeletePrice(int priceId)
        {
            try
            {
                ProductPrice price = _context.productPrices.Find(priceId);
                if (price.IsDelete == true)
                    return false;

                price.IsDelete = true;
                _context.Entry(price).State = EntityState.Modified;
                return Convert.ToBoolean(_context.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteProduct(int productId)
        {
            try
            {
                Product product = _context.products.Find(productId);
                if (product.IsDelete == true)
                    return false;

                product.IsDelete = true;
                _context.Entry(product).State = EntityState.Modified;
                return Convert.ToBoolean(_context.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int ProductCount()
        {
            int productCounts = _context.products.Count();
            if (productCounts % 2 != 0)
                productCounts++;

            productCounts = productCounts / 2;
            return productCounts;
        }
        #endregion

        #region Review
        public Review FindeReviewById(int productId)
        {
            return _context.reviews.Where(r => r.ProductId == productId).FirstOrDefault();
        }
        public bool AddOrUpdateReview(Review review)
        {
            try
            {
                _context.reviews.Add(review);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteReview(int productId)
        {
            try
            {
                Review review = _context.reviews.Where(r => r.ProductId == productId).FirstOrDefault();
                if (review != null)
                {
                    _context.reviews.Remove(review);
                    _context.SaveChanges();
                    return true;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region FAQ
        public List<ShowFaqVM> ShowAllFaq(int productId)
        {
            var question = _context.questions.Where(q => q.ProductId == productId);
            List<ShowFaqVM> showFaq = (from q in question
                                       join uq in _context.users on q.UserId equals uq.UserId

                                       join a in _context.answers on q.QuestionId equals a.QuestionId into qa
                                       from a in qa.DefaultIfEmpty()

                                       join ua in _context.users on a.UserId equals ua.UserId into u
                                       from ua in u.DefaultIfEmpty()
                                       select new ShowFaqVM 
                                       {
                                            CreateDateQ = q.CreateDate,
                                            DescriptionQ = q.QuestionDescription,
                                            QuestionId = q.QuestionId,
                                            UserNameQ = uq.FirstAndLastName,
                                            ShowAnswerVm = new ShowAnswerVM
                                            { 
                                                AnswerId = a.AnswerId,
                                                CreateDateA = a.CreateDate,
                                                DescriptionA = a.AnswerDescription,
                                                UserNameA = ua.FirstAndLastName
                                            }
                                       }).ToList();
            return showFaq;
        }
        public int AddQuestion(Question question)
        {
            try
            {
                _context.Add(question);
                _context.SaveChanges();
                return question.QuestionId;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int AddAnswer(Answer answer)
        {
            try
            {
                _context.Add(answer);
                _context.SaveChanges();
                return answer.AnswerId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion

        #region Favourite

        public Favourite FindFavouriteByUserId(int userId, int productId)
        {
            return _context.favourites.Where(f => f.UserId == userId && f.ProductId == productId).FirstOrDefault();
        }
        public bool AddFavourite(Favourite favourite)
        {
            try
            {
                _context.favourites.Add(favourite);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool RemoveFavourite(Favourite favourite)
        {
            try
            {
                _context.favourites.Remove(favourite);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Web

        public ProductInfosForShowInWebVM GetBestSellerProducts(int take)
        {
            
            ProductInfosForShowInWebVM product = new ProductInfosForShowInWebVM();
            product.products = _context.products.Include(c => c.productPrices).Include(c => c.category).Include(c => c.brand)
                .Select(p => new ProductInfosVM()
            { 
                CreateDate = p.ProductCreate,
                MainPrice = p.MainPrice,
                SpecialPrice = p.SpecialPrice,
                CategoryName = p.category.CategoryFaTitle,
                ProductBrand = p.brand.BrandName,
                ProductFaTitle = p.ProductFaTitle,
                ProductImage = p.ProductImage,
                ProductSell = p.ProductSell,
                ProductTag = p.ProductTag,
                ProductStar = p.ProductStar,
                ProductId = p.ProductId
            }).OrderByDescending(c => c.ProductSell).ToList();

            return product;
        }
        public ProductInfosForShowInWebVM GetLatestProducts(int take)
        {

            ProductInfosForShowInWebVM product = new ProductInfosForShowInWebVM();
            product.products = _context.products.Include(c => c.productPrices).Include(c => c.category).Include(c => c.brand)
                .Select(p => new ProductInfosVM()
                {
                    CreateDate = p.ProductCreate,
                    MainPrice = p.MainPrice,
                    SpecialPrice = p.SpecialPrice,
                    CategoryName = p.category.CategoryFaTitle,
                    ProductBrand = p.brand.BrandName,
                    ProductFaTitle = p.ProductFaTitle,
                    ProductImage = p.ProductImage,
                    ProductSell = p.ProductSell,
                    ProductTag = p.ProductTag,
                    ProductStar = p.ProductStar,
                    ProductId = p.ProductId
                }).OrderByDescending(c => c.ProductId).ToList();

            return product;
        }

        #endregion

        #region Comment

        public int AddComment(Comment comment)
        {
            _context.comments.Add(comment);
            _context.SaveChanges();
            return comment.CommentId;
        }
        public List<Comment> GetProductComment(int productId)
        {
            return _context.comments.Include(c => c.user).Where(c => c.ProductId == productId && !c.IsDelete && !c.IsActive)
                .OrderByDescending(c => c.CommentId).ToList();
        }
        public CommentListInAdminVM GetAllCommentsInAdmin(bool? isActive, int take = 10, int pageId = 1)
        {
            CommentListInAdminVM list = new CommentListInAdminVM();
            if (isActive == null)
            {
                list.Comments = _context.comments.Include(c => c.user).Include(c => c.product)
                    .Where(c => !c.IsDelete).OrderByDescending(c => c.CommentId).ToList();
            }
            else
            {
                list.Comments = _context.comments.Include(c => c.user).Include(c => c.product)
                    .Where(c => !c.IsDelete && c.IsActive == isActive).OrderByDescending(c => c.CommentId).ToList();
            }
            list.Count = list.Comments.Count;
            int skip = (pageId - 1) * take;
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling(list.Count / (double)take);
            list.Comments = list.Comments.Skip(skip).Take(take).ToList();
            return list;
        }
        public Comment GetCommentById(int commentId)
        {
            return _context.comments.Include(c => c.product).Include(c => c.user)
                .Where(c => c.CommentId == commentId).FirstOrDefault();
        }
        public bool OkComment(int commentId)
        {
            Comment comment = _context.comments.Find(commentId);
            if (comment == null)
                return false;
            if (comment.IsActive == true)
                return false;

            comment.IsActive = true;
            _context.Entry(comment).State = EntityState.Modified;
            return Convert.ToBoolean(_context.SaveChanges());
        }
        public bool NotOkComment(int commentId)
        {
            Comment comment = _context.comments.Find(commentId);
            if (comment == null)
                return false;
            if (comment.IsActive == false)
                return false;

            comment.IsActive = false;
            _context.Entry(comment).State = EntityState.Modified;
            return Convert.ToBoolean(_context.SaveChanges());
        }
        public bool DeleteComment(int commentId)
        {
            Comment comment = _context.comments.Find(commentId);
            if (comment == null)
                return false;
            if (comment.IsDelete == true)
                return false;

            comment.IsDelete = true;
            _context.Entry(comment).State = EntityState.Modified;
            return Convert.ToBoolean(_context.SaveChanges());
        }
        public bool RestoreComment(int commentId)
        {
            Comment comment = _context.comments.Find(commentId);
            if (comment == null)
                return false;
            if (comment.IsDelete == false)
                return false;

            comment.IsDelete = false;
            _context.Entry(comment).State = EntityState.Modified;
            return Convert.ToBoolean(_context.SaveChanges());
        }
        public CommentListInAdminVM GetAllDeletedComments(bool? isActive, int take = 10, int pageId = 1)
        {
            CommentListInAdminVM list = new CommentListInAdminVM();
            if (isActive == null)
            {
                list.Comments = _context.comments.Include(c => c.user).Include(c => c.product)
                    .Where(c => c.IsDelete == true).OrderByDescending(c => c.CommentId).ToList();
            }
            else
            {
                list.Comments = _context.comments.Include(c => c.user).Include(c => c.product)
                    .Where(c => c.IsDelete == true && c.IsActive == isActive).OrderByDescending(c => c.CommentId).ToList();
            }
            list.Count = list.Comments.Count;
            int skip = (pageId - 1) * take;
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling(list.Count / (double)take);
            list.Comments = list.Comments.Skip(skip).Take(take).ToList();
            return list;
        }

        #endregion

        #region Gallery

        public List<ProductGallery> ShowGalleryForProduct(int productId)
        {
            return _context.productGalleries.Where(p => p.IsActive && p.ProductId == productId).ToList();
        }
        public List<ProductGallery> ShowAllGallery(int productId)
        {
            return _context.productGalleries.Include(p => p.product).Where(c => !c.IsDelete && c.ProductId == productId).ToList();
        }
        public int AddGallery(ProductGallery gallery)
        {
            try
            {
                _context.productGalleries.Add(gallery);
                _context.SaveChanges();
                return gallery.GalleryId;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool UpdateGallery(ProductGallery gallery)
        {
            try
            {
                _context.productGalleries.Update(gallery);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteGallery(int galleryId)
        {
            try
            {
                ProductGallery gallery = _context.productGalleries.Find(galleryId);
                if (gallery.IsDelete == true)
                    return false;

                gallery.IsDelete = true;
                _context.Entry(gallery).State = EntityState.Modified;
                return Convert.ToBoolean(_context.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }
        public ProductGallery FindGalleryById(int galleryId)
        {
            return _context.productGalleries.Find(galleryId);
        }

        #endregion

    }
}
