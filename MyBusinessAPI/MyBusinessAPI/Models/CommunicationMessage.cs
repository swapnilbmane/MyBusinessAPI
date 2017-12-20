using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessAPI.Models
{
    public class CommunicationMessage
    {
        public int CommunicationMessageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EventNotification Notification { get; set; }
        public CommunicationMessage ParentMessage { get; set; }
        public Person Createdby { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Updatedon { get; set; }
    }
}
