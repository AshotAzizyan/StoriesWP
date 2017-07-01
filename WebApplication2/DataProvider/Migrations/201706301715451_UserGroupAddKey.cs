namespace DataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserGroupAddKey : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserGroups", newName: "UserGroup1");
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserGroups");
            RenameTable(name: "dbo.UserGroup1", newName: "UserGroups");
        }
    }
}
