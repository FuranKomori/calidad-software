using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using System.Web.Mvc;
using CalidadSoftware.Models;
using Database = CalidadSoftware.Models.Databases;

namespace CalidadSoftware.Controllers
{
    [Authorize]
    public class EmpleadoesController : Controller
    {
        private Databases db = new Databases();

        // GET: Empleadoes
        public ActionResult Index(string nomBusqueda, string expBusqueda, string profBusqueda, string message)
        {
            ViewBag.Message = message;

            var empleado = db.Empleado.Include(e => e.users);
            
            if (!String.IsNullOrEmpty(nomBusqueda))
            {
                empleado = empleado.Where(e => e.nombre.Contains(nomBusqueda)
                                       || e.apellido.Contains(nomBusqueda));
            }
            if (!String.IsNullOrEmpty(expBusqueda))
            {
                try
                {
                    int exp = Convert.ToInt32(expBusqueda);
                    empleado = empleado.Where(e => e.experiencia.Equals(exp));
                }catch
                {
                    return RedirectToAction("Index", "Empleadoes", new { message = "Debes ingresar el año de experiencia como un numero" });
                }
            }
            if (!String.IsNullOrEmpty(profBusqueda))
            {
                empleado = empleado.Where(e => e.profesion.Contains(profBusqueda));
            }
            return View(empleado.ToList());
        }

       

        // GET: Empleadoes/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            ViewBag.id_user = new SelectList(db.users, "id_user", "user");
            return View();
        }

        // POST: Empleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rut_empleado,dv_rut,nombre,apellido,genero,fecha_nac,email,telefono,direccion,profesion,experiencia,foto,id_user")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                int nom_img = empleado.rut_empleado;

                HttpPostedFileBase file = Request.Files["file"];

                string fileName = Path.GetFileName(file.FileName);

                string ext = Path.GetExtension(file.FileName);

                //HttpPostedFileBase file = Request.Files["file"];

                //var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/img"), nom_img+ext);
                file.SaveAs(path);

                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_user = new SelectList(db.users, "id_user", "user", empleado.id_user);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_user = new SelectList(db.users, "id_user", "user", empleado.id_user);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rut_empleado,dv_rut,nombre,apellido,genero,fecha_nac,email,telefono,direccion,profesion,experiencia,foto,id_user")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_user = new SelectList(db.users, "id_user", "user", empleado.id_user);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [NotMapped]
        public List<Empleado> ColeccionEmpleados { get; set; }
    }
}
