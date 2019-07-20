namespace ASP_Vidly_Udemy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentalCustomerMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RentalCustomerMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customer_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentalCustomerMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.RentalCustomerMovies", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.RentalCustomerMovies", new[] { "Movie_Id" });
            DropIndex("dbo.RentalCustomerMovies", new[] { "Customer_Id" });
            DropTable("dbo.RentalCustomerMovies");
        }
    }
}
