namespace ne_izlesek_Web_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Veritabani7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Filmler", "PhotoPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Filmler", "PhotoPath");
        }
    }
}
