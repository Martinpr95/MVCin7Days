using Mvc.Models;
using Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult GetView()
        {
            EmployeeListViewModel empleadoListaViewModel = new EmployeeListViewModel();

            EmployeeBusinessLayer empBusLay = new EmployeeBusinessLayer();
            List<Employee> empleados = empBusLay.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in empleados)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");

                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }

            empleadoListaViewModel.Employees = empViewModels;
            empleadoListaViewModel.UserName = "Admin";

            return View("MyView", empleadoListaViewModel);



        }

    }
}
