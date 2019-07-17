using DentalSystem.Entities.Migrations;
using DentalSystem.Entities.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DentalSystem.Entities.Context
{
    public class DentalSystemContext:DbContext
    {
        public DentalSystemContext() : base("name=DentalSystemConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DentalSystemContext, Configuration>());
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientHealth> PatientHealths { get; set; }
        public DbSet<Odontogram> Odontograms { get; set; }
        public DbSet<ActivityPerformed> ActivitiesPerformed { get; set; }
        public DbSet<AccountsReceivable> AccountsReceivables { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class PatientMappings : EntityTypeConfiguration<Patient>
    {
        public PatientMappings()
        {
            HasRequired(c => c.PatientHealth).WithRequiredPrincipal(e => e.Patient);
            HasRequired(c => c.AccountsReceivable).WithRequiredPrincipal(e => e.Patient);
        }
    }

    public class VisitMappings : EntityTypeConfiguration<Visit>
    {
        public VisitMappings()
        {
            HasRequired(c => c.Odontogram).WithRequiredPrincipal(e => e.Visit);
        }
    }

    public class ActivityPerformedMappings : EntityTypeConfiguration<ActivityPerformed>
    {
        public ActivityPerformedMappings()
        {
            HasRequired(c => c.InvoiceDetail).WithRequiredPrincipal(e => e.ActivityPerformed);
        }
    }
}