namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _873465 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Showings", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Showings", "StartDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Showings", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Showings", "Date");
        }
    }
}
