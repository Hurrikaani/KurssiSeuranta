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
    public class KurssitController : Controller
    {
        private KurssiRekisteriEntities db = new KurssiRekisteriEntities();

        // GET: Kurssit
        public ActionResult Index()
        {
            return View(db.Kurssi.ToList());
        }

        // GET: Kurssit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurssi kurssi = db.Kurssi.Find(id);
            if (kurssi == null)
            {
                return HttpNotFound();
            }
            return View(kurssi);
        }

        // GET: Kurssit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kurssit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Kurssinimi,Kurssikoodi,KurssiID")] Kurssi kurssi)
        {
            if (ModelState.IsValid)
            {
                db.Kurssi.Add(kurssi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kurssi);
        }

        // GET: Kurssit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurssi kurssi = db.Kurssi.Find(id);
            if (kurssi == null)
            {
                return HttpNotFound();
            }
            return View(kurssi);
        }

        // POST: Kurssit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Kurssinimi,Kurssikoodi,KurssiID")] Kurssi kurssi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kurssi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kurssi);
        }

        // GET: Kurssit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurssi kurssi = db.Kurssi.Find(id);
            if (kurssi == null)
            {
                return HttpNotFound();
            }
            return View(kurssi);
        }

        // POST: Kurssit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kurssi kurssi = db.Kurssi.Find(id);
            db.Kurssi.Remove(kurssi);
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
