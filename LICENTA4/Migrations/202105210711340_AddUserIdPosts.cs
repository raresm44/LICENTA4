namespace LICENTA4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdPosts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "UserId", c => c.String());
            DropColumn("dbo.Posts", "IdCreator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "IdCreator", c => c.String());
            DropColumn("dbo.Posts", "UserId");
        }
    }
}
