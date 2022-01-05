using KalaMarket.DataLayer.Entities.Address;
using KalaMarket.DataLayer.Entities.Discount;
using KalaMarket.DataLayer.Entities.ProductEntities;
using KalaMarket.DataLayer.Entities.ProductEntities.FAQ;
using KalaMarket.DataLayer.Entities.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstAndLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateAccount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string ActiveCode { get; set; }

        #region Relations
        public List<Question> questions { get; set; }
        public List<Comment> comments { get; set; }
        public List<Favourite> favourites { get; set; }
        public List<Cart> carts { get; set; }
        public List<UserDiscount> userDiscounts { get; set; }
        public List<UserRole> userRoles { get; set; }
        public List<UserAddress> userAddresses { get; set; }
        #endregion
    }
}
