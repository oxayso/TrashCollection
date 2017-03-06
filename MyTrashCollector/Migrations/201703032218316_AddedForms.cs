namespace MyTrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Street", c => c.String());
            AddColumn("dbo.AspNetUsers", "ZipCode", c => c.String());
            AddColumn("dbo.AspNetUsers", "Day_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Day_Id");
            AddForeignKey("dbo.AspNetUsers", "Day_Id", "dbo.Days", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Day_Id", "dbo.Days");
            DropIndex("dbo.AspNetUsers", new[] { "Day_Id" });
            DropColumn("dbo.AspNetUsers", "Day_Id");
            DropColumn("dbo.AspNetUsers", "ZipCode");
            DropColumn("dbo.AspNetUsers", "Street");
        }
    }
}
