using KalaMarket.Core.ExtensionMethod;
using KalaMarket.Core.Security;
using KalaMarket.Core.Service.IService;
using KalaMarket.Core.ViewModel;
using KalaMarket.DataLayer.Entities.ProductEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalaMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    [MyAuthorize("Admin")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private IBrandService _brandService;
        private IGuaranteeService _guarenteeService;
        private ICartService _cartService;
        public ProductController(IProductService productService, ICategoryService categoryService,
            IBrandService brandService, IGuaranteeService guaranteeService, ICartService cartService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
            _guarenteeService = guaranteeService;
            _cartService = cartService;
        }

        #region PropertyColor
        public IActionResult ShowAllColors()
        {
            return View(_productService.ShowAllColor());
        }

        [HttpGet]
        public IActionResult AddColors()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddColors(ProductColor productColor)
        {
            if (!ModelState.IsValid)
                return View(productColor);
            if (_productService.IsColorExists(productColor.ColorName, productColor.ColorCode, 0))
            {
                ModelState.AddModelError("ErrorColor", "رنگ انتخابی تکراری است");
                return View(productColor);
            }
            int colorid = _productService.AddColor(productColor);
            TempData["Result"] = colorid > 0 ? "true" : "false";
            return RedirectToAction(nameof(ShowAllColors));
        }

        [HttpGet]
        public IActionResult UpdateColors(int id)
        {
            ProductColor productColor = _productService.FindColorById(id);
            if (productColor == null)
            {
                TempData["NotFoundColor"] = "true";
                return RedirectToAction(nameof(ShowAllColors));
            }
            else
            {
                return View(productColor);
            }
        }

        [HttpPost]
        public IActionResult UpdateColors(ProductColor productColor)
        {
            if (!ModelState.IsValid)
                return View(productColor);

            if (_productService.IsColorExists(productColor.ColorName, productColor.ColorCode, productColor.ColorId))
            {
                ModelState.AddModelError("ErrorColor", "رنگ انتخابی تکراری است");
                return View(productColor);
            }
            bool res = _productService.UpdateColor(productColor);
            TempData["Result"] = res ? "true" : "false";
            return RedirectToAction(nameof(ShowAllColors));
        }


        #endregion

        #region ProprtyName
        public IActionResult ShowAllPropertyNames(int page = 1)
        {
            ViewBag.page = page;
            ViewBag.CountProperty = _productService.PropertyCount();
            return View(_productService.ShowAllProperties(page));
        }

        [HttpGet]
        public IActionResult AddPropertyNames()
        {
            ViewBag.category = _categoryService.ShowSubCategory();
            return View();
        }

        [HttpPost]
        public IActionResult AddPropertyNames(PropertyName propertyName, List<int> Categoryid)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.category = _categoryService.ShowSubCategory();
                return View(propertyName);
            }
            if (_productService.IsPropertyNameExists(propertyName.PropertyTitle, 0))
            {
                ModelState.AddModelError("PropertyTitle", "خصوصیات تکراری است");
            }
            int nameid = _productService.AddPropertyName(propertyName);
            if (nameid <= 0)
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllPropertyNames));
            }
            List<PropertyName_Category> Addpc = new List<PropertyName_Category>();
            foreach (var item in Categoryid)
            {
                Addpc.Add(new PropertyName_Category
                {
                    CategoryId = item,
                    PropertyNameId = nameid
                });
            }
            bool res = _productService.AddPropertyForCategory(Addpc);
            TempData["Result"] = res ? "true" : "false";
            return RedirectToAction(nameof(ShowAllPropertyNames));
        }

        [HttpGet]
        public IActionResult UpdateProperties(int id)
        {
            ViewBag.category = _categoryService.ShowSubCategory();
            ViewBag.property = _productService.ShowPropertyNameForUpdate(id);
            return View(_productService.FindPropById(id));
        }

        [HttpPost]
        public IActionResult UpdateProperties(PropertyName propertyName, List<int> Categoryid)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.category = _categoryService.ShowSubCategory();
                ViewBag.property = _productService.ShowPropertyNameForUpdate(propertyName.PropertyNameId);
                return View();
            }
            if (_productService.IsPropertyNameExists(propertyName.PropertyTitle, propertyName.PropertyNameId))
            {
                ModelState.AddModelError("PropertyTitle", "خصوصیات تکراری است");
                return View(propertyName);
            }
            bool updateprop = _productService.UpdatePropertyName(propertyName);
            if (!updateprop)
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllPropertyNames));
            }
            bool deleteprop = _productService.DeletePropertyForCategory(propertyName.PropertyNameId);
            if (!deleteprop)
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllPropertyNames));
            }
            List<PropertyName_Category> categories = new List<PropertyName_Category>();
            foreach (var item in Categoryid)
            {
                categories.Add(new PropertyName_Category
                {
                    CategoryId = item,
                    PropertyNameId = propertyName.PropertyNameId,
                });
            }
            bool addpropertyforcategory = _productService.AddPropertyForCategory(categories);
            TempData["Result"] = addpropertyforcategory ? "true" : "false";
            return RedirectToAction(nameof(ShowAllPropertyNames));
        }
        #endregion

        #region Product
        public IActionResult ShowAllProducts(int page = 1, string filterByName = "")
        {
            ViewData["FilterByName"] = filterByName;
            ViewBag.page = page;
            ViewBag.CountProduct = _productService.ProductCount();
            return View(_productService.ShowAllProduct(page, filterByName));
        }

        [HttpGet]
        public IActionResult Search(List<int> categoryId, List<int> brandId,
            string text = "", string minprice = "", string maxprice = "", int sort = 1)
        {
            if (text == null)
                text = "";

            var listProduct = _productService.SearchAllProduct(text, categoryId, brandId,
                minprice.PriceReplacement(), maxprice.PriceReplacement());
            ViewBag.brand = _brandService.ShowAllBrands();
            ViewBag.category = _categoryService.ShowSubCategory();
            ViewBag.text = text;
            ViewBag.sort = sort;
            ViewBag.categoryid = categoryId;
            ViewBag.brandid = brandId;
            return View(listProduct);
        }

        [HttpGet]
        public IActionResult AddProducts()
        {
            ViewBag.category = _categoryService.ShowSubCategory();
            ViewBag.brand = _brandService.ShowAllBrands();
            return View();
        }

        [HttpPost]
        public IActionResult AddProducts(Product product, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Category = _categoryService.ShowSubCategory();
                ViewBag.brand = _brandService.ShowAllBrands();
                return View(product);
            }
            if (file == null)
            {
                ModelState.AddModelError("SliderImg", "لطفا یک تصویر برای محصول انتخاب نمایید .");
                return View(product);

            }

            string imgname = UploadImage.CreateImage(file);
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllProducts));
            }
            product.ProductCreate = DateTime.Now;
            product.ProductImage = imgname;
            int productid = _productService.AddProduct(product);
            TempData["Result"] = productid > 0 ? "true" : "false";
            return RedirectToAction(nameof(ShowAllProducts));

        }


        [HttpGet]
        public IActionResult UpdateProducts(int id)
        {
            Product update = _productService.FindProductById(id);
            if (update == null)
            {
                return NotFound();
            }
            ViewBag.category = _categoryService.ShowSubCategory();
            ViewBag.brand = _brandService.ShowAllBrands();
            return View(update);
        }

        [HttpPost]
        public IActionResult UpdateProducts(Product product, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.category = _categoryService.ShowSubCategory();
                ViewBag.brand = _brandService.ShowAllBrands();
                return View(product);
            }
            if (file != null)
            {
                string imageName = UploadImage.CreateImage(file);
                if (imageName == "false")
                {
                    TempData["Result"] = "false";
                    return RedirectToAction(nameof(Index));
                }
                bool deleteImage = UploadImage.DeleteImage("ImageSite", product.ProductImage);
                if (!deleteImage)
                {
                    TempData["Result"] = "false";
                    return RedirectToAction(nameof(Index));
                }
                product.ProductImage = imageName;
            }
            product.ProductUpdate = DateTime.Now;
            bool update = _productService.UpdateProduct(product);
            TempData["Result"] = update ? "true" : "false";
            return RedirectToAction(nameof(ShowAllProducts));
        }

        [HttpGet]
        public IActionResult ShowPropertyNameForProduct(int id)
        {
            int categoryid = _productService.FindCategoryForProduct(id);
            ViewBag.propertyname = _productService.ShowAllPropertyForCategory(categoryid);
            ViewBag.propertyvalue = _productService.ShowPropertyValueForProduct(id);
            TempData["ProductId"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddPropertyForProduct(List<int> nameId, List<string> value)
        {
            int productid = int.Parse(TempData["ProductId"].ToString());
            if (nameId.Count != value.Count)
            {
                int categoryid = _productService.FindCategoryForProduct(productid);
                ViewBag.propertyname = _productService.ShowAllPropertyForCategory(categoryid);
                ViewBag.propertyvalue = _productService.ShowPropertyValueForProduct(productid);
                TempData["ProductId"] = productid;
                return View("ShowPropertyNameForProduct");
            }
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            for (int i = 0; i < nameId.Count; i++)
            {
                propertyValues.Add(new PropertyValue
                {
                    ProductId = productid,
                    Propertyvalue = value[i],
                    PropertyNameId = nameId[i]
                });
            }
            List<PropertyValue> propertyValue = propertyValues.Where(p => p.Propertyvalue != null).ToList();
            bool res = _productService.AddOrUpdatePropertyNameForProduct(propertyValues, productid);
            TempData["Result"] = res ? "true" : "false";
            return RedirectToAction(nameof(ShowAllProducts));
        }

        public IActionResult ShowAllPrice(int id)
        {
            ViewBag.id = id;
            return View(_productService.ShowAllPriceForProduct(id));
        }

        [HttpGet]
        public IActionResult AddPrice(int id)
        {
            ViewBag.guarantee = _guarenteeService.ShowAllGuarantee();
            ViewBag.color = _productService.ShowAllColor();
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddPrice(AddOrUpdateProductPriceVM productPrice)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.guarantee = _guarenteeService.ShowAllGuarantee();
                ViewBag.color = _productService.ShowAllColor();
                ViewBag.id = productPrice.ProductId;
                return View(productPrice);
            }
            ProductPrice product = new ProductPrice
            {
                Count = productPrice.Count,
                CreateDate = DateTime.Now,
                EndDateDiscount = productPrice.EndDateDiscount?.ToMiladi(),
                MainPrice = productPrice.MainPrice,
                MaxOrderCount = productPrice.MaxOrderCount,
                ColorId = productPrice.ColorId,
                ProductGuaranteeId = productPrice.ProductGuaranteeId,
                ProductId = productPrice.ProductId,
                SpecialPrice = productPrice.SpecialPrice,
                ProductPriceId = productPrice.ProductPriceId,
            };
            int priceid = _productService.AddPriceForProduct(product);
            TempData["Result"] = priceid > 0 ? "true" : "false";
            return RedirectToAction(nameof(ShowAllProducts));
        }

        #endregion

        #region Review
        public IActionResult ShowReview(int id)
        {
            ViewBag.review = _productService.FindeReviewById(id);
            TempData["ProductId"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddReview(List<string> posative, List<string> negative, Review review)
        {
            int productid = int.Parse(TempData["ProductId"].ToString());
            if (!ModelState.IsValid)
            {
                ViewBag.review = _productService.FindeReviewById(productid);
                TempData["ProductId"] = productid;
                return View(review);
            }
            bool deleteReview = _productService.DeleteReview(productid);
            if (!deleteReview)
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllProducts));
            }
            Review addReview = new Review()
            {
                ArticleDescription = review.ArticleDescription,
                ArticleTitle = review.ArticleTitle,
                ReviewDescription = review.ReviewDescription,
                ReviewNegative = string.Join("^", negative),
                ReviewPositive = string.Join("^", posative)
            };
            if (addReview.ReviewDescription != null ||
                addReview.ArticleTitle != null ||
                addReview.ArticleDescription != null ||
                (!string.IsNullOrEmpty(addReview.ReviewPositive) || !string.IsNullOrEmpty(addReview.ReviewNegative)))
            {
                addReview.ProductId = productid;
                bool addreview = _productService.AddOrUpdateReview(addReview);
                TempData["Result"] = addreview ? "true" : "false";
                return RedirectToAction(nameof(ShowAllProducts));
            }
            TempData["Result"] = deleteReview ? "true" : "false";
            return RedirectToAction(nameof(ShowAllProducts));
        }
        #endregion

        #region posted

        [Route("ShowPosted")]
        public IActionResult ShowPosted(int page = 1, string filterByEmail = "")
        {
            ViewData["FilterByEmail"] = filterByEmail;
            ViewBag.page = page;
            return View(_cartService.ShowPosteds(page, filterByEmail));
        }


        [Route("DetailPosted/{id}")]
        public IActionResult DetailPosted(int id, int page = 1, string filterByRefId = "")
        {
            ViewBag.FilterByRefId = filterByRefId;
            ViewBag.page = page;
            return View(_cartService.DetailPosteds(id, page, filterByRefId));
        }


        [Route("Accept/{cartId}")]
        public IActionResult Accept(int cartId)
        {
            _cartService.Accepts(cartId);
            return RedirectToAction(nameof(ShowPosted));
        }
        #endregion

        #region Gallery

        public IActionResult ShowAllGalleries(int id)
        {
            ViewBag.id = id;
            return View(_productService.ShowAllGallery(id));
        }

        [HttpGet]
        public IActionResult AddGalleries(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddGalleries(ProductGallery gallery, IFormFile galleryFile)
        {
            if (!ModelState.IsValid)
                return View(gallery);

            if (galleryFile == null)
            {
                ModelState.AddModelError("GalleryImage", "لطفا برای گالری خود تصویری را انتخاب نمایید");
                return View(gallery);
            }
            string galleryName = UploadImage.CreateImage(galleryFile);
            if (galleryName == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(ShowAllGalleries));
            }
            gallery.GalleryImage = galleryName;
            int res = _productService.AddGallery(gallery);
            TempData["Result"] = res > 0 ? "true" : "false";
            return RedirectToAction(nameof(ShowAllGalleries));

        }
        #endregion

    }
}
