using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessAPI.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string HomeAddress { get; set; }
        public string OfficeAddress { get; set; }
        public int ContactNumber2 { get; set; }
        public int ContactNumber3 { get; set; }
        public Gender Gender { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
