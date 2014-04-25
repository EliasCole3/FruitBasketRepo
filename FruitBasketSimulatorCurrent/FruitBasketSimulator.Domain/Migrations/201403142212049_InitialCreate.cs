namespace FruitBasketSimulator.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.FruitBaskets",
                c => new
                    {
                        FruitBasketId = c.Int(nullable: false, identity: true),
                        size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FruitBasketId);
            
            CreateTable(
                "dbo.Apples",
                c => new
                    {
                        AppleId = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        Type = c.String(),
                        FruitBasket_FruitBasketId = c.Int(),
                    })
                .PrimaryKey(t => t.AppleId)
                .ForeignKey("dbo.FruitBaskets", t => t.FruitBasket_FruitBasketId)
                .Index(t => t.FruitBasket_FruitBasketId);
            
            CreateTable(
                "dbo.Bananas",
                c => new
                    {
                        BananaId = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        NumberOfSpots = c.Int(nullable: false),
                        FruitBasket_FruitBasketId = c.Int(),
                    })
                .PrimaryKey(t => t.BananaId)
                .ForeignKey("dbo.FruitBaskets", t => t.FruitBasket_FruitBasketId)
                .Index(t => t.FruitBasket_FruitBasketId);
            
            CreateTable(
                "dbo.Grapes",
                c => new
                    {
                        GrapesId = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        FruitBasket_FruitBasketId = c.Int(),
                    })
                .PrimaryKey(t => t.GrapesId)
                .ForeignKey("dbo.FruitBaskets", t => t.FruitBasket_FruitBasketId)
                .Index(t => t.FruitBasket_FruitBasketId);
            
            CreateTable(
                "dbo.Kiwis",
                c => new
                    {
                        KiwiId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        FruitBasket_FruitBasketId = c.Int(),
                    })
                .PrimaryKey(t => t.KiwiId)
                .ForeignKey("dbo.FruitBaskets", t => t.FruitBasket_FruitBasketId)
                .Index(t => t.FruitBasket_FruitBasketId);
            
            CreateTable(
                "dbo.Melons",
                c => new
                    {
                        MelonId = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        Type = c.String(),
                        FruitBasket_FruitBasketId = c.Int(),
                    })
                .PrimaryKey(t => t.MelonId)
                .ForeignKey("dbo.FruitBaskets", t => t.FruitBasket_FruitBasketId)
                .Index(t => t.FruitBasket_FruitBasketId);
            
            CreateTable(
                "dbo.Oranges",
                c => new
                    {
                        OrangeId = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        Type = c.String(),
                        FruitBasket_FruitBasketId = c.Int(),
                    })
                .PrimaryKey(t => t.OrangeId)
                .ForeignKey("dbo.FruitBaskets", t => t.FruitBasket_FruitBasketId)
                .Index(t => t.FruitBasket_FruitBasketId);
            
            CreateTable(
                "dbo.RegisteredUsers",
                c => new
                    {
                        RegisteredUserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        AccessLevel = c.Int(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.RegisteredUserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        AccessLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oranges", "FruitBasket_FruitBasketId", "dbo.FruitBaskets");
            DropForeignKey("dbo.Melons", "FruitBasket_FruitBasketId", "dbo.FruitBaskets");
            DropForeignKey("dbo.Kiwis", "FruitBasket_FruitBasketId", "dbo.FruitBaskets");
            DropForeignKey("dbo.Grapes", "FruitBasket_FruitBasketId", "dbo.FruitBaskets");
            DropForeignKey("dbo.Bananas", "FruitBasket_FruitBasketId", "dbo.FruitBaskets");
            DropForeignKey("dbo.Apples", "FruitBasket_FruitBasketId", "dbo.FruitBaskets");
            DropIndex("dbo.Oranges", new[] { "FruitBasket_FruitBasketId" });
            DropIndex("dbo.Melons", new[] { "FruitBasket_FruitBasketId" });
            DropIndex("dbo.Kiwis", new[] { "FruitBasket_FruitBasketId" });
            DropIndex("dbo.Grapes", new[] { "FruitBasket_FruitBasketId" });
            DropIndex("dbo.Bananas", new[] { "FruitBasket_FruitBasketId" });
            DropIndex("dbo.Apples", new[] { "FruitBasket_FruitBasketId" });
            DropTable("dbo.Users");
            DropTable("dbo.RegisteredUsers");
            DropTable("dbo.Oranges");
            DropTable("dbo.Melons");
            DropTable("dbo.Kiwis");
            DropTable("dbo.Grapes");
            DropTable("dbo.Bananas");
            DropTable("dbo.Apples");
            DropTable("dbo.FruitBaskets");
            DropTable("dbo.Admins");
        }
    }
}
