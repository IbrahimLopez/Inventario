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
    public class Tabla_ClientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tabla_Clientes
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Tabla_Clientes.ToList());
        }
        public ActionResult Reporte()
        {
            
                return View(db.Tabla_Clientes.ToList());
          
            
        }
        public ActionResult Reporte2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Clientes tabla_Clientes = db.Tabla_Clientes.Find(id);
            if (tabla_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Clientes);
        }

        //Se genera el pdf
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
        public ActionResult GeneratePDF2(int id)
        {
            if (User.IsInRole("Admin"))
            {
                 
                return new Rotativa.ActionAsPdf("Reporte2"+"/"+id);

            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        // GET: Tabla_Clientes/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Clientes tabla_Clientes = db.Tabla_Clientes.Find(id);
            if (tabla_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Clientes);
        }

        // GET: Tabla_Clientes/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tabla_Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clienteID,nombreCliente,apellidoPaternoCliente,apellidoMaternoCliente,direccionCliente,telefonoCliente,correroCliente")] Tabla_Clientes tabla_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.Tabla_Clientes.Add(tabla_Clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tabla_Clientes);
        }

        // GET: Tabla_Clientes/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Clientes tabla_Clientes = db.Tabla_Clientes.Find(id);
            if (tabla_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Clientes);
        }

        // POST: Tabla_Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clienteID,nombreCliente,apellidoPaternoCliente,apellidoMaternoCliente,direccionCliente,telefonoCliente,correroCliente")] Tabla_Clientes tabla_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabla_Clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabla_Clientes);
        }

        // GET: Tabla_Clientes/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Clientes tabla_Clientes = db.Tabla_Clientes.Find(id);
            if (tabla_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Clientes);
        }

        // POST: Tabla_Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tabla_Clientes tabla_Clientes = db.Tabla_Clientes.Find(id);
            db.Tabla_Clientes.Remove(tabla_Clientes);
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
