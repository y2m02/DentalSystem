using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using DentalSystem.Entities.Migrations;
using DentalSystem.Entities.Models;

namespace DentalSystem.Entities.Context
{
    public class DentalSystemContext : DbContext
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
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PlateRegistration> PlateRegistrations { get; set; }
        public DbSet<TreatmentOdontogram> TreatmentOdontograms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Payment>().Property(w => w.AmountPaid).HasPrecision(18, 2);
            modelBuilder.Entity<InvoiceDetail>().Property(w => w.Price).HasPrecision(18, 2);
            modelBuilder.Entity<AccountsReceivable>().Property(w => w.Total).HasPrecision(18, 2);
            modelBuilder.Entity<AccountsReceivable>().Property(w => w.TotalPaid).HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class PatientMappings : EntityTypeConfiguration<Patient>
    {
        public PatientMappings()
        {
            HasRequired(c => c.PatientHealth).WithRequiredPrincipal(e => e.Patient);
            HasRequired(c => c.PlateRegistration).WithRequiredPrincipal(e => e.Patient);
        }
    }

    public class VisitMappings : EntityTypeConfiguration<Visit>
    {
        public VisitMappings()
        {
            //HasRequired(c => c.Odontogram).WithRequiredPrincipal(e => e.Visit);
            HasRequired(c => c.AccountsReceivable).WithRequiredPrincipal(e => e.Visit);
        }
    }

    public class ActivityPerformedMappings : EntityTypeConfiguration<ActivityPerformed>
    {
        public ActivityPerformedMappings()
        {
            HasRequired(c => c.InvoiceDetail).WithRequiredPrincipal(e => e.ActivityPerformed);
        }
    }

    public class OdontogramMappings : EntityTypeConfiguration<Odontogram>
    {
        public OdontogramMappings()
        {
            HasRequired(c => c.TreatmentOdontogram).WithRequiredPrincipal(e => e.Odontogram);
        }
    }
}