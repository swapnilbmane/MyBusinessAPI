using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessAPI.Models
{
    public class StudentParentRelation
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Person Parent { get; set; }
    }
}
