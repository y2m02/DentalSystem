using System.Data.Entity.Migrations;
using DentalSystem.Entities.Context;

namespace DentalSystem.Entities.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DentalSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DentalSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}