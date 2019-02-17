using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;

namespace MedicalCenterApplication.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    /// <summary>
    /// When you want to scaffold Controllers and Views,
    /// (1) Comment out line -> [DbConfigurationType(typeof(MySqlEFConfiguration))]
    /// (2) Change -> public class ApplicationDbContext : IdentityDbContext<Users>
    /// (3) Comment out connection string with providerName="MySql.Data.MySqlClient" and uncomment connection string with providerName="System.Data.SqlClient"
    /// (4) Clean and Rebuild
    /// (5) After scaffolding revert back everything.
    /// (6) Clean and Rebuild
    /// </summary>
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Properties().Where(x =>
                    x.PropertyType.FullName != null && 
                    (x.PropertyType.FullName.Equals("System.String") && 
                    !x.GetCustomAttributes(false).OfType<ColumnAttribute>().Any(q => q.TypeName != null && 
                    q.TypeName.Equals("varchar(max)", StringComparison.InvariantCultureIgnoreCase)))).Configure(c =>
                    c.HasColumnType("varchar(65000)"));

            modelBuilder.Properties().Where(x =>
                    x.PropertyType.FullName != null &&
                    (x.PropertyType.FullName.Equals("System.String") &&
                    !x.GetCustomAttributes(false).OfType<ColumnAttribute>().Any(q => q.TypeName != null &&
                    q.TypeName.Equals("nvarchar", StringComparison.InvariantCultureIgnoreCase)))).Configure(c =>
                    c.HasColumnType("varchar"));


        }

        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<ClinicInventories> ClinicInventories { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Inventories> Inventories { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Prescriptions> Prescriptions { get; set; }
        public DbSet<Sessions> Sessions { get; set; }
        public DbSet<Settlements> Settlements { get; set; }
        public DbSet<SubscriptionInvoices> SubscriptionInvoices { get; set; }
    }
}