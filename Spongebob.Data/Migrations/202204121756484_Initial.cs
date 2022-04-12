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
            AddColumn("dbo.Character", "InventoryId", c => c.Int());
            AddColumn("dbo.Item", "InventoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Character", "PlaceId", c => c.Int());
            CreateIndex("dbo.Character", "PlaceId");
            AddForeignKey("dbo.Character", "PlaceId", "dbo.Place", "PlaceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Character", "PlaceId", "dbo.Place");
            DropIndex("dbo.Character", new[] { "PlaceId" });
            AlterColumn("dbo.Character", "PlaceId", c => c.Int(nullable: false));
            DropColumn("dbo.Item", "InventoryId");
            DropColumn("dbo.Character", "InventoryId");
            CreateIndex("dbo.Character", "PlaceId");
            AddForeignKey("dbo.Character", "PlaceId", "dbo.Place", "PlaceId", cascadeDelete: true);
        }
    }
}
