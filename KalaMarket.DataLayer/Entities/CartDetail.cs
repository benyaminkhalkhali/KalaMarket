using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities
{
    public class CartDetail
    {
        [Key]
        public int CartDetailId { get; set; }
        public int Product_PriceID { get; set; }
        public int Product_ID { get; set; }
        public int OrderCount { get; set; }
        public int Price { get; set; }
        public DateTime CreateDate { get; set; }

        public int CartId { get; set; }
        #region relation

        [ForeignKey(nameof(CartId))]
        public Cart cart { get; set; }
        #endregion
    }
}
