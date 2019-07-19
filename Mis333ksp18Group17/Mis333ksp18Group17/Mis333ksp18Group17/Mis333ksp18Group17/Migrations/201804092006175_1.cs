namespace Mis333ksp18Group17.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Showings",
                c => new
                    {
                        ShowingID = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Movie_MovieID = c.Int(),
                    })
                .PrimaryKey(t => t.ShowingID)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieID)
                .Index(t => t.Movie_MovieID);
            
            AddColumn("dbo.OrderDetails", "Order_OrderID", c => c.Int());
            AddColumn("dbo.OrderDetails", "Showing_ShowingID", c => c.Int());
            AlterColumn("dbo.Movies", "MPAARating", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "Order_OrderID");
            CreateIndex("dbo.OrderDetails", "Showing_ShowingID");
            AddForeignKey("dbo.OrderDetails", "Order_OrderID", "dbo.Orders", "OrderID");
            AddForeignKey("dbo.OrderDetails", "Showing_ShowingID", "dbo.Showings", "ShowingID");
            DropColumn("dbo.Orders", "CVV");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CVV", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderDetails", "Showing_ShowingID", "dbo.Showings");
            DropForeignKey("dbo.OrderDetails", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Showings", "Movie_MovieID", "dbo.Movies");
            DropIndex("dbo.OrderDetails", new[] { "Showing_ShowingID" });
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderID" });
            DropIndex("dbo.Showings", new[] { "Movie_MovieID" });
            AlterColumn("dbo.Movies", "MPAARating", c => c.String());
            DropColumn("dbo.OrderDetails", "Showing_ShowingID");
            DropColumn("dbo.OrderDetails", "Order_OrderID");
            DropTable("dbo.Showings");
        }
    }
}
