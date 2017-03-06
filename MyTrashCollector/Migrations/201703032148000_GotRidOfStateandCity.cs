namespace MyTrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GotRidOfStateandCity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            DropColumn("dbo.Addresses", "City");
            DropColumn("dbo.Addresses", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "State", c => c.String());
            AddColumn("dbo.Addresses", "City", c => c.String());
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
