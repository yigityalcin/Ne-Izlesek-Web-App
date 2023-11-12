namespace ne_izlesek_Web_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Veritabani3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Filmler", "Genre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Filmler", "Genre");
        }
    }
}
