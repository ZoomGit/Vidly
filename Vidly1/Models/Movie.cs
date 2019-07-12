using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {   [Key]
        public int MovieId { get; set; }
      [StringLength(255)]
      
        public string MoveName { get; set; }
    }
}