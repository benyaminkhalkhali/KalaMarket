
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.ProductEntities
{
    public class ProductGallery
    {
        [Key]
        public int GalleryId { get; set; }

        [Display(Name = "عنوان گالری محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string GalleryTitle { get; set; }

        [Display(Name = "تصویر گالری محصول")]
        public string GalleryImage { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public int ProductId { get; set; }

        #region Relations
        [ForeignKey("ProductId")]
        public Product product { get; set; }
        #endregion
    }
}
