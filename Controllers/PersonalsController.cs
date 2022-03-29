using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using Gerencia_Proyectos_.Models;

namespace Gerencia_Proyectos_.Controllers
{
    public class PersonalsController : Controller
    {
        private gp_CafeteriaEntities db = new gp_CafeteriaEntities();

        // GET: Personals
        public ActionResult Index()
        {
            return View(db.Personal.ToList());
        }

        // GET: Personals/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personal.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // GET: Personals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,Puesto,Cedula,Nombre,Apellidos,Telefono,Correo,Contrasena")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                db.Personal.Add(personal);
                try
                {
                    db.SaveChanges();
                } 
                catch(EntityValidationException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
               
                return RedirectToAction("Index");
            }

            return View(personal);
        }

        // GET: Personals/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personal.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // POST: Personals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,Puesto,Cedula,Nombre,Apellidos,Telefono,Correo,Contrasena")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personal);
        }

        // GET: Personals/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personal.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // POST: Personals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Personal personal = db.Personal.Find(id);
            db.Personal.Remove(personal);
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

        [Serializable]
        private class EntityValidationException : Exception
        {
            public EntityValidationException()
            {
            }

            public EntityValidationException(string message) : base(message)
            {
            }

            public EntityValidationException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected EntityValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
