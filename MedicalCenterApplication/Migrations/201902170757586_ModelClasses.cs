namespace MedicalCenterApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClinicId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        SessionId = c.Int(nullable: false),
                        AppointedAt = c.DateTime(precision: 0),
                        IsPresent = c.Byte(),
                        CreatedBy = c.String(maxLength: 128, unicode: false),
                        Diagnosis = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinic", t => t.ClinicId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.ClinicId)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.SessionId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.ClinicInventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClinicId = c.Int(nullable: false),
                        InventoryId = c.Int(nullable: false),
                        ManufacturedDate = c.DateTime(precision: 0),
                        ExpiryDate = c.DateTime(precision: 0),
                        Quantity = c.Int(),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        BatchNo = c.Int(),
                        ReorderLevel = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinic", t => t.ClinicId, cascadeDelete: true)
                .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: true)
                .Index(t => t.ClinicId)
                .Index(t => t.InventoryId);

            CreateTable(
                    "dbo.Inventories",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddedBy = c.String(maxLength: 128, unicode: false),
                        UpdatedBy = c.String(maxLength: 128, unicode: false),
                        GenericName = c.String(maxLength: 1000, unicode: false),
                        BrandName = c.String(maxLength: 1000, unicode: false),
                        StorageTemperature = c.String(maxLength: 1000, unicode: false),
                        Manufacturer = c.String(maxLength: 1000, unicode: false),
                        Strength = c.String(maxLength: 1000, unicode: false),
                        Notes = c.String(maxLength: 1000, unicode: false),
                        AddedByNavigation_Id = c.String(maxLength: 128, unicode: false),
                        UpdatedByNavigation_Id = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AddedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.AddedBy)
                .Index(t => t.UpdatedBy);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, unicode: false),
                        Specialization = c.String(maxLength: 1000, unicode: false),
                        RegistrationNumber = c.String(maxLength: 1000, unicode: false),
                        Hospital = c.String(maxLength: 1000, unicode: false),
                        Notes = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClinicId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        Start = c.DateTime(precision: 0),
                        Stop = c.DateTime(precision: 0),
                        HasConducted = c.Byte(),
                        Fee = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinic", t => t.ClinicId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.ClinicId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Settlements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClinicId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        PayedAt = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinic", t => t.ClinicId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.ClinicId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, unicode: false),
                        Notification = c.String(maxLength: 1000, unicode: false),
                        Link = c.String(maxLength: 1000, unicode: false),
                        Status = c.Int(),
                        CreatedAt = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, unicode: false),
                        Nic = c.String(maxLength: 1000, unicode: false),
                        Dob = c.DateTime(precision: 0),
                        BloodGroup = c.String(maxLength: 1000, unicode: false),
                        EmergencyContactName = c.String(maxLength: 1000, unicode: false),
                        EmergencyContactPhone = c.String(maxLength: 1000, unicode: false),
                        EmergencyContactAddress = c.String(maxLength: 1000, unicode: false),
                        Notes = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentId = c.Int(nullable: false),
                        InventoryId = c.Int(nullable: false),
                        Quantity = c.Int(),
                        Dosage = c.String(maxLength: 1000, unicode: false),
                        Notes = c.String(maxLength: 1000, unicode: false),
                        IssuedAt = c.DateTime(precision: 0),
                        IsPublic = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.AppointmentId, cascadeDelete: true)
                .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: true)
                .Index(t => t.AppointmentId)
                .Index(t => t.InventoryId);
            
            CreateTable(
                "dbo.SubscriptionInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClinicId = c.Int(nullable: false),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        IssuedAt = c.DateTime(precision: 0),
                        PaidAt = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinic", t => t.ClinicId, cascadeDelete: true)
                .Index(t => t.ClinicId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentId = c.Int(),
                        Description = c.String(maxLength: 1000, unicode: false),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        PaidAt = c.DateTime(precision: 0),
                        IsReceived = c.Byte(),
                        Method = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.AppointmentId)
                .Index(t => t.AppointmentId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 1000, unicode: false),
                        Email = c.String(maxLength: 1000, unicode: false),
                        Phone = c.String(maxLength: 1000, unicode: false),
                        Message = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 1000, unicode: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(maxLength: 1000, unicode: false));
            AddColumn("dbo.AspNetUsers", "ClinicId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "VerificationCode", c => c.String(maxLength: 1000, unicode: false));
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128, storeType: "nvarchar"));
            AlterColumn("dbo.Clinic", "SubscribedAt", c => c.DateTime(precision: 0));
            AlterColumn("dbo.Clinic", "IsActive", c => c.Boolean());
            CreateIndex("dbo.AspNetUsers", "ClinicId");
            AddForeignKey("dbo.AspNetUsers", "ClinicId", "dbo.Clinic", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.SubscriptionInvoices", "ClinicId", "dbo.Clinic");
            DropForeignKey("dbo.Prescriptions", "InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Prescriptions", "AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.ClinicInventories", "InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Patients", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Notifications", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Inventories", "AddedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Inventories", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Doctors", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Settlements", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Settlements", "ClinicId", "dbo.Clinic");
            DropForeignKey("dbo.Sessions", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Sessions", "ClinicId", "dbo.Clinic");
            DropForeignKey("dbo.Appointments", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.AspNetUsers", "ClinicId", "dbo.Clinic");
            DropForeignKey("dbo.Appointments", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClinicInventories", "ClinicId", "dbo.Clinic");
            DropForeignKey("dbo.Appointments", "ClinicId", "dbo.Clinic");
            DropIndex("dbo.Payments", new[] { "AppointmentId" });
            DropIndex("dbo.SubscriptionInvoices", new[] { "ClinicId" });
            DropIndex("dbo.Prescriptions", new[] { "InventoryId" });
            DropIndex("dbo.Prescriptions", new[] { "AppointmentId" });
            DropIndex("dbo.Patients", new[] { "UserId" });
            DropIndex("dbo.Notifications", new[] { "UserId" });
            DropIndex("dbo.Settlements", new[] { "DoctorId" });
            DropIndex("dbo.Settlements", new[] { "ClinicId" });
            DropIndex("dbo.Sessions", new[] { "DoctorId" });
            DropIndex("dbo.Sessions", new[] { "ClinicId" });
            DropIndex("dbo.Doctors", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "ClinicId" });
            DropIndex("dbo.Inventories", new[] { "UpdatedBy" });
            DropIndex("dbo.Inventories", new[] { "AddedBy" });
            DropIndex("dbo.ClinicInventories", new[] { "InventoryId" });
            DropIndex("dbo.ClinicInventories", new[] { "ClinicId" });
            DropIndex("dbo.Appointments", new[] { "CreatedBy" });
            DropIndex("dbo.Appointments", new[] { "SessionId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropIndex("dbo.Appointments", new[] { "ClinicId" });
            AlterColumn("dbo.Clinic", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Clinic", "SubscribedAt", c => c.DateTime(nullable: false, precision: 0));
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "VerificationCode");
            DropColumn("dbo.AspNetUsers", "ClinicId");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.Contacts");
            DropTable("dbo.Payments");
            DropTable("dbo.SubscriptionInvoices");
            DropTable("dbo.Prescriptions");
            DropTable("dbo.Patients");
            DropTable("dbo.Notifications");
            DropTable("dbo.Settlements");
            DropTable("dbo.Sessions");
            DropTable("dbo.Doctors");
            DropTable("dbo.Inventories");
            DropTable("dbo.ClinicInventories");
            DropTable("dbo.Appointments");
        }
    }
}
