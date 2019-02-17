using System;
using System.Collections.Generic;

namespace MedicalCenterApplication.Models
{
    public partial class Inventories
    {
        public Inventories()
        {
            ClinicInventories = new HashSet<ClinicInventories>();
            Prescriptions = new HashSet<Prescriptions>();
        }

        public int Id { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string GenericName { get; set; }
        public string BrandName { get; set; }
        public string StorageTemperature { get; set; }
        public string Manufacturer { get; set; }
        public string Strength { get; set; }
        public string Notes { get; set; }

        public Users AddedByNavigation { get; set; }
        public Users UpdatedByNavigation { get; set; }
        public ICollection<ClinicInventories> ClinicInventories { get; set; }
        public ICollection<Prescriptions> Prescriptions { get; set; }
    }
}
