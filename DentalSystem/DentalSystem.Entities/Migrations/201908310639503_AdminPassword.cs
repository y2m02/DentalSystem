namespace DentalSystem.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminPassword : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminPassword",
                c => new
                    {
                        AdminPasswordId = c.Int(nullable: false, identity: true),
                        Password = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AdminPasswordId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminPassword");
        }
    }
}
