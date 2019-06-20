using DentalSystem.Entities.Migrations;
using DentalSystem.Entities.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DentalSystem.Entities.Context
{
    public class DentalSystemContext:DbContext
    {
        public DentalSystemContext() : base("name=DentalSystemConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DentalSystemContext, Configuration>());
        }

        public DbSet<Rol> Rols { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientHealth> PatientHealths { get; set; }
        public DbSet<Odontogram> Odontograms { get; set; }
        public DbSet<ActivityPerformed> ActivitiesPerformed { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}