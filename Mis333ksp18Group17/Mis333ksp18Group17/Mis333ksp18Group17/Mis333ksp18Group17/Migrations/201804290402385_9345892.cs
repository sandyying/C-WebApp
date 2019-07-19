namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9345892 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "Reviews", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "Reviews", c => c.String());
        }
    }
}
