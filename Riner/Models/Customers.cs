using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Riner.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Enter Customer's Name")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        public string DepartmentName { get; set; }
        public string Country { get; set; }
        public string PhotofileName { get; set; }

        public Customers()
        { }
    }
}
