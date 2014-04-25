namespace FruitBasketSimulator.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cleanup31914 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Admins");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        AccessLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        AccessLevel = c.Int(nullable: false),
                        Password = c.String(),
                        Handle = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
        }
    }
}
