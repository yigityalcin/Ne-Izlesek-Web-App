namespace ne_izlesek_Web_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Veritabani4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diziler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfSerie = c.String(nullable: false),
                        Years = c.String(nullable: false),
                        Genre = c.String(nullable: false),
                        SerieRating = c.String(nullable: false),
                        Votes = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Diziler");
        }
    }
}
