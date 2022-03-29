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
    public class CajasRecepcionsController : Controller
    {
        private gp_CafeteriaEntities db = new gp_CafeteriaEntities();

        // GET: CajasRecepcions
        public ActionResult Index()
        {
            var cajasRecepcion = db.CajasRecepcion.Include(c => c.OrdenPedidos).Include(c => c.MenuProductos).Include(c => c.Personal);
            return View(cajasRecepcion.ToList());
        }

        //Nuevo comentario

        // GET: CajasRecepcions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajasRecepcion cajasRecepcion = db.CajasRecepcion.Find(id);
            if (cajasRecepcion == null)
            {
                return HttpNotFound();
            }
            return View(cajasRecepcion);
        }

        // GET: CajasRecepcions/Create
        public ActionResult Create()
        {
            ViewBag.IdOrden = new SelectList(db.OrdenPedidos, "IdOrden", "CodProd");
            ViewBag.IDProd = new SelectList(db.MenuProductos, "IDProd", "CodiProd");
            ViewBag.IdUsuario = new SelectList(db.Personal, "IdUsuario", "Puesto");
            return View();
        }

        // POST: CajasRecepcions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCaja,IdUsuario,IdOrden,IDProd,EstadoPedido,TipoProd,DescProd,PrecioProd,CantProd")] CajasRecepcion cajasRecepcion)
        {
            if (ModelState.IsValid)
            {
                db.CajasRecepcion.Add(cajasRecepcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdOrden = new SelectList(db.OrdenPedidos, "IdOrden", "CodProd", cajasRecepcion.IdOrden);
            ViewBag.IDProd = new SelectList(db.MenuProductos, "IDProd", "CodiProd", cajasRecepcion.IDProd);
            ViewBag.IdUsuario = new SelectList(db.Personal, "IdUsuario", "Puesto", cajasRecepcion.IdUsuario);
            return View(cajasRecepcion);
        }

        // GET: CajasRecepcions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajasRecepcion cajasRecepcion = db.CajasRecepcion.Find(id);
            if (cajasRecepcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdOrden = new SelectList(db.OrdenPedidos, "IdOrden", "CodProd", cajasRecepcion.IdOrden);
            ViewBag.IDProd = new SelectList(db.MenuProductos, "IDProd", "CodiProd", cajasRecepcion.IDProd);
            ViewBag.IdUsuario = new SelectList(db.Personal, "IdUsuario", "Puesto", cajasRecepcion.IdUsuario);
            return View(cajasRecepcion);
        }

        // POST: CajasRecepcions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCaja,IdUsuario,IdOrden,IDProd,EstadoPedido,TipoProd,DescProd,PrecioProd,CantProd")] CajasRecepcion cajasRecepcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cajasRecepcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdOrden = new SelectList(db.OrdenPedidos, "IdOrden", "CodProd", cajasRecepcion.IdOrden);
            ViewBag.IDProd = new SelectList(db.MenuProductos, "IDProd", "CodiProd", cajasRecepcion.IDProd);
            ViewBag.IdUsuario = new SelectList(db.Personal, "IdUsuario", "Puesto", cajasRecepcion.IdUsuario);
            return View(cajasRecepcion);
        }

        // GET: CajasRecepcions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajasRecepcion cajasRecepcion = db.CajasRecepcion.Find(id);
            if (cajasRecepcion == null)
            {
                return HttpNotFound();
            }
            return View(cajasRecepcion);
        }

        // POST: CajasRecepcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CajasRecepcion cajasRecepcion = db.CajasRecepcion.Find(id);
            db.CajasRecepcion.Remove(cajasRecepcion);
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
