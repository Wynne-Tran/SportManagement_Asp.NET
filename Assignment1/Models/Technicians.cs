﻿
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Technicians
    {

        [Key]
        public int TechniciansId { get; set; }
        [Required(ErrorMessage = "Please enter a technician name!")]
        public string TName { get; set; }
        [Required(ErrorMessage = "Please enter an Email!")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter technician phone, it must be in (999) 999-9999 format")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

    }
}
