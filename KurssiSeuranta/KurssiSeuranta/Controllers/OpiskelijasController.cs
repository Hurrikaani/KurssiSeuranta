using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KurssiSeuranta.Models
{
    public class OpiskelijasController : Controller
    {
        private OpiskelijarekisteriEntities db = new OpiskelijarekisteriEntities();

        // GET: Opiskelijas
        public ActionResult Index()
        {
            return View(db.Opiskelija.ToList());
        }

        // GET: Opiskelijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opiskelija opiskelija = db.Opiskelija.Find(id);
            if (opiskelija == null)
            {
                return HttpNotFound();
            }
            return View(opiskelija);
        }

        // GET: Opiskelijas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Opiskelijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Etunimi,Sukunimi,Opiskelijanro,OpiskelijaID,Tutkinto")] Opiskelija opiskelija)
        {
            if (ModelState.IsValid)
            {
                db.Opiskelija.Add(opiskelija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opiskelija);
        }

        // GET: Opiskelijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opiskelija opiskelija = db.Opiskelija.Find(id);
            if (opiskelija == null)
            {
                return HttpNotFound();
            }
            return View(opiskelija);
        }

        // POST: Opiskelijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Etunimi,Sukunimi,Opiskelijanro,OpiskelijaID,Tutkinto")] Opiskelija opiskelija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opiskelija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opiskelija);
        }

        // GET: Opiskelijas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opiskelija opiskelija = db.Opiskelija.Find(id);
            if (opiskelija == null)
            {
                return HttpNotFound();
            }
            return View(opiskelija);
        }

        // POST: Opiskelijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opiskelija opiskelija = db.Opiskelija.Find(id);
            db.Opiskelija.Remove(opiskelija);
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
