namespace FruitBasketSimulator.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FruitBasketPropertiesRUserFruitBasketList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FruitBaskets", "RegisteredUser_RegisteredUserId", c => c.Int());
            CreateIndex("dbo.FruitBaskets", "RegisteredUser_RegisteredUserId");
            AddForeignKey("dbo.FruitBaskets", "RegisteredUser_RegisteredUserId", "dbo.RegisteredUsers", "RegisteredUserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FruitBaskets", "RegisteredUser_RegisteredUserId", "dbo.RegisteredUsers");
            DropIndex("dbo.FruitBaskets", new[] { "RegisteredUser_RegisteredUserId" });
            DropColumn("dbo.FruitBaskets", "RegisteredUser_RegisteredUserId");
        }
    }
}
