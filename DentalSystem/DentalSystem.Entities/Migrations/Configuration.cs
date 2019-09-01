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
            //context.Users.AddOrUpdate(x => x.UserId,
            //    new User
            //    {
            //     UserId = 1,
            //     FullName = "Dra. Ram�rez",
            //     Gender = "F",
            //     UserName = "rram�rez",
            //     Password = "12345"
            //    }
            //);
            //context.AdminPasswords.AddOrUpdate(x => x.AdminPasswordId,
            //    new Models.AdminPassword {Password = "12345"}
            //);
        }
    }
}