namespace Plant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameChangeForUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cart", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Request", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Cart", "UserId");
            DropColumn("dbo.Request", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Request", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Cart", "UserId", c => c.Guid(nullable: false));
            DropColumn("dbo.Request", "OwnerId");
            DropColumn("dbo.Cart", "OwnerId");
        }
    }
}
