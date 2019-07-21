namespace DentalSystem.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Created : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        AccountsReceivableId = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.AccountsReceivable", t => t.AccountsReceivableId, cascadeDelete: true)
                .Index(t => t.AccountsReceivableId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payment", "AccountsReceivableId", "dbo.AccountsReceivable");
            DropIndex("dbo.Payment", new[] { "AccountsReceivableId" });
            DropTable("dbo.Payment");
        }
    }
}
