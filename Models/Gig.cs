using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseProject.Models
{
    public class Gig
    {
        public int id { get; set; }

        public bool  IsCanceled { get; set; }

        public ApplicationUser Artist { get; set; }
        [Required]
        public String ArtistID { get; set; }
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre genre { get; set; }
        [Required]
        public byte GenreID { get; set; }
    }   
}