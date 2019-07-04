namespace ASP_Vidly_Udemy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToMemberShipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
