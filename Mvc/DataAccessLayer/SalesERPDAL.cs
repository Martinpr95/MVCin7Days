using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Mvc.Models;

namespace Mvc.DataAccessLayer
{
    public class SalesERPDAL:DbContext
    {
        //DbSet representa la colección de todas las entidades que pueden
        //ser consultadas desde la base de datos.

        //Cuando usás LINQ contra el DbSet, este se convierte a una consulta
        //y pega en la base de datos
        public DbSet<Employee> Empleados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //IMPORTANTE: El name de la connection String y el nombre de la
            //clase del DataAcessLayer DEBEN ser los MISMOS.
            //Para que mapee automáticamente
            modelBuilder.Entity<Employee>().ToTable("Empleados");
            base.OnModelCreating(modelBuilder);
        }

        //Si llamás de otra forma a la connectionString, en el constructor
        //de tu DAL, ten´s que pasarle a la clase padre, el nombre
        //de la nueva cnnString
        public SalesERPDAL()
            : base("SalesERPDAL")
        {

        }


    }
}