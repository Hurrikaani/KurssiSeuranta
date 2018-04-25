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
    public class OpetusTilatController : Controller
    {
        private KurssiRekisteriEntities db = new KurssiRekisteriEntities();

        // GET: OpetusTilat
        public ActionResult Index()
        {
            List<OpetustilaViewModel> model = new List<OpetustilaViewModel>();
            KurssiRekisteriEntities entities = new KurssiRekisteriEntities();
            try
            {
                List<OpetusTila> opetustila = entities.OpetusTila.OrderBy(OpetusTila => OpetusTila.LuokkaID).ToList();
                foreach (OpetusTila opetil in opetustila)
                {
                    OpetustilaViewModel view = new OpetustilaViewModel();
                    view.LuokkaID = opetil.LuokkaID;
                    view.LuokanNimi = opetil.LuokanNimi;
                    view.LuokkaKoodi = opetil.LuokkaKoodi;
                    model.Add(view);
                }
            }
            finally
            {
                entities.Dispose();
            }
            return View(model);
        }

        // GET: OpetusTilat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpetusTila opetusTila = db.OpetusTila.Find(id);
            if (opetusTila == null)
            {
                return HttpNotFound();
            }
            return View(opetusTila);
        }

        // GET: OpetusTilat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OpetusTilat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LuokkaID,LuokanNimi,LuokkaKoodi")] OpetusTila opetusTila)
        {
            if (ModelState.IsValid)
            {
                db.OpetusTila.Add(opetusTila);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opetusTila);
        }

        // GET: OpetusTilat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpetusTila opetusTila = db.OpetusTila.Find(id);
            if (opetusTila == null)
            {
                return HttpNotFound();
            }
            return View(opetusTila);
        }

        // POST: OpetusTilat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LuokkaID,LuokanNimi,LuokkaKoodi")] OpetusTila opetusTila)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opetusTila).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opetusTila);
        }

        // GET: OpetusTilat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpetusTila opetusTila = db.OpetusTila.Find(id);
            if (opetusTila == null)
            {
                return HttpNotFound();
            }
            return View(opetusTila);
        }

        // POST: OpetusTilat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OpetusTila opetusTila = db.OpetusTila.Find(id);
            db.OpetusTila.Remove(opetusTila);
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
