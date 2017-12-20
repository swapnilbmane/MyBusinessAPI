using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessAPI.Models
{
    public class SubjectExam
    {
        public int SubjectExamId { get; set; }
        public Exam Exam { get; set; }
        public Subject Subject { get; set; }
        public DateTime SceduledFrom { get; set; }
        public DateTime ScheduledTo { get; set; }
        public int MaxMarks { get; set; }
        public Person CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
