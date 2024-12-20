using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GestorAsignaturas.Models;

namespace GestorAsignaturas.DAL
{
    public class GestorData : DbContext
    {
        public DbSet<Asignatura> Asignaturas { get; set; }
    }
}
