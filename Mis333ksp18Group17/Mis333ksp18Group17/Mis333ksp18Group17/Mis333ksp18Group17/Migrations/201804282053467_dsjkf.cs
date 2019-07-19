namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsjkf : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "CardType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CardType", c => c.String());
        }
    }
}
