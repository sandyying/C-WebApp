namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _723524375243 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "ExpirationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "ExpirationDate", c => c.DateTime(nullable: false));
        }
    }
}
