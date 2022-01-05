using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ViewModel
{
    public  class ShowFaqVM
    {
        public int QuestionId { get; set; }
        public string UserNameQ { get; set; }
        public string DescriptionQ { get; set; }
        public DateTime CreateDateQ { get; set; }

        public ShowAnswerVM ShowAnswerVm { get; set; }
    }
    public class ShowAnswerVM
    {
        public int? AnswerId { get; set; }
        public string UserNameA { get; set; }
        public string DescriptionA { get; set; }
        public DateTime? CreateDateA { get; set; }
    }
}
