using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Countries
    {
        
        [Key]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Please enter country name!")]
        public string CountryName { get; set; }
    }
}
