using KalaMarket.DataLayer.Entities.Address;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public bool IsPaid { get; set; }
        public string RefId { get; set; }
        public DateTime CreateDate { get; set; }
        public int TotalPrice { get; set; }
        public bool Posted { get; set; }

        public int? AddressId { get; set; }
        #region relation

        [ForeignKey(nameof(UserId))]
        public User user { get; set; }

        [ForeignKey(nameof(AddressId))]
        public UserAddress address { get; set; }

        public List<CartDetail> cartDetails { get; set; }
        #endregion
    }
}
