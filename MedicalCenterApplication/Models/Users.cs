using System;
using System.Collections.Generic;

namespace MedicalCenterApplication.Models
{
    public partial class Users : ApplicationUser
    {
        public Users()
        {
            Appointments = new HashSet<Appointments>();
            Doctors = new HashSet<Doctors>();
            InventoriesAddedByNavigation = new HashSet<Inventories>();
            InventoriesUpdatedByNavigation = new HashSet<Inventories>();
            Notifications = new HashSet<Notifications>();
            Patients = new HashSet<Patients>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public int? ClinicId { get; set; }
        public string VerificationCode { get; set; }

        public Clinic Clinic { get; set; }
        public ICollection<Appointments> Appointments { get; set; }
        public ICollection<Doctors> Doctors { get; set; }
        public ICollection<Inventories> InventoriesAddedByNavigation { get; set; }
        public ICollection<Inventories> InventoriesUpdatedByNavigation { get; set; }
        public ICollection<Notifications> Notifications { get; set; }
        public ICollection<Patients> Patients { get; set; }
    }
}
