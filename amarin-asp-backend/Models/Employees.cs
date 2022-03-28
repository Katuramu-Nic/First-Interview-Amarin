using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace amarin_asp_backend.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeesName { get; set; }
        public string DepartmentName { get; set; }
        public string Country { get; set; }
        public string DateofJoining { get; set; }
    }
}
