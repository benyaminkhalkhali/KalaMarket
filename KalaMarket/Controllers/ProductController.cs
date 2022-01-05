using KalaMarket.Core.ExtensionMethod;
using KalaMarket.Core.Security;
using KalaMarket.Core.Service.IService;
using KalaMarket.Core.ViewModel;
using KalaMarket.DataLayer.Entities;
using KalaMarket.DataLayer.Entities.Address;
using KalaMarket.DataLayer.Entities.ProductEntities;
using KalaMarket.DataLayer.Entities.ProductEntities.FAQ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalaMarket.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IBrandService _brandService;
        private ICategoryService _categoryService;
        private ICartService _cartService;
        private IDiscountService _discountService;
        private IAddressService _addressService;
        private IUserService _userService;
        public ProductController(IProductService productService, IBrandService brandService,
            ICategoryService categoryService, ICartService cartService,
            IDiscountService discountService, IAddressService addressService, IUserService userService)
        {
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
            _cartService = cartService;
            _discountService = discountService;
            _addressService = addressService;
            _userService = userService;
        }


        [Route("Product/Detail/{id}/{productName}")]
        public IActionResult Detail(int id)
        {
            
            var detailProduct = _productService.DetailProduct(id);
            var productPrice = _productService.GetProductPrice(id);
            ViewBag.propertyvalue = _productService.ShowValueForProduct(id);
            ViewBag.gallery = _productService.ShowGalleryForProduct(id);
            if (detailProduct == null)
                return NotFound();

            return View(Tuple.Create(detailProduct, productPrice));
        }
        public IActionResult ShowReview(int id)
        {
            return View(_productService.FindeReviewById(id));
        }
        public IActionResult ShowAllProperty(int id)
        {
            return View(_productService.ShowAllPropertyForProduct(id));
        }
        public IActionResult ShowFaq(int id)
        {
            TempData["ProductId"] = id;
            return View(_productService.ShowAllFaq(id));
        }

        [Route("compare/{id?}/{id2?}/{id3?}")]
        public IActionResult Compare(int? id, int? id2, int? id3)
        {
            if (id <= 0 || id == null)
            {
                return Redirect("/Product/Detail/{id}");
            }
            List<int?> listId = new List<int?> { id, id2, id3 };
            var listProduct = _productService.ShowCompareProduct(listId);
            var productGroup = listProduct.GroupBy(p => p.ProductId).Select(p => new CompareVM
            {
                CategoryId = p.FirstOrDefault().CategoryId,
                ProductFaTitle = p.FirstOrDefault().ProductFaTitle,
                ProductId = p.Key,
                ProductImage = p.FirstOrDefault().ProductImage,
                ProductPrice = p.FirstOrDefault().ProductPrice,
                CompareVm = p.FirstOrDefault().CompareVm
            }).ToList();
            ViewBag.property = _productService.ShowPropertyCompare(productGroup[0].CategoryId);
            ViewBag.product = _productService.GetProductForCompare(productGroup[0].CategoryId, listId);
            return View(productGroup.OrderBy(p => p.ProductId));
        }

        [HttpPost]
        [Route("ChangeFavourite")]
        public JsonResult ChangeFavourite(int productId)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            Favourite favourite = _productService.FindFavouriteByUserId(userid, productId);
            Favourite addordelete = new Favourite();
            if (favourite == null)
            {
                addordelete.ProductId = productId;
                addordelete.UserId = userid;
                bool result = _productService.AddFavourite(addordelete);
                return Json(result);
            }
            else
            {
                bool result = _productService.RemoveFavourite(favourite);
                return Json(result);
            }
        }

        [HttpPost]
        [Route("CheckFavourite")]
        public JsonResult CheckFavourite(int productId)
        {
            if (User.Identity.IsAuthenticated)
            {
                int userid = int.Parse(User.FindFirst("userid").Value);
                Favourite favourite = _productService.FindFavouriteByUserId(userid, productId);
                if (favourite != null)
                    return Json(true);

                return Json(false);
            }
            return Json(false);
        }

        [HttpPost]
        [Route("AddorDeleteFavourite")]
        public JsonResult AddorDeleteFavourite(int productId)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            Favourite favourite = _productService.FindFavouriteByUserId(userid, productId);
            Favourite addfavourite = new Favourite();
            if (favourite != null)
            {
                _productService.RemoveFavourite(favourite);
                return Json(true);
            }
            else
            {
                addfavourite.ProductId = productId;
                addfavourite.UserId = userid;
                _productService.AddFavourite(addfavourite);
                return Json(false);
            }
        }

        [HttpPost]
        public IActionResult AddQuestionorAnswer(int questionId, string text, int productId)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            if (questionId > 0)
            {
                Answer answer = new Answer
                {
                    AnswerDescription = text,
                    CreateDate = DateTime.Now.Date,
                    QuestionId = questionId,
                    UserId = userid
                };
                int answerId = _productService.AddAnswer(answer);
                return Json(answerId);
            }
            else
            {
                Question question = new Question
                {
                    UserId = userid,
                    QuestionDescription = text,
                    CreateDate = DateTime.Now,
                    ProductId = productId
                };
                int questionid = _productService.AddQuestion(question);
                return Json(questionid);
            }
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


        [Route("ShowAllProductForBasket")]
        public IActionResult ShowAllProductForBasket()
        {
            List<ShowBasketVM> showBaskets = new List<ShowBasketVM>();
            if (!User.Identity.IsAuthenticated)
                return View(showBaskets);

            int userId = int.Parse(User.FindFirst("userid").Value);
            showBaskets = _cartService.ShowAllProductForBasket(userId);
            return View(showBaskets);
        }


        public IActionResult ShowComment(Product model)
        {
            ViewBag.comments = _productService.GetProductComment(model.ProductId);
            return View();
        }

        public IActionResult AddComment(Comment model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "ورودی های خود را بررسی نمایید";
                return PartialView();
            }
            model.UserId = _userService.GetUserIdByEmail(User.Identity.GetEmail());
            model.CreateDate = DateTime.Now;
            model.IsActive = false;
            model.IsDelete = false;
            int commentId = _productService.AddComment(model);
            if (commentId <= 0)
            {
                ViewBag.Message = "ثبت با خطا مواجه شد";
                return PartialView();
            }
            else
            {
                return PartialView(model);
            }
        }

        #region Cart

        [HttpPost]
        [Route("AddCart/{id}/{ordercount}")]
        public IActionResult AddCarts(int id, int ordercount)
        {
            if (!User.Identity.IsAuthenticated)
                return Json(1);

            int userId = int.Parse(User.FindFirst("userid").Value);
            int code = _cartService.AddCart(userId, id, ordercount);
            return Json(code);

        }


        [HttpGet]
        [Authorize]
        [Route("Basket")]
        public IActionResult Basket(int Code)
        {
            int userId = int.Parse(User.FindFirst("userid").Value);
            var viewmodel = _cartService.CartDetail(userId);
            ViewBag.code = Code;
            return View(viewmodel);
        }

        [HttpPost]
        [Route("changecart")]
        public IActionResult ChangeCart(int productpriceid, int count)
        {
            int userId = int.Parse(User.FindFirst("userid").Value);
            _cartService.ChangeBasket(userId, productpriceid, count);
            return Json(1);
        }


        [HttpGet]
        [Route("removeProductForBasket/{productpriceid}/{cartId}")]
        public IActionResult RemoveProductForBasket(int productpriceid, int cartId)
        {
            _cartService.RemoveProductForBasket(productpriceid, cartId);
            return RedirectToAction(nameof(Basket));
        }


        [HttpPost]
        [Route("Discount")]
        public IActionResult Discount(string discountCode, int cartId)
        {
            int userId = int.Parse(User.FindFirst("userid").Value);
            int code = _discountService.CheckDiscount(cartId, discountCode);
            return RedirectToAction(nameof(Basket), new { Code = code });
        }

        public IActionResult Order()
        {
            if (!ModelState.IsValid)
                return null;
            int userId = int.Parse(User.FindFirst("userid").Value);
            ViewBag.address = _addressService.GetUserAddress(userId);
            return View();
        }

        [HttpPost]
        public JsonResult AddNewAddress([FromBody] UserAddress model)
        {
            string result = "";
            //model.UserId = _userService.GetUserIdByEmail(User.Identity.GetEmail());
            model.UserId = _userService.GetUserIdByEmail(User.FindFirst("useremail").Value);
            if (string.IsNullOrEmpty(model.Province) || string.IsNullOrEmpty(model.City)
                || string.IsNullOrEmpty(model.PostalCode.ToString())
                || string.IsNullOrEmpty(model.FullAddress) || string.IsNullOrEmpty(model.PhoneNumber))
            {
                result = "مقادیر وارد شده صحیح نمی باشند";
            }
            else
            {
                if (_userService.IsExistPostalCodeForUser(model.UserId, model.PostalCode))
                {
                    result = "آدرسی با این کدپستی وجود دارد";
                }
                else
                {
                    if (_userService.AddNewAddressForUser(model))
                        result = "OK";
                    else
                        result = "خطایی در هنگام ثبت رخ داد";
                }
            }
            return Json(result);
        }

        #endregion

        #region Payment

        [HttpGet]
        [Authorize]
        [Route("Payment")]
        public IActionResult Payment()
        {
            int userId = int.Parse(User.FindFirst("userid").Value);
            Cart cart = _cartService.FindCartByUserId(userId);
            var zarinpal = new ZarinpalSandbox.Payment(cart.TotalPrice);
            var result = zarinpal.PaymentRequest("پرداخت سبد خرید کالامارکت", "https://localhost:44341/onlinepayment/" + cart.CartId);
            if (result.Result.Status == 100)
            {
                var a = result.Result.Link;
                var a1 = result.Result.Authority;
                return Redirect(a);
                /*return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + result.Result.Authority);*/
            }
            return null;
        }


        [Route("onlinepayment/{cartId}")]
        public IActionResult onlinepayment(int cartId)
        {
            bool res = false;
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                var authority = HttpContext.Request.Query["Authority"];
                var cart = _cartService.FindCartById(cartId);
                var zarinpal = new ZarinpalSandbox.Payment(cart.TotalPrice);
                var result = zarinpal.Verification(authority).Result;

                if (result.Status == 100)
                {
                    ViewBag.refid = result.RefId;
                    res = true;
                    cart.IsPaid = true;
                    cart.RefId = result.RefId.ToString();
                    _cartService.UpdateCart(cart);
                    _cartService.UpdateSell(cart.CartId);
                }
                
            }
            ViewBag.res = res;
            return View();
        }

        #endregion

        #region Comment

        [HttpPost]
        public JsonResult OkComment([FromBody] Comment model)
        {
            string result = "";
            if (_productService.OkComment(model.CommentId))
                result = "OK";
            else
                result = "NOK";

            return Json(result);

        }
        [HttpPost]
        public JsonResult NotOkComment([FromBody] Comment model)
        {
            string result = "";
            if (_productService.NotOkComment(model.CommentId))
                result = "OK";
            else
                result = "NOK";

            return Json(result);
        }

       

        #endregion

    }
}
