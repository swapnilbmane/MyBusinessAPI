using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessAPI.Models
{
    public class SubjectTeacherStandardRelation
    {
        public int Id { get; set; }
        public Standard Standard { get; set; }
        public Subject Subject { get; set; }
        public Person Teacher { get; set; }
    }
}
