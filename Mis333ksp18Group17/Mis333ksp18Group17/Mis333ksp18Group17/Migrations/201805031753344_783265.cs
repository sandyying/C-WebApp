namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _783265 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardID = c.Int(nullable: false, identity: true),
                        CardHolder = c.String(nullable: false),
                        CreditCardNumber = c.String(nullable: false),
                        CardTypes = c.String(),
                        ExpirationDate = c.DateTime(nullable: false),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CreditCardID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Number = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MiddleInitial = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        SSN = c.String(),
                        PopcornPoints = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                        MoviePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(),
                        GiftOrNot = c.String(),
                        DiscountAmt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                        PaymentMethod = c.String(),
                        CreditCardNumber = c.String(),
                        CardType = c.String(),
                        ExpirationDate = c.DateTime(),
                        CardHolder = c.String(),
                        CheckOutStatus = c.Boolean(nullable: false),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CancelStatus = c.Int(nullable: false),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        SeatAssignment = c.String(),
                        DiscountType = c.String(),
                        Quantity = c.Int(nullable: false),
                        MoviePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Order_OrderID = c.Int(),
                        Showing_ShowingID = c.Int(),
                        CreditCard_CreditCardID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .ForeignKey("dbo.Showings", t => t.Showing_ShowingID)
                .ForeignKey("dbo.CreditCards", t => t.CreditCard_CreditCardID)
                .Index(t => t.Order_OrderID)
                .Index(t => t.Showing_ShowingID)
                .Index(t => t.CreditCard_CreditCardID);
            
            CreateTable(
                "dbo.Showings",
                c => new
                    {
                        ShowingID = c.Int(nullable: false, identity: true),
                        Location = c.Int(nullable: false),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        Runtime = c.Int(nullable: false),
                        MoviePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pending = c.Int(nullable: false),
                        SpecialEvent = c.Int(nullable: false),
                        Publish = c.Boolean(nullable: false),
                        ShowingCancelStatus = c.Int(nullable: false),
                        Movie_MovieID = c.Int(),
                    })
                .PrimaryKey(t => t.ShowingID)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieID)
                .Index(t => t.Movie_MovieID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.Int(nullable: false, identity: true),
                        MovieNum = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Tagline = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        MPAARating = c.Int(nullable: false),
                        Actors = c.String(nullable: false),
                        Runtime = c.Int(nullable: false),
                        Overview = c.String(nullable: false),
                        Revenue = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MovieID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        Reviews = c.String(maxLength: 100),
                        CustomerRating = c.Int(nullable: false),
                        Vote = c.Boolean(nullable: false),
                        Movie_MovieID = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieID)
                .Index(t => t.Movie_MovieID);
            
            CreateTable(
                "dbo.GenreMovies",
                c => new
                    {
                        Genre_GenreID = c.Int(nullable: false),
                        Movie_MovieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_GenreID, t.Movie_MovieID })
                .ForeignKey("dbo.Genres", t => t.Genre_GenreID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieID, cascadeDelete: true)
                .Index(t => t.Genre_GenreID)
                .Index(t => t.Movie_MovieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderDetails", "CreditCard_CreditCardID", "dbo.CreditCards");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderDetails", "Showing_ShowingID", "dbo.Showings");
            DropForeignKey("dbo.Showings", "Movie_MovieID", "dbo.Movies");
            DropForeignKey("dbo.Reviews", "Movie_MovieID", "dbo.Movies");
            DropForeignKey("dbo.GenreMovies", "Movie_MovieID", "dbo.Movies");
            DropForeignKey("dbo.GenreMovies", "Genre_GenreID", "dbo.Genres");
            DropForeignKey("dbo.OrderDetails", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CreditCards", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.GenreMovies", new[] { "Movie_MovieID" });
            DropIndex("dbo.GenreMovies", new[] { "Genre_GenreID" });
            DropIndex("dbo.Reviews", new[] { "Movie_MovieID" });
            DropIndex("dbo.Showings", new[] { "Movie_MovieID" });
            DropIndex("dbo.OrderDetails", new[] { "CreditCard_CreditCardID" });
            DropIndex("dbo.OrderDetails", new[] { "Showing_ShowingID" });
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderID" });
            DropIndex("dbo.Orders", new[] { "AppUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CreditCards", new[] { "AppUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.GenreMovies");
            DropTable("dbo.Reviews");
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
            DropTable("dbo.Showings");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CreditCards");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
