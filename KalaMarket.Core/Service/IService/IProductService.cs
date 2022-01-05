using KalaMarket.Core.ViewModel;
using KalaMarket.DataLayer.Entities.Address;
using KalaMarket.DataLayer.Entities.ProductEntities;
using KalaMarket.DataLayer.Entities.ProductEntities.FAQ;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service.IService
{
    public interface IProductService
    {
        #region ProductColor
        List<ProductColor> ShowAllColor();
        int AddColor(ProductColor productColor);
        bool UpdateColor(ProductColor productColor);
        ProductColor FindColorById(int colorId);
        bool IsColorExists(string nameColor, string codeColor, int colorId);
        int ColorCount();
        bool DeleteColor(int colorId);
        #endregion

        #region PropertyNames
        List<PropertyName> ShowAllProperties(int page);
        int AddPropertyName(PropertyName propertyName);
        bool IsPropertyNameExists(string name, int id);
        bool AddPropertyForCategory(List<PropertyName_Category> categories);
        List<UpdatePropertyNameVM> ShowPropertyNameForUpdate(int propertyNameId);
        bool UpdatePropertyName(PropertyName propertyName);
        bool DeletePropertyForCategory(int propId);
        PropertyName FindPropById(int id);
        int PropertyCount();
        bool DeleteProperty(int propId);
        #endregion

        #region Products
        List<Product> ShowAllProduct(int page, string filterByName = "");
        int AddProduct(Product product);
        Product FindProductById(int productId);
        bool UpdateProduct(Product product);
        int FindCategoryForProduct(int productId);
        List<PropertyName> ShowAllPropertyForCategory(int categoryId);
        bool AddOrUpdatePropertyNameForProduct(List<PropertyValue> propertyValues, int productId);
        bool DeletePropertyValueForProduct(int productId);
        List<PropertyValue> ShowPropertyValueForProduct(int productId);
        List<ShowPriceForProductVM> ShowAllPriceForProduct(int productId);
        int AddPriceForProduct(ProductPrice productPrice);
        List<SpecialProductVM> ShowAllSpecialProduct();
        //List<SliderForCategoryVM> ShowProductForCategory(int categoryId);
        List<SliderForShowProductsInWebVM> ShowLatestProductForWeb();
        public List<SliderForShowProductsInWebVM> ShowBestSellerProductForWeb();
        /*List<ShowDetailsProductVM> ShowDetailsProduct(int productId);*/
        List<ValueVM> ShowValueForProduct(int productId);
        List<ValueVM> ShowAllPropertyForProduct(int productId);
        List<CompareVM> ShowCompareProduct(List<int?> productId);
        List<PropertyProductCompareVM> ShowPropertyCompare(int categoryId);
        List<GetProductForCompare> GetProductForCompare(int categoryId, List<int?> productId);
        List<Product> SearchAllProduct(string text, List<int> categoryId, List<int> brandId,
            int minPrice = 0, int maxPrice = 0, int sort = 1);
        List<RandomProductVM> RandomProduct();
        List<ProductPriceVM> GetProductPrice(int productId);
        DetailProductVM DetailProduct(int productId);
        ProductPrice FindPriceForProductById(int priceId);
        bool DeletePrice(int priceId); 
        bool DeleteProduct(int productId);
        int ProductCount();
        #endregion

        #region Review
        Review FindeReviewById(int productId);
        public bool AddOrUpdateReview(Review review);
        public bool DeleteReview(int productId);

        #endregion

        #region FAQ
        List<ShowFaqVM> ShowAllFaq(int productId);
        int AddQuestion(Question question);
        int AddAnswer(Answer answer);

        #endregion

        #region Favourite
        Favourite FindFavouriteByUserId(int userId, int productId);
        bool AddFavourite(Favourite favourite);
        bool RemoveFavourite(Favourite favourite);
        #endregion

        #region Web

        ProductInfosForShowInWebVM GetBestSellerProducts(int take);
        ProductInfosForShowInWebVM GetLatestProducts(int take);


        #endregion

        #region Detail


        #endregion

        #region Comment

        int AddComment(Comment comment);
        List<Comment> GetProductComment(int productId);
        CommentListInAdminVM GetAllCommentsInAdmin(bool? isActive, int take = 10, int pageId = 1);
        Comment GetCommentById(int commentId);
        bool OkComment(int commentId);
        bool NotOkComment(int commentId);
        bool DeleteComment(int commentId);
        bool RestoreComment(int commentId);
        CommentListInAdminVM GetAllDeletedComments(bool? isActive, int take = 10, int pageId = 1);

        #endregion

        #region Gallery

        List<ProductGallery> ShowGalleryForProduct(int productId);
        List<ProductGallery> ShowAllGallery(int productId);
        int AddGallery(ProductGallery gallery);
        bool UpdateGallery(ProductGallery gallery);
        bool DeleteGallery(int galleryId);
        ProductGallery FindGalleryById(int galleryId);
        #endregion

    }
}
