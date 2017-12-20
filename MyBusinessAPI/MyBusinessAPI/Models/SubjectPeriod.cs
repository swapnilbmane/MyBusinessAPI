using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessAPI.Models
{
    public class SubjectPeriod
    {
        public int SubjectPeriodId { get; set; }
        public SubjectTeacherStandardRelation SubjectTeacherStandardRelation { get; set; }
        public DateTime SchecduledFrom { get; set; }
        public DateTime SchecduledTo { get; set; }
        public Person CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
