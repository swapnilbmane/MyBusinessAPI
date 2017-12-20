using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessAPI.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Description { get; set; }
        public Standard Standard { get; set; }
    }
    
    public enum Gender
    {
        Male,
        Female
    }
}
