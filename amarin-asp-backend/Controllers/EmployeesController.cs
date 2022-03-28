using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using amarin_asp_backend.Models;
using Microsoft.Extensions.Configuration;

namespace amarin_asp_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EmployeesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //Api Method for Selecting Data
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select EmployeeId,EmployeesName, DepartmentName,Country,DateofJoining from dbo.Employee";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeesAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        //Api Method for creating a new Employee EmployeesName, DepartmentName,Country,DateofJoining
        [HttpPost]
        public JsonResult Post(Employees dep)
        {
            string query = @"insert into dbo.Employee values
 ('" + dep.EmployeesName + @"','" 
    + dep.DepartmentName  + @"','"
    + dep.Country         + @"','"
    + dep.DateofJoining   + @"')";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeesAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Employee Created Successfully");
        }

        //API Method  for updating table Employees
        [HttpPut]
        public JsonResult Put(Employees dep)
        {
            string query = @"update  dbo.Employee
set EmployeesName= @EmployeesName,
DepartmentName= @DepartmentName,
Country= @Country,
DateofJoining= @DateofJoining";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeesAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeId", dep.EmployeeId);
                    myCommand.Parameters.AddWithValue("@EmployeesName", dep.EmployeesName);
                    myCommand.Parameters.AddWithValue("@DepartmentName", dep.DepartmentName);
                    myCommand.Parameters.AddWithValue("@Country", dep.Country);
                    myCommand.Parameters.AddWithValue("@DateofJoining", dep.DateofJoining);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Department Updated Successfully");
        }
        //API Method for Deleting Employees
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from dbo.Employee where
EmployeeId=@EmployeeId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeesAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeId", id);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Department Deleted Successfully");
        }
    }
}
