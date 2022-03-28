using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace amarin_asp_backend.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentId { get; set; }
        public string City { get; set; }
        public string DepartmentName { get; set; }
    }
}
