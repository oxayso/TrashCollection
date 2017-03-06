namespace MyTrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedZipCodeToAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "ZipCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "ZipCode");
        }
    }
}
