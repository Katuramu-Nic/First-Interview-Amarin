using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Riner.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeIdId { get; set; }
        public string EmployeesName { get; set; }
        public string DepartmentName { get; set; }
        public string Country { get; set; }
        public string DateofJoining { get; set; }

    }
}
