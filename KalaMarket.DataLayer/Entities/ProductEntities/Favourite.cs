using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.ProductEntities
{
    public class Favourite
    {
        [Key]

        public int FavouriteId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        #region relation

        [ForeignKey(nameof(ProductId))]
        public Product product { get; set; }

        [ForeignKey(nameof(UserId))]
        public User user { get; set; }
        #endregion
    }
}
