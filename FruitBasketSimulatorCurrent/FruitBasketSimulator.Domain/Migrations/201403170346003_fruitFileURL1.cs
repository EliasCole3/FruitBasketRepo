namespace FruitBasketSimulator.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fruitFileURL1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bananas", "FileURL", c => c.String());
            AddColumn("dbo.Grapes", "FileURL", c => c.String());
            AddColumn("dbo.Kiwis", "FileURL", c => c.String());
            AddColumn("dbo.Melons", "FileURL", c => c.String());
            AddColumn("dbo.Oranges", "FileURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Oranges", "FileURL");
            DropColumn("dbo.Melons", "FileURL");
            DropColumn("dbo.Kiwis", "FileURL");
            DropColumn("dbo.Grapes", "FileURL");
            DropColumn("dbo.Bananas", "FileURL");
        }
    }
}
