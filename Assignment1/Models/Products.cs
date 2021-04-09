using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Products
    {
        [Key]
        public int ProductsId { get; set; }
        [Required(ErrorMessage = "Please enter a product code!")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please enter a product name!")]
        public string PName { get; set; }
        [Required]
        [Range(0.01, 1000000, ErrorMessage = "Price have to larger than 0.00")]
        public decimal Price { get; set; } = 0.00M;
        [Required(ErrorMessage = "Please enter a RDate!")]
        public DateTime Rdate { get; set; } = DateTime.Now;


    }
}
