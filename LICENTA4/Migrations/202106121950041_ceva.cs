namespace LICENTA4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ceva : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "DateRelease", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "DateRelease", c => c.DateTime(nullable: true));
        }
    }
}
