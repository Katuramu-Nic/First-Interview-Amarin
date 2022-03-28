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
    public class CustomersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CustomersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //Api Method for Selecting Data
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select CustomerId,CustomerName,DepartmentName,Country from dbo.Customer";
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
        //Api Method for creating a new Customer Record
        [HttpPost]
        public JsonResult Post(Customers dep)
        {
            string query = @"insert into dbo.Customer values
('" + dep.CustomerName     + @"','"
    + dep.DepartmentName   + @"','"
    + dep.Country          + @"')";
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
            return new JsonResult("New Customer Created Successfully");
        }

        //API for updating table Customer
        [HttpPut]
        public JsonResult Put(Customers dep)
        {
            string query = @"update  dbo.Customer 
set CustomerName= @CustomerName,DepartmentName= @DepartmentName,Country= @Country";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeesAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CustomerId", dep.CustomerId);
                    myCommand.Parameters.AddWithValue("@DepartmentName", dep.DepartmentName);
                    myCommand.Parameters.AddWithValue("@Country", dep.Country);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Customer Updated Successfully");
        }
        //API Method for Deleting Customer Details
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from dbo.Customer where
CustomerId=@CustomerId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeesAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CustomerId", id);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Customer Deleted Successfully");
        }
    }
}
