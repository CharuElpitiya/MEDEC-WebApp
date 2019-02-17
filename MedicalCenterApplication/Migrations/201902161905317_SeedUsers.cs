namespace MedicalCenterApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO `aspnetusers` (`Id`, `Email`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEndDateUtc`, `LockoutEnabled`, `AccessFailedCount`, `UserName`, `Name`, `Address`, `ClinicId`, `VerificationCode`, `Discriminator`) VALUES
                ('47d824e9-9d36-48de-a74a-ffef58ca4ad5', 'admin@medec.lk', 0, 'ALDPllpM6lAqWKww9MmuEHEZh7SKJR5GMy4QWBKYr8u3/M490abmECkcu8VkozHZAQ==', '43cbf062-803f-4aa2-95b3-2849dc446b5b', '0115726411', 0, 0, NULL, 1, 0, 'admin', 'Administrator', 'No 13, Samagi Mawatha, Colombo 11', NULL, NULL, 'Users'),
                ('8d6caee3-0f88-4116-beed-3bb69fbab2ab', 'patient@medec.lk', 0, 'ABGIQ4y93yST91oJ+YH1xgH9ymqQr4v/F2Thvr/HUSgGWGdVCgoMyze2XGzruVwgzQ==', '5179a271-b82d-4a26-9f14-d73e34b4f8ed', '0115726411', 0, 0, NULL, 1, 0, 'patient', 'Patient User', 'Katubedda, Sri Lanka.', NULL, NULL, 'Users');

                INSERT INTO `aspnetroles` (`Id`, `Name`) VALUES
                ('8870027e-08e1-4b82-b7e3-f5043db112ee', 'Administrator'),
                ('10fbafac-9365-4f52-82da-e7a90d9b5aae', 'Patient');

                INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
                ('47d824e9-9d36-48de-a74a-ffef58ca4ad5', '8870027e-08e1-4b82-b7e3-f5043db112ee'),
                ('8d6caee3-0f88-4116-beed-3bb69fbab2ab', '10fbafac-9365-4f52-82da-e7a90d9b5aae');
                ");
        }
        
        public override void Down()
        {
        }
    }
}
