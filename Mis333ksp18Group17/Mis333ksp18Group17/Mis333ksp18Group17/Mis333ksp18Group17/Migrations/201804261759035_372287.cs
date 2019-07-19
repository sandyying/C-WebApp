namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _372287 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CheckOutStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CheckOutStatus");
        }
    }
}
