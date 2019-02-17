namespace MedicalCenterApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MedicalCenterApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            CommandTimeout = 3600;

            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
            SetSqlGenerator(MySql.Data.Entity.MySqlProviderInvariantName.ProviderName, new MySql.Data.Entity.MySqlMigrationSqlGenerator());
            SetHistoryContextFactory(MySql.Data.Entity.MySqlProviderInvariantName.ProviderName, (connection, schema) => new MySql.Data.Entity.MySqlHistoryContext(connection, schema));
        }

        protected override void Seed(MedicalCenterApplication.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
