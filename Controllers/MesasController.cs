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
    public class MesasController : Controller
    {
        private gp_CafeteriaEntities db = new gp_CafeteriaEntities();

        // GET: Mesas
        public ActionResult Index()
        {
            ViewData["estado"] = "1";
            ViewData["mesa"] = "";
            return View();
        }
        [HttpPost]
        public ActionResult Index(int mesa)
        {
            ViewData["mesa"] = Convert.ToString(mesa);
            ViewData["estado"] = "2";

            return View();
        }
        // GET: Mesas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesas mesas = db.Mesas.Find(id);
            if (mesas == null)
            {
                return HttpNotFound();
            }
            return View(mesas);
        }

        // GET: Mesas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mesas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMesa,NumMesa")] Mesas mesas)
        {
            if (ModelState.IsValid)
            {
                db.Mesas.Add(mesas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mesas);
        }

        // GET: Mesas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesas mesas = db.Mesas.Find(id);
            if (mesas == null)
            {
                return HttpNotFound();
            }
            return View(mesas);
        }

        // POST: Mesas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMesa,NumMesa")] Mesas mesas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mesas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mesas);
        }

        // GET: Mesas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesas mesas = db.Mesas.Find(id);
            if (mesas == null)
            {
                return HttpNotFound();
            }
            return View(mesas);
        }

        // POST: Mesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mesas mesas = db.Mesas.Find(id);
            db.Mesas.Remove(mesas);
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
