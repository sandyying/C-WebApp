namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _83t528743 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "AvgRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "AvgRating", c => c.String());
        }
    }
}
