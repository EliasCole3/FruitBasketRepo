namespace FruitBasketSimulator.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appleUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apples", "FileURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Apples", "FileURL");
        }
    }
}
