namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7483 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderDetails", "DayOfWeek");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "DayOfWeek", c => c.Int(nullable: false));
        }
    }
}
