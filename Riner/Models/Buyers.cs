
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riner.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentId { get; set; }
        public string City { get; set; }
        public string DepartmentName { get; set; }
    }
}

