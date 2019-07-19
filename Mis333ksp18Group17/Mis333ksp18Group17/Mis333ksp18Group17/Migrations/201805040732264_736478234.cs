namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _736478234 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "Approve", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "UpVote", c => c.Int());
            AddColumn("dbo.Reviews", "DownVote", c => c.Int());
            DropColumn("dbo.Reviews", "Vote");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "Vote", c => c.Boolean(nullable: false));
            DropColumn("dbo.Reviews", "DownVote");
            DropColumn("dbo.Reviews", "UpVote");
            DropColumn("dbo.Reviews", "Approve");
        }
    }
}
