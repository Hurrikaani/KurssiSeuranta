using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KurssiSeuranta.Models;
using KurssiSeuranta.ViewModels;

namespace KurssiSeuranta.Controllers
{
    public class OpettajatController : Controller
    {
        private KurssiRekisteriEntities db = new KurssiRekisteriEntities();

        // GET: Opettajat
        public ActionResult Index()
        {
            List<OpettajaViewModel> model = new List<OpettajaViewModel>();
            KurssiRekisteriEntities entities = new KurssiRekisteriEntities();
            try
            {
                List<Opettaja> opettaja = entities.Opettaja.OrderBy(Opettaja => Opettaja.OpettajaID).ToList();
                foreach (Opettaja ope in opettaja)
                {
                    OpettajaViewModel view = new OpettajaViewModel();
                    view.OpettajaID = ope.OpettajaID;
                    view.Etunimi = ope.Etunimi;
                    view.Sukunimi = ope.Sukunimi;
                    view.Opettajanro = ope.Opettajanro;
                    model.Add(view);
                }
            }
            finally
            {
                entities.Dispose();
            }
            return View(model);
        }

        // GET: Opettajat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opettaja opettaja = db.Opettaja.Find(id);
            if (opettaja == null)
            {
                return HttpNotFound();
            }
            return View(opettaja);
        }

        // GET: Opettajat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Opettajat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OpettajaID,Etunimi,Sukunimi,Opettajanro")] Opettaja opettaja)
        {
            if (ModelState.IsValid)
            {
                db.Opettaja.Add(opettaja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opettaja);
        }

        // GET: Opettajat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opettaja opettaja = db.Opettaja.Find(id);
            if (opettaja == null)
            {
                return HttpNotFound();
            }
            return View(opettaja);
        }

        // POST: Opettajat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OpettajaID,Etunimi,Sukunimi,Opettajanro")] Opettaja opettaja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opettaja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opettaja);
        }

        // GET: Opettajat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opettaja opettaja = db.Opettaja.Find(id);
            if (opettaja == null)
            {
                return HttpNotFound();
            }
            return View(opettaja);
        }

        // POST: Opettajat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opettaja opettaja = db.Opettaja.Find(id);
            db.Opettaja.Remove(opettaja);
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
