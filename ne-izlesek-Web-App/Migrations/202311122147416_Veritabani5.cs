namespace ne_izlesek_Web_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Veritabani5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Diziler", "SerieRating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Diziler", "SerieRating", c => c.String(nullable: false));
        }
    }
}
