using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public class InformationAccountVM
    {
        public DateTime DateTime { get; set; }

       
        public string Email { get; set; }
        public int UserId { get; set; }

        
        public string Phone { get; set; }

        public string FirstAndLastName { get; set; }
    }
}
