namespace LICENTA4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlatformToPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Platform_Id", c => c.Int());
            CreateIndex("dbo.Posts", "Platform_Id");
            AddForeignKey("dbo.Posts", "Platform_Id", "dbo.Platforms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Platform_Id", "dbo.Platforms");
            DropIndex("dbo.Posts", new[] { "Platform_Id" });
            DropColumn("dbo.Posts", "Platform_Id");
        }
    }
}
