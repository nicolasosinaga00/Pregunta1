using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pregunta1MVC.Models;

namespace Pregunta1MVC.Controllers
{
    public class OsinagasController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Osinagas
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Osinagas.ToList());
        }

        // GET: Osinagas/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osinaga osinaga = db.Osinagas.Find(id);
            if (osinaga == null)
            {
                return HttpNotFound();
            }
            return View(osinaga);
        }

        // GET: Osinagas/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Osinagas/Create
        [Authorize]
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OsinagaID,FriendofOsinaga,Place,Email,Birthday")] Osinaga osinaga)
        {
            if (ModelState.IsValid)
            {
                db.Osinagas.Add(osinaga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(osinaga);
        }

        // GET: Osinagas/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osinaga osinaga = db.Osinagas.Find(id);
            if (osinaga == null)
            {
                return HttpNotFound();
            }
            return View(osinaga);
        }

        // POST: Osinagas/Edit/5
        [Authorize]
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OsinagaID,FriendofOsinaga,Place,Email,Birthday")] Osinaga osinaga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osinaga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(osinaga);
        }

        // GET: Osinagas/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osinaga osinaga = db.Osinagas.Find(id);
            if (osinaga == null)
            {
                return HttpNotFound();
            }
            return View(osinaga);
        }

        // POST: Osinagas/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Osinaga osinaga = db.Osinagas.Find(id);
            db.Osinagas.Remove(osinaga);
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
