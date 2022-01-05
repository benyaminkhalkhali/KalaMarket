using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.ProductEntities
{
    public class PropertyName_Category
    {
        [Key]
        public int pcId { get; set; }

        public int PropertyNameId { get; set; }
        public int CategoryId { get; set; }

        #region Relations
        [ForeignKey("CategoryId")]
        public Category category { get; set; }

        [ForeignKey("PropertyNameId")]
        public PropertyName propertyName { get; set; }
        #endregion

    }
}
