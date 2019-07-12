using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name ="Customer")]
        public string CustomerName { get; set; }
        [Display(Name ="Date Of Birth")]
        public DateTime? CustomerBirthGate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
  
        public virtual MembershipType MemershipType { get; set; }
        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; }

    }
}