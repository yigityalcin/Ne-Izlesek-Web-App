using ne_izlesek_Web_App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ne_izlesek_Web_App.Models.MoviesModel
{
    public class SerieIndexViewModel
    {
        public List<Dizi> Diziler { get; set; }

        public Dizi Dizi { get; set; }


        public int PageSize { get; set; } // Ekledik
        public int CurrentPage { get; set; } // Ekledik
        public int TotalRecords { get; set; } // Ekledik
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize); // Ekledik
    }
}
