namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsfja : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "MovieTitle", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "MovieTitle");
        }
    }
}
