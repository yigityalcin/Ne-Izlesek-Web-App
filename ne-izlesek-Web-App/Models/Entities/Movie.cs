using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace ne_izlesek_Web_App.Models.Entities
{
    [Table("Filmler")]
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NameOfMovie { get; set; }

        [Required]
        public string YearOfRelease { get; set; }

        public string Watchtime { get; set; }

        [Required]
        public string Genre {  get; set; }

        [Required]
        public string MovieRating { get; set; }

        public string Metascore { get; set; }

        [Required]
        public string Votes { get; set; }

        public string GrossCollection { get; set; }

        public string Description { get; set; }

        [Required]
        public string Director { get; set; }

        public List<string> Star { get; set; } = new List<string>();

        // Diğer özellikleri buraya ekleyin
    }
}
