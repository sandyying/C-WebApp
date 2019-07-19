namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9787 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Showings", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "Actors", c => c.String());
            AlterColumn("dbo.Showings", "Location", c => c.String());
            DropColumn("dbo.Showings", "Date");
            DropColumn("dbo.Showings", "Runtime");
            DropColumn("dbo.Showings", "Pending");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Showings", "Pending", c => c.Int(nullable: false));
            AddColumn("dbo.Showings", "Runtime", c => c.Int(nullable: false));
            AddColumn("dbo.Showings", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Showings", "Location", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Actors", c => c.String(nullable: false));
            DropColumn("dbo.Showings", "EndTime");
        }
    }
}
