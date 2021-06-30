namespace LICENTA4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagesIntoPosts : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Posts SET Image = (SELECT * FROM OPENROWSET( BULK N'C:\\Users\\Rares\\Downloads\\witcher1.jpg', SINGLE_BLOB)as IMG)");
        }
        
        public override void Down()
        {
        }
    }
}
