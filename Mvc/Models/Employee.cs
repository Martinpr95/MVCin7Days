using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Mvc.Models.Validaciones;

namespace Mvc.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        //[Required(ErrorMessage="Ingresá tu nombre")]
        [FirstNameValidation]
        public string FirstName { get; set; }

        [StringLength(5,ErrorMessage="El apellido no debe tener más de 5 caracteres")]
        //[DataType(DataType.Text)]
        public string LastName { get; set; }


        //El campo Salario, se validó sin que nosotros le pongamos nada
        //Eso sucede porque los validadores se disparan automáticamente con
        //las propiedades con tipos de datos primitivos

        [DataType(DataType.Currency,ErrorMessage="Ingrese un valor entero")]
        public int Salary { get; set; }
    }
}