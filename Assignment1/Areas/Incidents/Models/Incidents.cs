using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Incidents
    {
        [Key]
        public int IncidentsId { get; set; }
        [Required(ErrorMessage = "Please enter a title!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a description!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a date added!")]
        public DateTime DateAdded { get; set; }
        public DateTime? DateClosed { get; set; }

       
        public int CustomersId { get; set; }
        public Customers Customers { get; set; }


        [Required(ErrorMessage = "Please choice a product")]
        public int ProductsId { get; set; }
        public Products Product { get; set; }


        public int? TechniciansId { get; set; }
        public Technicians? Technician { get; set; }
       


    }
}
