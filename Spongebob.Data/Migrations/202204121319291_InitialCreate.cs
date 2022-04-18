namespace Spongebob.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        CharacterName = c.String(nullable: false),
                        CharacterDescription = c.String(nullable: false),
                        CharacterJob = c.String(nullable: false),
                        PlaceId = c.Int(),
                        InventoryId = c.Int(),

                })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.Place", t => t.PlaceId)
                .Index(t => t.PlaceId);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ItemId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                    
                })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ItemName = c.String(nullable: false),
                        ItemDescription = c.String(nullable: false),
                        ItemIsCool = c.Boolean(nullable: false),
                        
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.Place",
                c => new
                    {
                        PlaceId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        PlaceName = c.String(nullable: false),
                        PlaceDescription = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    
                })
                .PrimaryKey(t => t.PlaceId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Character", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.Inventory", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Inventory", "CharacterId", "dbo.Character");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Inventory", new[] { "CharacterId" });
            DropIndex("dbo.Inventory", new[] { "ItemId" });
            DropIndex("dbo.Character", new[] { "PlaceId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Place");
            DropTable("dbo.Item");
            DropTable("dbo.Inventory");
            DropTable("dbo.Character");
        }
    }
}
