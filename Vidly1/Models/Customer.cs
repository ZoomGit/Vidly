using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {   [Key]
        public int CustomerId { get; set; }
        []
        public string CustomerName { get; set; }
    }
}