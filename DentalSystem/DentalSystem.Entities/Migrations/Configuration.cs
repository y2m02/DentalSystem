using System.Data.Entity.Migrations;
using DentalSystem.Entities.Context;
using DentalSystem.Entities.Models;

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
            context.Users.AddOrUpdate(x => x.UserId,
                new User
                {
                 UserId = 1,
                 FullName = "Dra. Ramírez",
                 UserName = "rramírez",
                 Password = "12345"
                }
            );
        }
    }
}