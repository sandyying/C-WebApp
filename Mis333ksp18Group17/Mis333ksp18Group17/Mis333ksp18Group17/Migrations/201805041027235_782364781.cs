namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _782364781 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "appuser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reviews", "appuser_Id");
            AddForeignKey("dbo.Reviews", "appuser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "appuser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reviews", new[] { "appuser_Id" });
            DropColumn("dbo.Reviews", "appuser_Id");
        }
    }
}
