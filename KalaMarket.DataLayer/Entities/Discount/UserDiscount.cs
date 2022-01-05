using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.Discount
{
    public class UserDiscount
    {
        [Key]
        public int UserDiscountId { get; set; }


        public int UserId { get; set; }
        public int DiscountId { get; set; }

        #region relation

        [ForeignKey(nameof(UserId))]
        public User user { get; set; }

        [ForeignKey(nameof(DiscountId))]
        public Discount discount { get; set; }
        #endregion
    }
}
