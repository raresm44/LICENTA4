namespace LICENTA4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyPost : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Image", c => c.String());
        }
    }
}
