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
    public class OpiskelijatController : Controller
    {
        private KurssiRekisteriEntities db = new KurssiRekisteriEntities();

        // GET: Opiskelijat
        public ActionResult Index()
        {
            List<OpiskelijaViewModel> model = new List<OpiskelijaViewModel>();
            KurssiRekisteriEntities entities = new KurssiRekisteriEntities();
            try
            {
                List<Opiskelija> opiskelija = entities.Opiskelija.OrderBy(Opiskelija => Opiskelija.OpiskelijaID).ToList();
                foreach (Opiskelija op in opiskelija)
                {
                    OpiskelijaViewModel view = new OpiskelijaViewModel();
                    view.OpiskelijaID = op.OpiskelijaID;
                    view.Etunimi = op.Etunimi;
                    view.Sukunimi = op.Sukunimi;
                    view.Opiskelijanro = op.Opiskelijanro;
                    view.Tutkinto = op.Tutkinto;

                    model.Add(view);
                }
            }
            finally
            {
                entities.Dispose();
            }
            return View(model);
        }

        // GET: Opiskelijat/Details/5
        public ActionResult Details(int? id)
        {
            OpiskelijaViewModel model = new OpiskelijaViewModel();
            KurssiRekisteriEntities entities = new KurssiRekisteriEntities();
            try
            {
                Opiskelija op = entities.Opiskelija.Find(id);
                if (op == null)
                {
                    return HttpNotFound();
                }
                OpiskelijaViewModel view = new OpiskelijaViewModel();
                view.OpiskelijaID = op.OpiskelijaID;
                view.Etunimi = op.Etunimi;
                view.Sukunimi = op.Sukunimi;
                view.Opiskelijanro = op.Opiskelijanro;
                view.Tutkinto = op.Tutkinto;
                model = view;
            }
            finally
            {
                entities.Dispose();
            }
            return View(model);
        }

        // GET: Opiskelijat/Create
        public ActionResult Create()
        {
            KurssiRekisteriEntities db = new KurssiRekisteriEntities();
            OpiskelijaViewModel model = new OpiskelijaViewModel();
            return View(model);
        }

        // POST: Opiskelijat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OpiskelijaViewModel model)
        {
            KurssiRekisteriEntities db = new KurssiRekisteriEntities();
            Opiskelija view = new Opiskelija();
            view.OpiskelijaID = model.OpiskelijaID;
            view.Etunimi = model.Etunimi;
            view.Sukunimi = model.Sukunimi;
            view.Opiskelijanro = model.Opiskelijanro;
            view.Tutkinto = model.Tutkinto;
            db.Opiskelija.Add(view);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("Index");
        }

        // GET: Opiskelijat/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opiskelija op = db.Opiskelija.Find(id);
            if (op == null)
            {
                return HttpNotFound();
            }
            OpiskelijaViewModel view = new OpiskelijaViewModel();
            view.OpiskelijaID = op.OpiskelijaID;
            view.Etunimi = op.Etunimi;
            view.Sukunimi = op.Sukunimi;
            view.Opiskelijanro = op.Opiskelijanro;
            view.Tutkinto = op.Tutkinto;

            return View(view);

        }

        // POST: Opiskelijat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OpiskelijaViewModel model)
        {
            Opiskelija view = db.Opiskelija.Find(model.OpiskelijaID);

            //view.CustomerID = model.CustomerID;
            view.OpiskelijaID = model.OpiskelijaID;
            view.Etunimi = model.Etunimi;
            view.Sukunimi = model.Sukunimi;
            view.Opiskelijanro = model.Opiskelijanro;
            view.Tutkinto = model.Tutkinto;

            db.SaveChanges();

            return View("Index");
        }

        // GET: Opiskelijat/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opiskelija op = db.Opiskelija.Find(id);
            if (op == null)
            {
                return HttpNotFound();
            }

            OpiskelijaViewModel view = new OpiskelijaViewModel();
            view.OpiskelijaID = op.OpiskelijaID;
            view.Etunimi = op.Etunimi;
            view.Sukunimi = op.Sukunimi;
            view.Opiskelijanro = op.Opiskelijanro;
            view.Tutkinto = op.Tutkinto;


            return View(view);
        }

        // POST: Opiskelijat/Delete/5
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
