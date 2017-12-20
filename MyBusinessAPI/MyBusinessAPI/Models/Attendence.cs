using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessAPI.Models
{
    public class Attendence
    {
        public int AttendenceId { get; set; }
        public string Title { get; set; }
        public SubjectTeacherStandardRelation SubjectTeacherStandardRelation { get; set; }
        public Student Student { get; set; }
        public bool IsPresent { get; set; }
        public Person CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
