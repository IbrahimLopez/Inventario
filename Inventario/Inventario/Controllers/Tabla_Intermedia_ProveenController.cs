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
    
    public class Tabla_Intermedia_ProveenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tabla_Intermedia_Proveen
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var tabla_Intermedia_Proveen = db.Tabla_Intermedia_Proveen.Include(t => t.Tabla_Productos).Include(t => t.Tabla_Proveedores);
            return View(tabla_Intermedia_Proveen.ToList());
        }
        
        public ActionResult Reporte()
        {
            
                var tabla_Intermedia_Proveen = db.Tabla_Intermedia_Proveen.Include(t => t.Tabla_Productos).Include(t => t.Tabla_Proveedores);
                return View(tabla_Intermedia_Proveen.ToList());
          
            
        }

        // GET: Tabla_Intermedia_Proveen/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Intermedia_Proveen tabla_Intermedia_Proveen = db.Tabla_Intermedia_Proveen.Find(id);
            if (tabla_Intermedia_Proveen == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Intermedia_Proveen);
        }

        // GET: Tabla_Intermedia_Proveen/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            
            ViewBag.productoID = new SelectList(db.Tabla_Productos, "productoID", "nombreProducto");
            ViewBag.RFCproveedor = new SelectList(db.Tabla_Proveedores, "RFCproveedor", "nombreProveedor");
            return View();
        }

        // POST: Tabla_Intermedia_Proveen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "proveenID,productoID,RFCproveedor,fechaProveen")] Tabla_Intermedia_Proveen tabla_Intermedia_Proveen)
        {
            if (ModelState.IsValid)
            {
                db.Tabla_Intermedia_Proveen.Add(tabla_Intermedia_Proveen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.productoID = new SelectList(db.Tabla_Productos, "productoID", "nombreProducto", tabla_Intermedia_Proveen.productoID);
            ViewBag.RFCproveedor = new SelectList(db.Tabla_Proveedores, "RFCproveedor", "nombreProveedor", tabla_Intermedia_Proveen.RFCproveedor);
            return View(tabla_Intermedia_Proveen);
        }

        // GET: Tabla_Intermedia_Proveen/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Intermedia_Proveen tabla_Intermedia_Proveen = db.Tabla_Intermedia_Proveen.Find(id);
            if (tabla_Intermedia_Proveen == null)
            {
                return HttpNotFound();
            }
            ViewBag.productoID = new SelectList(db.Tabla_Productos, "productoID", "nombreProducto", tabla_Intermedia_Proveen.productoID);
            ViewBag.RFCproveedor = new SelectList(db.Tabla_Proveedores, "RFCproveedor", "nombreProveedor", tabla_Intermedia_Proveen.RFCproveedor);
            return View(tabla_Intermedia_Proveen);
        }

        // POST: Tabla_Intermedia_Proveen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "proveenID,productoID,RFCproveedor,fechaProveen")] Tabla_Intermedia_Proveen tabla_Intermedia_Proveen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabla_Intermedia_Proveen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productoID = new SelectList(db.Tabla_Productos, "productoID", "nombreProducto", tabla_Intermedia_Proveen.productoID);
            ViewBag.RFCproveedor = new SelectList(db.Tabla_Proveedores, "RFCproveedor", "nombreProveedor", tabla_Intermedia_Proveen.RFCproveedor);
            return View(tabla_Intermedia_Proveen);
        }

        // GET: Tabla_Intermedia_Proveen/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Intermedia_Proveen tabla_Intermedia_Proveen = db.Tabla_Intermedia_Proveen.Find(id);
            if (tabla_Intermedia_Proveen == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Intermedia_Proveen);
        }

        // POST: Tabla_Intermedia_Proveen/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tabla_Intermedia_Proveen tabla_Intermedia_Proveen = db.Tabla_Intermedia_Proveen.Find(id);
            db.Tabla_Intermedia_Proveen.Remove(tabla_Intermedia_Proveen);
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
