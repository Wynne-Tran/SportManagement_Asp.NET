using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Registrations
    {
        [Key]
        public int RegistrationsId { get; set; }
        [Required]
        public int CustomersId { get; set; }
        public Customers Customers { get; set; }
        [Required]
        public int ProductsId { get; set; }
        public Products Products { get; set; }

        
    }
}
