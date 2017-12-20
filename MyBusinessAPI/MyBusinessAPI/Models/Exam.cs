using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessAPI.Models
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledOn { get; set; }
        public Person Createdby { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
