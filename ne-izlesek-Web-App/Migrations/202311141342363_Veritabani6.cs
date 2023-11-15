namespace ne_izlesek_Web_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Veritabani6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Filmler", "Watchtime", c => c.Double(nullable: false));
            AlterColumn("dbo.Filmler", "MovieRating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Filmler", "MovieRating", c => c.String(nullable: false));
            AlterColumn("dbo.Filmler", "Watchtime", c => c.String());
        }
    }
}
