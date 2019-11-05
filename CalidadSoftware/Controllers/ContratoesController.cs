using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CalidadSoftware.Models;
using CalidadSoftware.Providers;

namespace CalidadSoftware.Controllers
{
    public class ContratoesController : Controller
    {
        private Databases db = new Databases();

        // GET: Contratoes
        public ActionResult Index()
        {
            var contrato = db.Contrato.Include(c => c.Categoria_Empleado).Include(c => c.Empleado);
            return View(contrato.ToList());
        }

        // GET: Contratoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);


            if (contrato == null)
            {
                return HttpNotFound();
            }

            //var sueldo = new Sueldo()
            //{
            //    Bonificacion = 1000,
            //    Descuento = 2000,
            //    Sueldo_Final = 30000

            //};

            return View(contrato);
        }


        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(db.Categoria_Empleado, "id_categoria", "descripcion");
            ViewBag.rut_empleado = new SelectList(from s in db.Empleado select new
                                                    {
                                                        rut_empleado = s.rut_empleado,
                                                        nombrecompleto = s.nombre + " " + s.apellido
                                                    }, "rut_empleado", "nombrecompleto");
            return View();
        }

        // POST: Contratoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_contrato,fecha_ini,fecha_fin,tipo_contrato,rut_empleado,id_categoria")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Contrato.Add(contrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.Categoria_Empleado, "id_categoria", "descripcion", contrato.id_categoria);
            ViewBag.rut_empleado = new SelectList(db.Empleado, "apellido", "nombre", contrato.rut_empleado);
            return View(contrato);
        }

        // GET: Contratoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(db.Categoria_Empleado, "id_categoria", "descripcion", contrato.id_categoria);
            ViewBag.rut_empleado = new SelectList(db.Empleado, "rut_empleado", "dv_rut", contrato.rut_empleado);
            return View(contrato);
        }

        // POST: Contratoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_contrato,fecha_ini,fecha_fin,tipo_contrato,rut_empleado,id_categoria")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(db.Categoria_Empleado, "id_categoria", "descripcion", contrato.id_categoria);
            ViewBag.rut_empleado = new SelectList(db.Empleado, "rut_empleado", "dv_rut", contrato.rut_empleado);
            return View(contrato);
        }   

    }
}

