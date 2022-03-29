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
    public class Detalle_FacturaController : Controller
    {
        private gp_CafeteriaEntities db = new gp_CafeteriaEntities();

        // GET: Detalle_Factura
        public ActionResult Index()
        {
            var detalle_Factura = db.Detalle_Factura.Include(d => d.CajasRecepcion).Include(d => d.Factura).Include(d => d.Mesas).Include(d => d.OrdenPedidos);
            return View(detalle_Factura.ToList());
        }

        // GET: Detalle_Factura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Factura detalle_Factura = db.Detalle_Factura.Find(id);
            if (detalle_Factura == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Factura);
        }

        // GET: Detalle_Factura/Create
        public ActionResult Create()
        {
            ViewBag.Id_Caja = new SelectList(db.CajasRecepcion, "IdCaja", "IdUsuario");
            ViewBag.id_factura = new SelectList(db.Factura, "id_factura", "codigo");
            ViewBag.id_factura = new SelectList(db.Mesas, "IdMesa", "NumMesa");
            ViewBag.Id_Orden = new SelectList(db.OrdenPedidos, "IdOrden", "CodProd");
            return View();
        }

        // POST: Detalle_Factura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_detalleFactura,id_factura,Id_Orden,Id_Mesa,Id_Caja,cantidad_articulo")] Detalle_Factura detalle_Factura)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_Factura.Add(detalle_Factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Caja = new SelectList(db.CajasRecepcion, "IdCaja", "IdUsuario", detalle_Factura.Id_Caja);
            ViewBag.id_factura = new SelectList(db.Factura, "id_factura", "codigo", detalle_Factura.id_factura);
            ViewBag.id_factura = new SelectList(db.Mesas, "IdMesa", "NumMesa", detalle_Factura.id_factura);
            ViewBag.Id_Orden = new SelectList(db.OrdenPedidos, "IdOrden", "CodProd", detalle_Factura.Id_Orden);
            return View(detalle_Factura);
        }

        // GET: Detalle_Factura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Factura detalle_Factura = db.Detalle_Factura.Find(id);
            if (detalle_Factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Caja = new SelectList(db.CajasRecepcion, "IdCaja", "IdUsuario", detalle_Factura.Id_Caja);
            ViewBag.id_factura = new SelectList(db.Factura, "id_factura", "codigo", detalle_Factura.id_factura);
            ViewBag.id_factura = new SelectList(db.Mesas, "IdMesa", "NumMesa", detalle_Factura.id_factura);
            ViewBag.Id_Orden = new SelectList(db.OrdenPedidos, "IdOrden", "CodProd", detalle_Factura.Id_Orden);
            return View(detalle_Factura);
        }

        // POST: Detalle_Factura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_detalleFactura,id_factura,Id_Orden,Id_Mesa,Id_Caja,cantidad_articulo")] Detalle_Factura detalle_Factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_Factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Caja = new SelectList(db.CajasRecepcion, "IdCaja", "IdUsuario", detalle_Factura.Id_Caja);
            ViewBag.id_factura = new SelectList(db.Factura, "id_factura", "codigo", detalle_Factura.id_factura);
            ViewBag.id_factura = new SelectList(db.Mesas, "IdMesa", "NumMesa", detalle_Factura.id_factura);
            ViewBag.Id_Orden = new SelectList(db.OrdenPedidos, "IdOrden", "CodProd", detalle_Factura.Id_Orden);
            return View(detalle_Factura);
        }

        // GET: Detalle_Factura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Factura detalle_Factura = db.Detalle_Factura.Find(id);
            if (detalle_Factura == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Factura);
        }

        // POST: Detalle_Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_Factura detalle_Factura = db.Detalle_Factura.Find(id);
            db.Detalle_Factura.Remove(detalle_Factura);
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
