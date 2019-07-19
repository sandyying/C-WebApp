namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "MPAARating", c => c.String());
            AlterColumn("dbo.Movies", "Revenue", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Revenue", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "MPAARating", c => c.Int(nullable: false));
        }
    }
}
