namespace LICENTA4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aprobare : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Aprobare", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Aprobare");
        }
    }
}
