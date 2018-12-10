namespace Plant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedQuantityToCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cart", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cart", "Quantity");
        }
    }
}
