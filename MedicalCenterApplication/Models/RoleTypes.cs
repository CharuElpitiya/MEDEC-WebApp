using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalCenterApplication.Models
{
    public class RoleTypes
    {
        public enum Role
        {
            Administrator,
            Patient,
            Manager,
            Doctor,
            AppointmentManager,
            Pharmacist,
            PaymentManager
        }

        public const string Administrator = "Administrator";
        public const string Patient = "Patient";
        public const string Manager = "Manager";
        public const string Doctor = "Doctor";
        public const string AppointmentManager = "AppointmentManager";
        public const string Pharmacist = "Pharmacist";
        public const string PaymentManager = "PaymentManager";
    }
}