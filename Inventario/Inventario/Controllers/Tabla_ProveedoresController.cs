using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventario.Models;

namespace Inventario.Controllers
{
    [Authorize(Roles = "Admin, Capturista")]
    public class Tabla_ProveedoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tabla_Proveedores
        public ActionResult Index()
        {
            return View(db.Tabla_Proveedores.ToList());
        }
        public ActionResult Reporte()
        {
            return View(db.Tabla_Proveedores.ToList());
        }

        // GET: Tabla_Proveedores/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Proveedores tabla_Proveedores = db.Tabla_Proveedores.Find(id);
            if (tabla_Proveedores == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Proveedores);
        }

        // GET: Tabla_Proveedores/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tabla_Proveedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RFCproveedor,nombreProveedor,apellidoPaternoProveedor,apellidoMaternoProveedor,telefonoProveedor,direccionProveedor")] Tabla_Proveedores tabla_Proveedores)
        {
            if (ModelState.IsValid)
            {
                db.Tabla_Proveedores.Add(tabla_Proveedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tabla_Proveedores);
        }

        // GET: Tabla_Proveedores/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Proveedores tabla_Proveedores = db.Tabla_Proveedores.Find(id);
            if (tabla_Proveedores == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Proveedores);
        }

        // POST: Tabla_Proveedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "RFCproveedor,nombreProveedor,apellidoPaternoProveedor,apellidoMaternoProveedor,telefonoProveedor,direccionProveedor")] Tabla_Proveedores tabla_Proveedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabla_Proveedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabla_Proveedores);
        }

        // GET: Tabla_Proveedores/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Proveedores tabla_Proveedores = db.Tabla_Proveedores.Find(id);
            if (tabla_Proveedores == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Proveedores);
        }

        // POST: Tabla_Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Tabla_Proveedores tabla_Proveedores = db.Tabla_Proveedores.Find(id);
            db.Tabla_Proveedores.Remove(tabla_Proveedores);
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
    }
}
