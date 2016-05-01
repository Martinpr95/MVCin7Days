using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc.DataAccessLayer;

namespace Mvc.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            //List<Employee> employees = new List<Employee>();
            //Employee emp = new Employee();
            //emp.FirstName = "Johnson";
            //emp.LastName = "fernandez";
            //emp.Salary = 14000;
            //employees.Add(emp);
            //return employees;

            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Empleados.ToList();            
        }

        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Empleados.Add(e);
            salesDal.SaveChanges();
            return e;
        }

    }
}