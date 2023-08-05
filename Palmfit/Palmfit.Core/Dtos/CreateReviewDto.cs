using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Dtos
{
    public class CreateReviewDto
    {
        public DateTime Date { get; set; }= DateTime.Now;
        public string Comment { get; set; }
        public int Rating { get; set; }
        public string Verdict { get; set; }
        public string AppUserId { get; set; }
    }
}
