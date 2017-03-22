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
   
    public class Tabla_Intemedia_ComprasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tabla_Intemedia_Compras
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            var tabla_Intemedia_Comrpas = db.Tabla_Intemedia_Comrpas.Include(t => t.Tabla_Clientes).Include(t => t.Tabla_Productos);
            return View(tabla_Intemedia_Comrpas.ToList());
        }
        // GET: Tabla_Intemedia_Compras
        public ActionResult Reporte()
        {
          
                var tabla_Intemedia_Comrpas = db.Tabla_Intemedia_Comrpas.Include(t => t.Tabla_Clientes).Include(t => t.Tabla_Productos);
                return View(tabla_Intemedia_Comrpas.ToList());
          
            
        }
        // GET: Tabla_Intemedia_Compras/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Intemedia_Comrpas tabla_Intemedia_Comrpas = db.Tabla_Intemedia_Comrpas.Find(id);
            if (tabla_Intemedia_Comrpas == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Intemedia_Comrpas);
        }

        // GET: Tabla_Intemedia_Compras/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.clienteID = new SelectList(db.Tabla_Clientes, "clienteID", "nombreCliente");
            ViewBag.productoID = new SelectList(db.Tabla_Productos, "productoID", "nombreProducto");
            return View();
        }

        // POST: Tabla_Intemedia_Compras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "compraID,clienteID,productoID,fechaCompra,cantidad")] Tabla_Intemedia_Comrpas tabla_Intemedia_Comrpas)
        {
            if (ModelState.IsValid)
            {
                Tabla_Productos productos = new Tabla_Productos();
                var producto = db.Tabla_Productos.Find(tabla_Intemedia_Comrpas.productoID);
                if (tabla_Intemedia_Comrpas.cantidad>producto.pesoNeto)
                {
                    RedirectToAction("Index", "Tabla_Intemedia_Compras");
                }
                else
                {
                    producto.pesoNeto = producto.pesoNeto - tabla_Intemedia_Comrpas.cantidad;
                    db.Tabla_Intemedia_Comrpas.Add(tabla_Intemedia_Comrpas);
                    db.SaveChanges();
                }
                
                
                return RedirectToAction("Index");
            }

            ViewBag.clienteID = new SelectList(db.Tabla_Clientes, "clienteID", "nombreCliente", tabla_Intemedia_Comrpas.clienteID);
            ViewBag.productoID = new SelectList(db.Tabla_Productos, "productoID", "nombreProducto", tabla_Intemedia_Comrpas.productoID);
            return View(tabla_Intemedia_Comrpas);
        }

        // GET: Tabla_Intemedia_Compras/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Intemedia_Comrpas tabla_Intemedia_Comrpas = db.Tabla_Intemedia_Comrpas.Find(id);
            if (tabla_Intemedia_Comrpas == null)
            {
                return HttpNotFound();
            }
            ViewBag.clienteID = new SelectList(db.Tabla_Clientes, "clienteID", "nombreCliente", tabla_Intemedia_Comrpas.clienteID);
            ViewBag.productoID = new SelectList(db.Tabla_Productos, "productoID", "nombreProducto", tabla_Intemedia_Comrpas.productoID);
            return View(tabla_Intemedia_Comrpas);
        }

        // POST: Tabla_Intemedia_Compras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "compraID,clienteID,productoID,fechaCompra,cantidad")] Tabla_Intemedia_Comrpas tabla_Intemedia_Comrpas)
        {
            if (ModelState.IsValid)
            {

                db.Entry(tabla_Intemedia_Comrpas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clienteID = new SelectList(db.Tabla_Clientes, "clienteID", "nombreCliente", tabla_Intemedia_Comrpas.clienteID);
            ViewBag.productoID = new SelectList(db.Tabla_Productos, "productoID", "nombreProducto", tabla_Intemedia_Comrpas.productoID);
            return View(tabla_Intemedia_Comrpas);
        }

        // GET: Tabla_Intemedia_Compras/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Intemedia_Comrpas tabla_Intemedia_Comrpas = db.Tabla_Intemedia_Comrpas.Find(id);
            if (tabla_Intemedia_Comrpas == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Intemedia_Comrpas);
        }

        // POST: Tabla_Intemedia_Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Tabla_Intemedia_Comrpas tabla_Intemedia_Comrpas = db.Tabla_Intemedia_Comrpas.Find(id);
            db.Tabla_Intemedia_Comrpas.Remove(tabla_Intemedia_Comrpas);
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
