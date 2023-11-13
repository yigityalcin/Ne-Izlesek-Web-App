using ne_izlesek_Web_App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ne_izlesek_Web_App.Models.MoviesModel
{
    public class MovieIndexViewModel
    {
        public List<Film> Filmler { get; set; }

        public Film Film { get; set; }

        public int PageSize { get; set; } // Ekledik
        public int CurrentPage { get; set; } // Ekledik
        public int TotalRecords { get; set; } // Ekledik
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize); // Ekledik
    }
}
