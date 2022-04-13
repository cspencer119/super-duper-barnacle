namespace Spongebob.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Character", "PlaceId", "dbo.Place");
            DropIndex("dbo.Character", new[] { "PlaceId" });
            CreateTable(
                "dbo.Hangouts",
                c => new
                    {
                        HangoutsId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        PlaceId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HangoutsId)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Place", t => t.PlaceId, cascadeDelete: true)
                .Index(t => t.PlaceId)
                .Index(t => t.CharacterId);
            
            AddColumn("dbo.Item", "InventoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Place", "Character_CharacterId", c => c.Int());
            CreateIndex("dbo.Place", "Character_CharacterId");
            AddForeignKey("dbo.Place", "Character_CharacterId", "dbo.Character", "CharacterId");
            DropColumn("dbo.Character", "PlaceId");
            DropColumn("dbo.Character", "InventoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Character", "InventoryId", c => c.Int());
            AddColumn("dbo.Character", "PlaceId", c => c.Int());
            DropForeignKey("dbo.Hangouts", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.Place", "Character_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Hangouts", "CharacterId", "dbo.Character");
            DropIndex("dbo.Place", new[] { "Character_CharacterId" });
            DropIndex("dbo.Hangouts", new[] { "CharacterId" });
            DropIndex("dbo.Hangouts", new[] { "PlaceId" });
            DropColumn("dbo.Place", "Character_CharacterId");
            DropColumn("dbo.Item", "InventoryId");
            DropTable("dbo.Hangouts");
            CreateIndex("dbo.Character", "PlaceId");
            AddForeignKey("dbo.Character", "PlaceId", "dbo.Place", "PlaceId");
        }
    }
}
