using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace OTPLoginTask.Models.Notifications
{
    public class NotificationModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationDescription { get; set; }
        public string NotificationTime { get; set; }
    }
}
