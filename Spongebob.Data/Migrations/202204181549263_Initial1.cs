namespace Spongebob.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Character", "IsSeedList", c => c.Boolean(nullable: false));
            AddColumn("dbo.Hangouts", "IsSeedList", c => c.Boolean(nullable: false));
            AddColumn("dbo.Place", "IsSeedList", c => c.Boolean(nullable: false));
            AddColumn("dbo.Inventory", "IsSeedList", c => c.Boolean(nullable: false));
            AddColumn("dbo.Item", "IsSeedList", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "IsSeedList");
            DropColumn("dbo.Inventory", "IsSeedList");
            DropColumn("dbo.Place", "IsSeedList");
            DropColumn("dbo.Hangouts", "IsSeedList");
            DropColumn("dbo.Character", "IsSeedList");
        }
    }
}
