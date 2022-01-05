using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.Discount
{
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountPercent { get; set; }
        public int? UsableCount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsDelete { get; set; }

        #region relation
        public List<UserDiscount> userDiscounts { get; set; }
        #endregion
    }
}
