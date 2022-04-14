using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gerencia_Proyectos_.Models;

namespace Gerencia_Proyectos_.Controllers
{
    public class FacturasController : Controller
    {
        private gp_CafeteriaEntities db = new gp_CafeteriaEntities();

        // GET: Facturas
        public ActionResult Index()
        {
            //var factura = db.Factura.Include(f => f.Mesas).Include(f => f.OrdenPedidos);
            return View();
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
           // ViewBag.NumCliente = new SelectList(db.Mesas, "IdMesa", "NumMesa");
            ViewBag.NumCliente = new SelectList(db.OrdenPedidos, "IdOrden", "CodProd");
            return View();
        }

        // POST: Facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_factura,codigo,fecha,NumCliente,idUsuario,MONEY")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Factura.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.NumCliente = new SelectList(db.Mesas, "IdMesa", "NumMesa", factura.NumCliente);
            ViewBag.NumCliente = new SelectList(db.OrdenPedidos, "IdOrden", "CodProd", factura.NumCliente);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
           // ViewBag.NumCliente = new SelectList(db.Mesas, "IdMesa", "NumMesa", factura.NumCliente);
            ViewBag.NumCliente = new SelectList(db.OrdenPedidos, "IdOrden", "CodProd", factura.NumCliente);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_factura,codigo,fecha,NumCliente,idUsuario,MONEY")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.NumCliente = new SelectList(db.Mesas, "IdMesa", "NumMesa", factura.NumCliente);
            ViewBag.NumCliente = new SelectList(db.OrdenPedidos, "IdOrden", "CodProd", factura.NumCliente);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Factura.Find(id);
            db.Factura.Remove(factura);
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
