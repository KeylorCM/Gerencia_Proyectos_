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
    public class AdminMenuProductosController : Controller
    {
        private gp_CafeteriaEntities db = new gp_CafeteriaEntities();

        // GET: AdminMenuProductos
        public ActionResult Index()
        {
            return View(db.MenuProductos.ToList());
        }

        // GET: AdminMenuProductos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuProductos menuProductos = db.MenuProductos.Find(id);
            if (menuProductos == null)
            {
                return HttpNotFound();
            }
            return View(menuProductos);
        }

        // GET: AdminMenuProductos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminMenuProductos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDProd,CodiProd,TipoProd,DescProd,PrecioProd,CantProd")] MenuProductos menuProductos)
        {
            if (ModelState.IsValid)
            {
                db.MenuProductos.Add(menuProductos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuProductos);
        }

        // GET: AdminMenuProductos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuProductos menuProductos = db.MenuProductos.Find(id);
            if (menuProductos == null)
            {
                return HttpNotFound();
            }
            return View(menuProductos);
        }

        // POST: AdminMenuProductos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDProd,CodiProd,TipoProd,DescProd,PrecioProd,CantProd")] MenuProductos menuProductos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuProductos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuProductos);
        }

        // GET: AdminMenuProductos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuProductos menuProductos = db.MenuProductos.Find(id);
            if (menuProductos == null)
            {
                return HttpNotFound();
            }
            return View(menuProductos);
        }

        // POST: AdminMenuProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuProductos menuProductos = db.MenuProductos.Find(id);
            db.MenuProductos.Remove(menuProductos);
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
