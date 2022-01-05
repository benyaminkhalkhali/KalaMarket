using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities
{
    public class MainSlider
    {
        [Key]
        public int SliderId { get; set; }
        [Display(Name = "عنوان اسلایدر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SliderTitle { get; set; }

        [Display(Name = "آلت اسلایدر")]
        public string SliderAlt { get; set; }

        [Display(Name = "ترتیب اسلایدر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int SliderSort { get; set; }

        [Display(Name = "لینک اسلایدر")]
        public string SliderLink { get; set; }

        [Display(Name = "عکس اسلایدر")]
        public string SliderImage { get; set; }
        public bool IsActive { get; set; }
    }
}
