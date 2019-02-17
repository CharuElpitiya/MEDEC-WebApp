using System;
using System.Collections.Generic;

namespace MedicalCenterApplication.Models
{
    public partial class ClinicInventories
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int InventoryId { get; set; }
        public DateTime? ManufacturedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? BatchNo { get; set; }
        public int? ReorderLevel { get; set; }

        public Clinic Clinic { get; set; }
        public Inventories Inventory { get; set; }
    }
}
