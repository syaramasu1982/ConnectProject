using System;
using System.Collections.Generic;
using System.Text;

namespace Uksbs.Connect.AutomatedTests.Common
{
    public class NotificationCentre
    {
        public List<Notification> Notifications { get; set; }
    }
    public class Notification
    {
        public string Title { get; set; }
        public string DateWithDay { get; set; }
        public string FromWhom { get; set; }
        public string HeadsUpMessage { get; set; }
        public string Status { get; set; }
        public string ElementId { get; set; }
    }
}
