namespace GestorAsignaturas.Migrations
{
    using GestorAsignaturas.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GestorAsignaturas.DAL.GestorData>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GestorAsignaturas.DAL.GestorData context) // Cambiar el espacio de nombres aquí también
        {
            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method 
            // to avoid creating duplicate seed data.

            context.Asignaturas.AddOrUpdate(
                a => a.Nombre,
                new Asignatura
                {
                    Nombre = "Programación I",
                    Creditos = 3,
                    CD = 2,
                    CP = 1,
                    AA = 0,
                    Area = "Programación"
                },
                new Asignatura
                {
                    Nombre = "Bases de Datos",
                    Creditos = 4,
                    CD = 2,
                    CP = 2,
                    AA = 0,
                    Area = "Bases de Datos"
                },
                new Asignatura
                {
                    Nombre = "Redes de Computadoras",
                    Creditos = 3,
                    CD = 1,
                    CP = 1,
                    AA = 1,
                    Area = "Redes"
                },
                new Asignatura
                {
                    Nombre = "Sistemas Operativos",
                    Creditos = 3,
                    CD = 2,
                    CP = 0,
                    AA = 1,
                    Area = "Sistemas"
                },
                new Asignatura
                {
                    Nombre = "Ingeniería de Software",
                    Creditos = 4,
                    CD = 2,
                    CP = 1,
                    AA = 1,
                    Area = "Ingeniería"
                }
            );
        }
    }
}
