namespace FruitBasketSimulator.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminPage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegisteredUsers", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.RegisteredUsers", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegisteredUsers", "Password", c => c.String());
            AlterColumn("dbo.RegisteredUsers", "Username", c => c.String());
        }
    }
}
