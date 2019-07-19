namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _83444 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Showings", "SpecialEvent", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "AvgRating", c => c.Double());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Birthday", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "State", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "ZipCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ZipCode", c => c.String());
            AlterColumn("dbo.AspNetUsers", "State", c => c.String());
            AlterColumn("dbo.AspNetUsers", "City", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Street", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Birthday", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            DropColumn("dbo.Movies", "AvgRating");
            DropColumn("dbo.Showings", "SpecialEvent");
        }
    }
}
