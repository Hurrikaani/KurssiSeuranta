using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KurssiSeuranta.Models;

namespace KurssiSeuranta.Controllers
{
    public class LasnaolotietoController : Controller
    {
        private OpiskelijarekisteriEntities db = new OpiskelijarekisteriEntities();

        // GET: Lasnaolotieto
        public ActionResult Index()
        {
            var lasnaolotiedot = db.Lasnaolotiedot.Include(l => l.Opettaja);
            return View(lasnaolotiedot.ToList());
        }

        // GET: Lasnaolotieto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lasnaolotiedot lasnaolotiedot = db.Lasnaolotiedot.Find(id);
            if (lasnaolotiedot == null)
            {
                return HttpNotFound();
            }
            return View(lasnaolotiedot);
        }

        // GET: Lasnaolotieto/Create
        public ActionResult Create()
        {
            ViewBag.OpettajaID = new SelectList(db.Opettaja, "OpettajaID", "Etunimi");
            return View();
        }

        // POST: Lasnaolotieto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Kirjautuminen_sisaan,Kirjautuminen_ulos,Luokkanumero,OpettajaID,RekisteriID")] Lasnaolotiedot lasnaolotiedot)
        {
            if (ModelState.IsValid)
            {
                db.Lasnaolotiedot.Add(lasnaolotiedot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OpettajaID = new SelectList(db.Opettaja, "OpettajaID", "Etunimi", lasnaolotiedot.OpettajaID);
            return View(lasnaolotiedot);
        }

        // GET: Lasnaolotieto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lasnaolotiedot lasnaolotiedot = db.Lasnaolotiedot.Find(id);
            if (lasnaolotiedot == null)
            {
                return HttpNotFound();
            }
            ViewBag.OpettajaID = new SelectList(db.Opettaja, "OpettajaID", "Etunimi", lasnaolotiedot.OpettajaID);
            return View(lasnaolotiedot);
        }

        // POST: Lasnaolotieto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Kirjautuminen_sisaan,Kirjautuminen_ulos,Luokkanumero,OpettajaID,RekisteriID")] Lasnaolotiedot lasnaolotiedot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lasnaolotiedot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OpettajaID = new SelectList(db.Opettaja, "OpettajaID", "Etunimi", lasnaolotiedot.OpettajaID);
            return View(lasnaolotiedot);
        }

        // GET: Lasnaolotieto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lasnaolotiedot lasnaolotiedot = db.Lasnaolotiedot.Find(id);
            if (lasnaolotiedot == null)
            {
                return HttpNotFound();
            }
            return View(lasnaolotiedot);
        }

        // POST: Lasnaolotieto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lasnaolotiedot lasnaolotiedot = db.Lasnaolotiedot.Find(id);
            db.Lasnaolotiedot.Remove(lasnaolotiedot);
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
