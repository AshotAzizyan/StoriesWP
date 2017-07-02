namespace DataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumneNameChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stories", "Title", c => c.String(nullable: false, maxLength: 40));
            DropColumn("dbo.Stories", "Titel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stories", "Titel", c => c.String(nullable: false, maxLength: 40));
            DropColumn("dbo.Stories", "Title");
        }
    }
}
