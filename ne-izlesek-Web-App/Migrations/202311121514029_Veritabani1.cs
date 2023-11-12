namespace ne_izlesek_Web_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Veritabani1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Movies", newName: "Filmler");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Filmler", newName: "Movies");
        }
    }
}
