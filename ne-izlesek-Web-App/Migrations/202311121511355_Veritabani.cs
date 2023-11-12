namespace ne_izlesek_Web_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Veritabani : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfMovie = c.String(nullable: false),
                        YearOfRelease = c.String(nullable: false),
                        Watchtime = c.String(),
                        MovieRating = c.String(nullable: false),
                        Metascore = c.String(),
                        Votes = c.String(nullable: false),
                        GrossCollection = c.String(),
                        Description = c.String(),
                        Director = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
