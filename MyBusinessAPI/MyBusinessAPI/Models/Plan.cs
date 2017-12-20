using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessAPI.Models
{
    public class Plan
    {
        public int PlanId { get; set; }
        public string Title { get; set; }
        public string descrioption { get; set; }
        public DateTime DurationFrom { get; set; }
        public DateTime DurationTo { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
