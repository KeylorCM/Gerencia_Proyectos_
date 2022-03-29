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
    public class OrdenPedidosController : Controller
    {
        private gp_CafeteriaEntities db = new gp_CafeteriaEntities();

        // GET: OrdenPedidos
        public ActionResult Index()
        {
            var ordenPedidos = db.OrdenPedidos.Include(o => o.MenuProductos).Include(o => o.Mesas);
            return View(ordenPedidos.ToList());
        }

        // GET: OrdenPedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenPedidos ordenPedidos = db.OrdenPedidos.Find(id);
            if (ordenPedidos == null)
            {
                return HttpNotFound();
            }
            return View(ordenPedidos);
        }

        // GET: OrdenPedidos/Create
        public ActionResult Create()
        {
            ViewBag.IDProd = new SelectList(db.MenuProductos, "IDProd", "CodiProd");
            ViewBag.IdMesa = new SelectList(db.Mesas, "IdMesa", "NumMesa");
            return View();
        }

        // POST: OrdenPedidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdOrden,CodProd,IDProd,IdMesa,Descrpción,Cantidad,Estado,Fecha,Total")] OrdenPedidos ordenPedidos)
        {
            if (ModelState.IsValid)
            {
                db.OrdenPedidos.Add(ordenPedidos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDProd = new SelectList(db.MenuProductos, "IDProd", "CodiProd", ordenPedidos.IDProd);
            ViewBag.IdMesa = new SelectList(db.Mesas, "IdMesa", "NumMesa", ordenPedidos.IdMesa);
            return View(ordenPedidos);
        }

        // GET: OrdenPedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenPedidos ordenPedidos = db.OrdenPedidos.Find(id);
            if (ordenPedidos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDProd = new SelectList(db.MenuProductos, "IDProd", "CodiProd", ordenPedidos.IDProd);
            ViewBag.IdMesa = new SelectList(db.Mesas, "IdMesa", "NumMesa", ordenPedidos.IdMesa);
            return View(ordenPedidos);
        }

        // POST: OrdenPedidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdOrden,CodProd,IDProd,IdMesa,Descrpción,Cantidad,Estado,Fecha,Total")] OrdenPedidos ordenPedidos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenPedidos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDProd = new SelectList(db.MenuProductos, "IDProd", "CodiProd", ordenPedidos.IDProd);
            ViewBag.IdMesa = new SelectList(db.Mesas, "IdMesa", "NumMesa", ordenPedidos.IdMesa);
            return View(ordenPedidos);
        }

        // GET: OrdenPedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenPedidos ordenPedidos = db.OrdenPedidos.Find(id);
            if (ordenPedidos == null)
            {
                return HttpNotFound();
            }
            return View(ordenPedidos);
        }

        // POST: OrdenPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenPedidos ordenPedidos = db.OrdenPedidos.Find(id);
            db.OrdenPedidos.Remove(ordenPedidos);
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
