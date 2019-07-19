namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sjkfahkja : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Showings", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            DropColumn("dbo.Showings", "StartDate");
            DropColumn("dbo.Showings", "StartTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Showings", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Showings", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.Showings", "Date");
        }
    }
}
