using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessAPI.Models
{
    public class SchoolEvent
    {
        public int SchoolEventId { get; set; }
        public int EventType { get; set; }
        public string Title { get; set; }
        public String Description { get; set; }
        public DateTime ScheduledOn { get; set; }
        public Person CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
