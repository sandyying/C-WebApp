namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Tagline = c.String(),
                        Genre = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        MPAARating = c.Int(nullable: false),
                        Actors = c.String(),
                        Runtime = c.Int(nullable: false),
                        Overview = c.String(),
                        Revenue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        SeatAssignment = c.String(),
                        MoviePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                        NumberOfTickets = c.Int(nullable: false),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalBeforeTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Receipent = c.String(),
                        Gift = c.Boolean(nullable: false),
                        PaymentMethod = c.String(nullable: false),
                        CreditCardNumber = c.String(),
                        CardType = c.String(),
                        ExpirationDate = c.DateTime(nullable: false),
                        CVV = c.Int(nullable: false),
                        CardHolder = c.String(),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Password = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleInitial = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        SSN = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        PopcornPoints = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Movies");
        }
    }
}
