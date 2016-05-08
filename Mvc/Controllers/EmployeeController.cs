using Mvc.Models;
using Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Test/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index()
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
            //empleadoListaViewModel.UserName = "Admin";

            return View("Index", empleadoListaViewModel);



        }

        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        } 

        public ActionResult SaveEmployee(Employee e, string BtnSubmit)// , string FirstName) Si acá paso una propiedad que se llame igual que la propiedad de la clase Employee
            //se va a cargar también, porque va a machear con el nombre de la key que tiene en los datos de entrada.
        {
            //Esto genera automáticamente un employee a partir de los Textboxes.
            //Por el concepto llamado Model Binder.
            
            //Model Binder se ejecutará automáticamente cada vez
            //que se hace un pedido a un Action Method que contenga parámetros.
            
            //Model binder iterará por todos los parámetros primitivos de un método
            //y entonces, va a comparar el nombre del parámetro con cada elemento de
            //los datos de entrada (por POST o por Query String).
            //Cuando encuentra una coincidencia, asigna el dato entrante a un parámetro.
            //Si no encuentra, le asigna un valor por defecto, por ejemplo:
            //0 para integer, NULL para String
            //En caso de que pueda asignar la propiedad porque los datos no coinciden, lanza
            //una excepción


            //Después de que el Model binder itera por cada propiedad de cada una de las
            //clases de los parámetros y compara cada nombre de las propiedades con cada key
            //el los datos de entrada. Cuando coinciden, asigna el dato entrante a un parámetro.

            //Hay dos botones Submit, con el mismo nombre (BtnSubmit) para diferenciarlos,
            //preguntás por su value
            //Corrección! En realidad, son los botones Submit, son input, así que el 
            //Model Binder les asigna el valor ´que tengan, en este caso, el texto del botón
            
            //Model Binder, también actualiza el ModelState, el cual encapsula el estado del
            //modelo. El mismo, tiene una propiedad llamada IsValid, la cual, determina si
            //el modelo (en este caso el obj Employee) fue actualizado correctamente o no
            //El Modelo no se actualiza si alguna de las validaciones del servidor falla.

            //Por ejemplo: ModelState["FirstName"].Errors contiene todos los errores relacionados
            //con el First Name

            //En MVC, se usa DataAnnotations para llevar a cabo las validaciones del lado del servidor.

            
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                        //return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
                    }
                    else
                    {
                        return View("CreateEmployee");
                    }
                case "Cancel":
                    return RedirectToAction("Index");
                    //RedirectToAction realiza un nuevo Request al Action Method apuntado
            }

            return new EmptyResult(); //pantalla en blanco
            
        }

    }
}
