using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.Notifications
{
    public class Notification
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public NotificationTypes Type { get; set; }
    }
}
