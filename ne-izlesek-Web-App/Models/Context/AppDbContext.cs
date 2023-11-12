using ne_izlesek_Web_App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ne_izlesek_Web_App.Models.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext():base("Server=.;Database=NeIzlesekDB;Trusted_Connection=true")
        {
               
        }
        public DbSet<Film> Filmler { get; set; }
        public DbSet<Dizi> Diziler { get; set; }

    }
}
