namespace LICENTA4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdCreator : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "IdCreator", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "IdCreator");
        }
    }
}
