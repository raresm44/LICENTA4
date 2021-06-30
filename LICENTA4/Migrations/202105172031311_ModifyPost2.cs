namespace LICENTA4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyPost2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Image");
        }
    }
}
