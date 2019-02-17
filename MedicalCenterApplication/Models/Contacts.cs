using System;
using System.Collections.Generic;

namespace MedicalCenterApplication.Models
{
    public partial class Contacts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}
