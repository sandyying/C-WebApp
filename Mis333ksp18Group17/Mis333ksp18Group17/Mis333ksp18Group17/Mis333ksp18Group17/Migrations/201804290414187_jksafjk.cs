namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jksafjk : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reviews", "MovieTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "MovieTitle", c => c.String(nullable: false));
        }
    }
}
