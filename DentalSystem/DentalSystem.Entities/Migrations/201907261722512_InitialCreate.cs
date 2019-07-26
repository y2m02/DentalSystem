namespace DentalSystem.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountsReceivable",
                c => new
                    {
                        AccountsReceivableId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        TotalPaid = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccountsReceivableId)
                .ForeignKey("dbo.Patient", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Visit", t => t.AccountsReceivableId)
                .Index(t => t.AccountsReceivableId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100),
                        IdentificationCard = c.String(maxLength: 15),
                        Age = c.Int(),
                        Gender = c.String(maxLength: 1),
                        BirthDate = c.DateTime(),
                        PhoneNumber = c.String(maxLength: 10),
                        Address = c.String(maxLength: 200),
                        Sector = c.String(maxLength: 100),
                        IsUrbanZone = c.Boolean(),
                        HasInsurancePlan = c.Boolean(),
                        NSS = c.String(maxLength: 100),
                        AdmissionDate = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.PatientId);
            
            CreateTable(
                "dbo.PatientHealth",
                c => new
                    {
                        PatientHealthId = c.Int(nullable: false),
                        HasBronchialAsthma = c.Boolean(),
                        HasRenalDisease = c.Boolean(),
                        HasBeenSickRecently = c.Boolean(),
                        DiseaseCause = c.String(maxLength: 200),
                        HasAllergy = c.Boolean(),
                        HeartValve = c.Boolean(),
                        IsEpileptic = c.Boolean(),
                        HasHeartMurmur = c.Boolean(),
                        HasAnemia = c.Boolean(),
                        HasDiabeticParents = c.Boolean(),
                        HasTuberculosis = c.Boolean(),
                        HasBleeding = c.Boolean(),
                        HasHepatitis = c.Boolean(),
                        HasAllergicReaction = c.Boolean(),
                    })
                .PrimaryKey(t => t.PatientHealthId)
                .ForeignKey("dbo.Patient", t => t.PatientHealthId)
                .Index(t => t.PatientHealthId);
            
            CreateTable(
                "dbo.PlateRegistration",
                c => new
                    {
                        PlateRegistrationId = c.Int(nullable: false),
                        PDB = c.String(maxLength: 30),
                        N16 = c.String(maxLength: 30),
                        N11 = c.String(maxLength: 30),
                        N26 = c.String(maxLength: 30),
                        N36 = c.String(maxLength: 30),
                        N32 = c.String(maxLength: 30),
                        N46 = c.String(maxLength: 30),
                        CT = c.String(maxLength: 30),
                        X = c.String(maxLength: 30),
                        RadiographicInterpretation = c.String(maxLength: 400),
                    })
                .PrimaryKey(t => t.PlateRegistrationId)
                .ForeignKey("dbo.Patient", t => t.PlateRegistrationId)
                .Index(t => t.PlateRegistrationId);
            
            CreateTable(
                "dbo.Visit",
                c => new
                    {
                        VisitId = c.Int(nullable: false, identity: true),
                        VisitNumber = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        HasEnded = c.Boolean(),
                        HasBeenBilled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VisitId)
                .ForeignKey("dbo.Patient", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.ActivityPerformed",
                c => new
                    {
                        ActivityPerformedId = c.Int(nullable: false, identity: true),
                        Responsable = c.String(maxLength: 100),
                        VisitId = c.Int(nullable: false),
                        Section = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 100),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ActivityPerformedId)
                .ForeignKey("dbo.Visit", t => t.VisitId, cascadeDelete: true)
                .Index(t => t.VisitId);
            
            CreateTable(
                "dbo.InvoiceDetail",
                c => new
                    {
                        InvoiceDetailId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.InvoiceDetailId)
                .ForeignKey("dbo.ActivityPerformed", t => t.InvoiceDetailId)
                .Index(t => t.InvoiceDetailId);
            
            CreateTable(
                "dbo.Odontogram",
                c => new
                    {
                        OdontogramId = c.Int(nullable: false, identity: true),
                        VisitId = c.Int(nullable: false),
                        Information = c.String(),
                        CavitiesQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OdontogramId)
                .ForeignKey("dbo.Visit", t => t.VisitId, cascadeDelete: true)
                .Index(t => t.VisitId);
            
            CreateTable(
                "dbo.TreatmentOdontogram",
                c => new
                    {
                        TreatmentOdontogramId = c.Int(nullable: false),
                        Information = c.String(),
                        CavitiesQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TreatmentOdontogramId)
                .ForeignKey("dbo.Odontogram", t => t.TreatmentOdontogramId)
                .Index(t => t.TreatmentOdontogramId);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        AccountsReceivableId = c.Int(nullable: false),
                        AmountPaid = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.AccountsReceivable", t => t.AccountsReceivableId, cascadeDelete: true)
                .Index(t => t.AccountsReceivableId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountsReceivable", "AccountsReceivableId", "dbo.Visit");
            DropForeignKey("dbo.Payment", "AccountsReceivableId", "dbo.AccountsReceivable");
            DropForeignKey("dbo.AccountsReceivable", "PatientId", "dbo.Patient");
            DropForeignKey("dbo.Visit", "PatientId", "dbo.Patient");
            DropForeignKey("dbo.Odontogram", "VisitId", "dbo.Visit");
            DropForeignKey("dbo.TreatmentOdontogram", "TreatmentOdontogramId", "dbo.Odontogram");
            DropForeignKey("dbo.ActivityPerformed", "VisitId", "dbo.Visit");
            DropForeignKey("dbo.InvoiceDetail", "InvoiceDetailId", "dbo.ActivityPerformed");
            DropForeignKey("dbo.PlateRegistration", "PlateRegistrationId", "dbo.Patient");
            DropForeignKey("dbo.PatientHealth", "PatientHealthId", "dbo.Patient");
            DropIndex("dbo.Payment", new[] { "AccountsReceivableId" });
            DropIndex("dbo.TreatmentOdontogram", new[] { "TreatmentOdontogramId" });
            DropIndex("dbo.Odontogram", new[] { "VisitId" });
            DropIndex("dbo.InvoiceDetail", new[] { "InvoiceDetailId" });
            DropIndex("dbo.ActivityPerformed", new[] { "VisitId" });
            DropIndex("dbo.Visit", new[] { "PatientId" });
            DropIndex("dbo.PlateRegistration", new[] { "PlateRegistrationId" });
            DropIndex("dbo.PatientHealth", new[] { "PatientHealthId" });
            DropIndex("dbo.AccountsReceivable", new[] { "PatientId" });
            DropIndex("dbo.AccountsReceivable", new[] { "AccountsReceivableId" });
            DropTable("dbo.Payment");
            DropTable("dbo.TreatmentOdontogram");
            DropTable("dbo.Odontogram");
            DropTable("dbo.InvoiceDetail");
            DropTable("dbo.ActivityPerformed");
            DropTable("dbo.Visit");
            DropTable("dbo.PlateRegistration");
            DropTable("dbo.PatientHealth");
            DropTable("dbo.Patient");
            DropTable("dbo.AccountsReceivable");
        }
    }
}
