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
    
    public class Tabla_ProductosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tabla_Productos
        public ActionResult Index()
        {
            return View(db.Tabla_Productos.ToList());
        }

        // GET: Tabla_Productos/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Productos tabla_Productos = db.Tabla_Productos.Find(id);
            if (tabla_Productos == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Productos);
        }

        // GET: Tabla_Productos/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tabla_Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "productoID,nombreProducto,precioVenta,precioCompra,pesoNeto,fechaEntrada")] Tabla_Productos tabla_Productos)
        {
            if (ModelState.IsValid)
            {
                db.Tabla_Productos.Add(tabla_Productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tabla_Productos);
        }

        // GET: Tabla_Productos/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Productos tabla_Productos = db.Tabla_Productos.Find(id);
            if (tabla_Productos == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Productos);
        }

        // POST: Tabla_Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "productoID,nombreProducto,precioVenta,precioCompra,pesoNeto,fechaEntrada")] Tabla_Productos tabla_Productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabla_Productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabla_Productos);
        }

        // GET: Tabla_Productos/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Productos tabla_Productos = db.Tabla_Productos.Find(id);
            if (tabla_Productos == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Productos);
        }

        // POST: Tabla_Productos/Delete/5
        //[Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tabla_Productos tabla_Productos = db.Tabla_Productos.Find(id);
            db.Tabla_Productos.Remove(tabla_Productos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult Reporte()
        {
            
                return View(db.Tabla_Productos.ToList());
         
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //generar pdf con rotativa
        //[Authorize(Roles ="Admin")]
        public ActionResult GeneratePDF()
        {
            if (User.IsInRole("Admin"))
            {
                return new Rotativa.ActionAsPdf("Reporte");
            }
            else
            {
                return RedirectToAction("Index");
            }
       
        }
    }
}
