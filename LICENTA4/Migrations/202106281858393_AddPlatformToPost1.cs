namespace LICENTA4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlatformToPost1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Platform_Id", "dbo.Platforms");
            DropIndex("dbo.Posts", new[] { "Platform_Id" });
            RenameColumn(table: "dbo.Posts", name: "Platform_Id", newName: "PlatformId");
            AlterColumn("dbo.Posts", "PlatformId", c => c.Int(nullable: true));
            CreateIndex("dbo.Posts", "PlatformId");
            AddForeignKey("dbo.Posts", "PlatformId", "dbo.Platforms", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "PlatformId", "dbo.Platforms");
            DropIndex("dbo.Posts", new[] { "PlatformId" });
            AlterColumn("dbo.Posts", "PlatformId", c => c.Int());
            RenameColumn(table: "dbo.Posts", name: "PlatformId", newName: "Platform_Id");
            CreateIndex("dbo.Posts", "Platform_Id");
            AddForeignKey("dbo.Posts", "Platform_Id", "dbo.Platforms", "Id");
        }
    }
}
