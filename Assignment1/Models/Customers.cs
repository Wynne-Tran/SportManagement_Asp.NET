using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Customers
    {
        [Key]
        public int CustomersId { get; set; }
        [Required(ErrorMessage = "Please enter a first name!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter an address!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter a city!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a state!")]
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public int CountryId { get; set; }
        public Countries Country { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number must be in (999) 999-9999 format")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string FullName => FirstName + " " + LastName;


    }
}
