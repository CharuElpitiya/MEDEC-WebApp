using System;
using System.Collections.Generic;

namespace MedicalCenterApplication.Models
{
    public partial class Settlements
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int DoctorId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PayedAt { get; set; }

        public Clinic Clinic { get; set; }
        public Doctors Doctor { get; set; }
    }
}
