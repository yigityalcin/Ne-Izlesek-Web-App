using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace ne_izlesek_Web_App.Models.Entities
{
    [Table("Diziler")]
    public class Dizi
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NameOfSerie { get; set; }

        [Required]
        public string Years { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public double SerieRating { get; set; }

        [Required]
        public string Votes { get; set; }

        public string Description { get; set; }

    }
}
