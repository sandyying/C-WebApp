namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _63t4527 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Showings", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Showings", "StartDate");
            DropColumn("dbo.Showings", "StartTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Showings", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Showings", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Showings", "Date");
        }
    }
}
