using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalCenterApplication.Models
{
    public class Clinic
    {
        public Clinic()
        {
            Appointments = new HashSet<Appointments>();
            ClinicInventories = new HashSet<ClinicInventories>();
            Sessions = new HashSet<Sessions>();
            Settlements = new HashSet<Settlements>();
            SubscriptionInvoices = new HashSet<SubscriptionInvoices>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string RegNo { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? SubscribedAt { get; set; }
        public string BillingCycle { get; set; }
        public bool? IsActive { get; set; }
        public ICollection<Appointments> Appointments { get; set; }
        public ICollection<ClinicInventories> ClinicInventories { get; set; }
        public ICollection<Sessions> Sessions { get; set; }
        public ICollection<Settlements> Settlements { get; set; }
        public ICollection<SubscriptionInvoices> SubscriptionInvoices { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}