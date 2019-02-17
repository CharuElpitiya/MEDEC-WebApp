using System;
using System.Collections.Generic;

namespace MedicalCenterApplication.Models
{
    public partial class Notifications
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Notification { get; set; }
        public string Link { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Users User { get; set; }
    }
}
