namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23u324y1iu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CreditCardNumber", c => c.String());
            AddColumn("dbo.Orders", "CardType", c => c.String());
            AddColumn("dbo.Orders", "ExpirationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "CardHolder", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CardHolder");
            DropColumn("dbo.Orders", "ExpirationDate");
            DropColumn("dbo.Orders", "CardType");
            DropColumn("dbo.Orders", "CreditCardNumber");
        }
    }
}
