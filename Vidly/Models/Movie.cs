using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Display(Name="Name")]
        [Required (ErrorMessage ="Please Enter Vaild Name")]
        [StringLength(255)]
        public string  MovieName { get; set; }


        [Display(Name ="Number In Stock")]
        public byte NumberInStock { get; set; }

        public DateTime DateAdded { get; set; }
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        public virtual Genre Genre { get; set; }

        [ForeignKey("Genre")]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }
}