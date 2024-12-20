using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using GestorAsignaturas.DAL;
using GestorAsignaturas.Models;

namespace GestorAsignaturas.Controllers
{
    public class AsignaturaController : Controller
    {
        private GestorData bd = new GestorData();

        // GET: Asignatura
        public ActionResult Index()
        {
            return View(bd.Asignaturas.ToList());
        }

        // GET: Asignatura/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura asignatura = bd.Asignaturas.Find(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }

        // GET: Asignatura/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Asignatura/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "Id,Nombre,Codigo,Creditos,CD,CP,AA,Area")] Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                bd.Asignaturas.Add(asignatura);
                bd.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asignatura);
        }

        // GET: Asignatura/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura asignatura = bd.Asignaturas.Find(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }

        // POST: Asignatura/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id,Nombre,Codigo,Creditos,CD,CP,AA,Area")] Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                bd.Entry(asignatura).State = EntityState.Modified;
                bd.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asignatura);
        }

        // GET: Asignatura/Borrar/5
        public ActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura asignatura = bd.Asignaturas.Find(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }

        // POST: Asignatura/Borrar/5
        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarBorrar(int id)
        {
            Asignatura asignatura = bd.Asignaturas.Find(id);
            bd.Asignaturas.Remove(asignatura);
            bd.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bd.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
