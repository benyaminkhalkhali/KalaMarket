using KalaMarket.Core.ExtensionMethod;
using KalaMarket.Core.Service.IService;
using KalaMarket.Core.ViewModel;
using KalaMarket.DataLayer.Context;
using KalaMarket.DataLayer.Entities;
using KalaMarket.DataLayer.Entities.Address;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service
{
    public class UserService : IUserService
    {
        private KalaMarketContext _context;
        public UserService(KalaMarketContext context)
        {
            _context = context;
        }
        public int AddUser(User user)
        {
            try
            {
                _context.users.Add(user);
                _context.SaveChanges();
                return user.UserId;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool DeleteUser(User user)
        {
            try
            {
                user.IsDelete = true;
                _context.users.Update(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool IsEmailExists(string email)
        {
            return _context.users.Any(u => u.Email == email);
        }
        public bool IsMobileExists(string mobile)
        {
            return _context.users.Any(c => c.PhoneNumber == mobile.Replace(" ", "") && c.IsDelete == false);
        }
        public bool UpdateUser(User user)
        {
            try
            {
                _context.users.Update(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public User FindUser(int userId, string code)
        {
            return _context.users.Where(u => u.UserId == userId && u.ActiveCode == code).FirstOrDefault();
        }
        public User FindUserByEmail(string email)
        {
            return _context.users.Where(u => u.Email == email && !u.IsDelete).FirstOrDefault();
        }
        public User LoginUser(string email, string password)
        {
            return _context.users.Where(u => u.Password == password && u.Email == email).SingleOrDefault();
        }
        public InformationAccountVM InformationAccount(int userId)
        {
            return _context.users.Where(x => x.UserId == userId).Select(x => new InformationAccountVM
            {
                DateTime = x.CreateAccount,
                Email = x.Email,
                UserId = x.UserId,
                Phone = x.PhoneNumber,
                FirstAndLastName = x.FirstAndLastName
            }).FirstOrDefault();
        }
        public EditUserVM FindUserById(int userId)
        {
            return _context.users.Where(u => u.UserId == userId && !u.IsDelete)
                .Select(u => new EditUserVM
                {
                    Email = u.Email,
                    Phone = u.PhoneNumber,
                    UserNameAndFamily = u.FirstAndLastName
                }).FirstOrDefault();
        }
        public User FindEditUserBuId(int userId)
        {
            return _context.users.Find(userId);
        }
        public List<ShowFavouriteVM> ShowFavouriteUser(int userId)
        {
            return (from f in _context.favourites
                    join u in _context.users on f.UserId equals u.UserId
                    join p in _context.products on f.ProductId equals p.ProductId
                    where (f.UserId == userId)
                    select new ShowFavouriteVM
                    {
                        ProductFaTitle = p.ProductFaTitle,
                        ProductId = p.ProductId,
                        ProductImage = p.ProductImage,
                        ProductStar = p.ProductStar,
                        ProductPrice = _context.productPrices.Where(x => x.Count > 0 && x.ProductId == p.ProductId)
                            .OrderBy(x => x.MainPrice).Select(x => x.MainPrice).FirstOrDefault(),

                    }).ToList();
        }
        public List<ShowOrderForUserVM> ShowOrderForUsers(int userId)
        {
            return _context.carts.Where(x => x.UserId == userId)
                .Select(x => new ShowOrderForUserVM
                {
                    CartId = x.CartId,
                    CreateDate = x.CreateDate.ToShamsi(),
                    IsPay = x.IsPaid,
                    TotalPrice = x.TotalPrice,
                }).ToList();
        }
        public List<ShowDetailOrderForUserVM> showDetailOrderForUsers(int userId, int cartId)
        {
            return (from c in _context.carts
                    join cd in _context.cartDetails on c.CartId equals cd.CartId
                    join u in _context.users on c.UserId equals u.UserId
                    join pr in _context.productPrices on cd.Product_PriceID equals pr.ProductPriceId
                    join p in _context.products on pr.ProductId equals p.ProductId
                    where (c.UserId == userId && c.CartId == cartId)
                    select new ShowDetailOrderForUserVM
                    {
                        Count = cd.OrderCount,
                        ProductId = p.ProductId,
                        ProductPrice = cd.Price,
                        TotalPrice = c.TotalPrice,
                        ProductFaTitle = p.ProductFaTitle,
                        RefId = c.RefId,
                        IsPaid = c.IsPaid,
                    }).ToList();
        }



        #region AdminPanel

        public EditUserVM GetUserDataForEdit(string email)
        {

            return _context.users.Where(c => c.Email == email && c.IsDelete == false).Select(c => new EditUserVM()
            {
                UserNameAndFamily = c.FirstAndLastName,
                Phone = c.PhoneNumber,
            }).FirstOrDefault();

        }
        public bool SaveUserEdit(string email, EditUserVM model)
        {
            User user = _context.users.Where(c => c.Email == email && c.IsDelete == false).FirstOrDefault();

            user.FirstAndLastName = model.UserNameAndFamily;
            user.PhoneNumber = model.Phone;


            return Convert.ToBoolean(_context.SaveChanges());
        }
        public ShowUsersInAdminVM ShowUserInAdmin(int pageId = 1, int take = 10, string filterByName = "",
            string filterByMobile = "", string filterByEmail = "")
        {
            IQueryable<User> result = _context.users.Where(c => !c.IsDelete);
            ShowUsersInAdminVM list = new ShowUsersInAdminVM();

            if (!string.IsNullOrEmpty(filterByName))
            {
                result = result.Where(c => c.FirstAndLastName.Contains(filterByName));
            }
            if (!string.IsNullOrEmpty(filterByMobile))
            {
                result = result.Where(c => c.PhoneNumber.Contains(filterByMobile));
            }
            if (!string.IsNullOrEmpty(filterByEmail))
            {
                result = result.Where(c => c.Email.Contains(filterByEmail));
            }

            list.Count = result.Count();
            int skip = (pageId - 1) * take;
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling(result.Count() / (double)take);
            list.users = result.OrderByDescending(c => c.UserId).Skip(skip).Take(take).ToList();
            return list;
        }

        public int AddUserByAdmin(AddUserByAdminVM model)
        {
            User user = new User();
            user.Email = model.Email.Replace(" ", "");
            user.FirstAndLastName = model.UserNameAndFamily;
            user.IsActive = model.IsActive;
            user.IsDelete = false;
            user.PhoneNumber = model.PhoneNumber;
            user.Password = Md5.EncodePasswordMd5(model.Password);
            user.CreateAccount = DateTime.Now;
            user.ActiveCode = GenerateCode.GuidCode();

            _context.users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public EditUserByAdminVM GetUserDataForEditInAdminPanel(int userId)
        {
            return _context.users.Include(c => c.userRoles).Where(c => c.UserId == userId)
                .Select(c => new EditUserByAdminVM
                {
                    IsActive = c.IsActive,
                    Email = c.Email,
                    UserNameAndFamily = c.FirstAndLastName,
                    PhoneNumber = c.PhoneNumber,
                    UserId = c.UserId,
                    UserRolesID = c.userRoles.Select(r => r.RoleId).ToList()
                }).FirstOrDefault();
        }

        public bool EditUserByAdmin(EditUserByAdminVM model)
        {
            if (model.UserId <= 0)
                return false;

            User user = _context.users.Find(model.UserId);
            if (user == null)
                return false;

            user.Email = model.Email.Replace(" ", "");
            user.FirstAndLastName = model.UserNameAndFamily;
            user.PhoneNumber = model.PhoneNumber;
            user.IsActive = model.IsActive;
            if (!string.IsNullOrEmpty(model.Password) && !string.IsNullOrEmpty(model.ConfirmPassword))
            {
                user.Password = Md5.EncodePasswordMd5(model.Password);
            }
            _context.Entry(user).State = EntityState.Modified;
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public User GetUserById(int id)
        {
            return _context.users.Where(c => c.UserId == id && !c.IsDelete).FirstOrDefault();
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                User user = _context.users.Find(userId);
                if (user.IsDelete == true)
                    return false;

                user.IsDelete = true;
                _context.Entry(user).State = EntityState.Modified;
                return Convert.ToBoolean(_context.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int CountofDeletedUsers()
        {
            return _context.users.Where(c => c.IsDelete == true).Count();
        }

        public int CountofDeactiveUsers()
        {
            return _context.users.Where(c => !c.IsActive).Count();
        }
        public ShowUsersInAdminVM DeletedUsers(int pageId = 1, int take = 10, string filterByName = "",
            string filterByMobile = "", string filterByEmail = "")
        {
            IQueryable<User> result = _context.users.Where(c => c.IsDelete == true);
            ShowUsersInAdminVM list = new ShowUsersInAdminVM();

            if (!string.IsNullOrEmpty(filterByName))
            {
                result = result.Where(c => c.FirstAndLastName.Contains(filterByName));
            }
            if (!string.IsNullOrEmpty(filterByMobile))
            {
                result = result.Where(c => c.PhoneNumber.Contains(filterByMobile));
            }
            if (!string.IsNullOrEmpty(filterByEmail))
            {
                result = result.Where(c => c.Email.Contains(filterByEmail));
            }

            list.Count = result.Count();
            int skip = (pageId - 1) * take;
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling(result.Count() / (double)take);
            list.users = result.OrderByDescending(c => c.UserId).Skip(skip).Take(take).ToList();
            return list;
        }

        public ShowUsersInAdminVM DeactiveUsers(int pageId = 1, int take = 10, string filterByName = "",
            string filterByMobile = "", string filterByEmail = "")
        {
            IQueryable<User> result = _context.users.Where(c => !c.IsDelete && !c.IsActive);
            ShowUsersInAdminVM list = new ShowUsersInAdminVM();

            if (!string.IsNullOrEmpty(filterByName))
            {
                result = result.Where(c => c.FirstAndLastName.Contains(filterByName));
            }
            if (!string.IsNullOrEmpty(filterByMobile))
            {
                result = result.Where(c => c.PhoneNumber.Contains(filterByMobile));
            }
            if (!string.IsNullOrEmpty(filterByEmail))
            {
                result = result.Where(c => c.Email.Contains(filterByEmail));
            }

            list.Count = result.Count();
            int skip = (pageId - 1) * take;
            list.CurrentPage = pageId;
            list.PageCount = (int)Math.Ceiling(result.Count() / (double)take);
            list.users = result.OrderByDescending(c => c.UserId).Skip(skip).Take(take).ToList();
            return list;
        }
        #endregion

        #region Order

        public int GetUserIdByEmail(string email)
        {
            return _context.users.Where(c => c.Email == email).FirstOrDefault().UserId;
        }
        public bool IsExistPostalCodeForUser(int userId, int postalCode)
        {
            return _context.userAddresses.Any(c => c.UserId == userId && c.PostalCode == postalCode);
        }
        public bool AddNewAddressForUser(UserAddress address)
        {
            _context.userAddresses.Add(address);
            return Convert.ToBoolean(_context.SaveChanges());
        }

        #endregion
    }
}
