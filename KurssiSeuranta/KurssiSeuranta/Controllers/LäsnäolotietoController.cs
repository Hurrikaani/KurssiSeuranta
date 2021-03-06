﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KurssiSeuranta.Models;
using KurssiSeuranta.ViewModels;
using Newtonsoft.Json;
using KurssiSeuranta.Utilities;

namespace KurssiSeuranta.Controllers
{
    public class LäsnäolotietoController : Controller
    {
        private KurssiRekisteriEntities db = new KurssiRekisteriEntities();

        // GET: Läsnäolotieto
        public ActionResult Index()
        {
            List<LasnaolotietoViewModel> model = new List<LasnaolotietoViewModel>();
            KurssiRekisteriEntities entities = new KurssiRekisteriEntities();
            try
            {
                List<Läsnäolotiedot> läsnäolotiedot = entities.Läsnäolotiedot.OrderBy(Läsnäolotiedot => Läsnäolotiedot.RekisteriID).ToList();
                foreach (Läsnäolotiedot läs in läsnäolotiedot)
                {
                    LasnaolotietoViewModel view = new LasnaolotietoViewModel();
                    view.Kirjautuminen_sisään = läs.Kirjautuminen_sisään.GetValueOrDefault();
                    view.Kirjautuminen_ulos = läs.Kirjautuminen_ulos.GetValueOrDefault();
                    view.Luokkanumero = läs.Luokkanumero;
                    view.RekisteriID = läs.RekisteriID;
                    view.OpettajaID = läs.OpettajaID;
                    view.KurssiID = läs.KurssiID;
                    view.OpiskelijaID = läs.OpiskelijaID;
                    view.LuokkaID = läs.LuokkaID;

                    //kkkk
                    //Kurssitaulu
                    view.Kurssinimi = läs.Kurssi?.Kurssinimi;
                    view.Kurssikoodi = läs.Kurssi?.Kurssikoodi;

                    //opetustila taulu
                    view.LuokanNimi = läs.OpetusTila?.LuokanNimi;
                    view.LuokkaKoodi = läs.OpetusTila?.LuokkaKoodi;

                    //Opettaja taulu
                    // view.Etunimi = läs.Opettaja?.Etunimi;
                    //view.Sukunimi = läs.Opettaja?.Sukunimi;
                    //  view.Opettajanro = läs.Opettaja.Opettajanro;
                    view.OpettajaNimi = läs.Opettaja?.Etunimi + " " + läs.Opettaja?.Sukunimi;


                    //Opiskelija taulu
                    view.OpiskelijaNimi = läs.Opiskelija?.Etunimi + " " + läs.Opiskelija?.Sukunimi;


                    


                    model.Add(view);
                }
            }
            finally
            {
                entities.Dispose();
            }
            return View(model);
        }

        public ActionResult TallennaLasnaOlo()
        {
            KurssiRekisteriEntities entities = new KurssiRekisteriEntities();
            List<LasnaolotietoViewModel> model = new List<LasnaolotietoViewModel>();
            try
            {
                List<Läsnäolotiedot> läs = entities.Läsnäolotiedot.ToList();
                foreach (Läsnäolotiedot lä in läs)
                {
                    LasnaolotietoViewModel view = new LasnaolotietoViewModel();
                    view.Kirjautuminen_sisään = lä.Kirjautuminen_sisään.GetValueOrDefault();
                    view.Kirjautuminen_ulos = lä.Kirjautuminen_ulos.GetValueOrDefault();
                    view.RekisteriID = lä.RekisteriID;
                    view.KirjattuID = lä.KirjattuID;
                    view.KurssiID = lä.KurssiID;
                    view.OpiskelijaID = lä.OpiskelijaID;
                    view.Opiskelijanro = lä.Opiskelija?.Opiskelijanro;
                    view.Kurssikoodi = lä.Kurssi?.Kurssikoodi;
                    view.KurssiRekisteriID = lä.KurssiRekisteriID;
                    view.KirjattuUlosID = lä.KirjattuUlosID;
                    view.KurssiUlosID = lä.KurssiUlosID;

                    model.Add(view);

                }

            }
            finally
            {
                entities.Dispose();
            }
            return View(model);
        }



        [HttpPost]
        public JsonResult TallennaLasnaolo()
        {

            string json = Request.InputStream.ReadToEnd();
            KurssiDataModel inputData = JsonConvert.DeserializeObject<KurssiDataModel>(json);
            bool success = false;
            string error = " ";
            KurssiRekisteriEntities entities = new KurssiRekisteriEntities();
            try
            {
                int opiskelijaId = (from op in entities.Opiskelija
                                    where op.Opiskelijanro == inputData.Opiskelijanro
                                    select op.OpiskelijaID).FirstOrDefault();

                int kurssiId = (from kur in entities.Kurssi
                                where kur.Kurssikoodi == inputData.Kurssikoodi
                                select kur.KurssiID).FirstOrDefault();


                if((opiskelijaId > 0) && (kurssiId > 0))
                {
                    Läsnäolotiedot newEntry = new Läsnäolotiedot();
                    newEntry.KirjattuID = opiskelijaId;
                    newEntry.KurssiRekisteriID = kurssiId;
                    newEntry.Kirjautuminen_sisään = DateTime.Now;

                    entities.Läsnäolotiedot.Add(newEntry);
                    entities.SaveChanges();
                    success = true;
                }


            }
            catch (Exception ex)
            {
                error = ex.GetType().Name + ": " + ex.Message;
            }
            finally
            {
                entities.Dispose();
            }
            var result = new { success = success, error = error };
            return Json(result);
        }


        //Uloskirjaus
        [HttpPost]
        public JsonResult TallennaUlosKirjaus()
        {

            string json = Request.InputStream.ReadToEnd();
            KurssiDataModel inputData = JsonConvert.DeserializeObject<KurssiDataModel>(json);
            bool success = false;
            string error = " ";
            KurssiRekisteriEntities entities = new KurssiRekisteriEntities();
            try
            {
                int opiskelijaId = (from op in entities.Opiskelija
                                    where op.Opiskelijanro == inputData.Opiskelijanro
                                    select op.OpiskelijaID).FirstOrDefault();

                int kurssiId = (from kur in entities.Kurssi
                                where kur.Kurssikoodi == inputData.Kurssikoodi
                                select kur.KurssiID).FirstOrDefault();


                if ((opiskelijaId > 0) && (kurssiId > 0))
                {
                    Läsnäolotiedot newEntry = new Läsnäolotiedot();
                    newEntry.KirjattuUlosID = opiskelijaId;
                    newEntry.KurssiUlosID = kurssiId;
                    newEntry.Kirjautuminen_ulos = DateTime.Now;

                    entities.Läsnäolotiedot.Add(newEntry);
                    entities.SaveChanges();
                    success = true;
                }


            }
            catch (Exception ex)
            {
                error = ex.GetType().Name + ": " + ex.Message;
            }
            finally
            {
                entities.Dispose();
            }
            var result = new { success = success, error = error };
            return Json(result);
        }
        // GET: Läsnäolotieto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Läsnäolotiedot läsnäolotiedot = db.Läsnäolotiedot.Find(id);
            if (läsnäolotiedot == null)
            {
                return HttpNotFound();
            }
            return View(läsnäolotiedot);
        }

        // GET: Läsnäolotieto/Create
        //public ActionResult Create()
        //{

        //    KurssiRekisteriEntities db = new KurssiRekisteriEntities();
        //    LasnaolotietoViewModel model = new LasnaolotietoViewModel();

           



            //ViewBag.KurssiID = new SelectList(db.Kurssi, "KurssiID", "Kurssinimi");
            //ViewBag.LuokkaID = new SelectList(db.OpetusTila, "LuokkaID", "LuokanNimi");
            //ViewBag.OpettajaID = new SelectList(db.Opettaja, "OpettajaID", "Etunimi");
            //ViewBag.OpiskelijaID = new SelectList(db.Opiskelija, "OpiskelijaID", "Etunimi");
            //return View(model);
       // }

        // POST: Läsnäolotieto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(LasnaolotietoViewModel model)
        //{




            //KurssiRekisteriEntities db = new KurssiRekisteriEntities();
            //Läsnäolotiedot las = new Läsnäolotiedot();

            //las.Kirjautuminen_sisään = model.Kirjautuminen_sisään;
            //las.Kirjautuminen_ulos = model.Kirjautuminen_ulos;
            //las.Luokkanumero = model.Luokkanumero;

            //db.Läsnäolotiedot.Add(las);

            //int opiskelijaId = int.Parse(model.Etunimi);

            //if(opiskelijaId > 0)
            //{
            //    Opiskelija op = db.Opiskelija.Find(opiskelijaId);
            //    las.OpiskelijaID = op.OpiskelijaID;
            //}
            //try
            //{
            //    db.SaveChanges();

            //}
            //catch (Exception ex)
            //{

            //    throw;
           // }

            //ViewBag.KurssiID = new SelectList(db.Kurssi, "KurssiID", "Kurssinimi", läsnäolotiedot.KurssiID);
            //ViewBag.LuokkaID = new SelectList(db.OpetusTila, "LuokkaID", "LuokanNimi", läsnäolotiedot.LuokkaID);
            //ViewBag.OpettajaID = new SelectList(db.Opettaja, "OpettajaID", "Etunimi", läsnäolotiedot.OpettajaID);
            //ViewBag.OpiskelijaID = new SelectList(db.Opiskelija, "OpiskelijaID", "Etunimi", läsnäolotiedot.OpiskelijaID);

            //return RedirectToAction("Index");
       // }

        // GET: Läsnäolotieto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Läsnäolotiedot läs = db.Läsnäolotiedot.Find(id);
            if (läs == null)
            {
                return HttpNotFound();
            }
            LasnaolotietoViewModel view = new LasnaolotietoViewModel();
            view.Kirjautuminen_sisään = läs.Kirjautuminen_sisään.Value;
            view.Kirjautuminen_ulos = läs.Kirjautuminen_ulos.Value;
            view.Luokkanumero = läs.Luokkanumero;
            view.RekisteriID = läs.RekisteriID;
            view.OpettajaID = läs.OpettajaID;
            view.KurssiID = läs.KurssiID;
            view.OpiskelijaID = läs.OpiskelijaID;
            view.LuokkaID = läs.LuokkaID;

            //Kurssitaulu
            view.Kurssinimi = läs.Kurssi?.Kurssinimi;
            view.Kurssikoodi = läs.Kurssi?.Kurssikoodi;

            //opetustila taulu
            view.LuokanNimi = läs.OpetusTila?.LuokanNimi;
            view.LuokkaKoodi = läs.OpetusTila?.LuokkaKoodi;

            //Opettaja taulu
            // view.Etunimi = läs.Opettaja?.Etunimi;
            //view.Sukunimi = läs.Opettaja?.Sukunimi;
            //  view.Opettajanro = läs.Opettaja.Opettajanro;
            view.OpettajaNimi = läs.Opettaja?.Etunimi + " " + läs.Opettaja?.Sukunimi;


            //Opiskelija taulu
            view.OpiskelijaNimi = läs.Opiskelija?.Etunimi + " " + läs.Opiskelija?.Sukunimi;



            return View(view);
        }

        // POST: Läsnäolotieto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LasnaolotietoViewModel model)


        {
            Läsnäolotiedot view = db.Läsnäolotiedot.Find(model.RekisteriID);
            view.Kirjautuminen_sisään = model.Kirjautuminen_sisään.Value;
            view.Kirjautuminen_ulos = model.Kirjautuminen_ulos.Value;
            view.Luokkanumero = model.Luokkanumero;
            view.RekisteriID = model.RekisteriID;
            view.OpettajaID = model.OpettajaID;
            view.KurssiID = model.KurssiID;
            view.OpiskelijaID = model.OpiskelijaID;
            view.LuokkaID = model.LuokkaID;

            //Kurssitaulu

            int kurssiID = int.Parse(model.Kurssikoodi);
            if (kurssiID > 0)
            {
                Kurssi kurs = db.Kurssi.Find(kurssiID);
                view.KurssiID = kurs.KurssiID;
            }


           

            //opetustila taulu


            int luokkaID = int.Parse(model.LuokkaKoodi);
            if (luokkaID > 0)
            {
                OpetusTila opet = db.OpetusTila.Find(luokkaID);
                view.LuokkaID = opet.LuokkaID;
            }




            //Opettaja taulu
            // view.Etunimi = läs.Opettaja?.Etunimi;
            //view.Sukunimi = läs.Opettaja?.Sukunimi;
            //  view.Opettajanro = läs.Opettaja.Opettajanro;
            //view.OpettajaNimi = model.Opettaja?.Etunimi + " " + model.Opettaja?.Sukunimi;


            //Opiskelija taulu

            int opiskelijaID = int.Parse(model.Opiskelijanro);
            if (opiskelijaID > 0)
            {
                Opiskelija opis = db.Opiskelija.Find(opiskelijaID);
                view.OpiskelijaID = opis.OpiskelijaID;
            }
            db.SaveChanges();
            return View("Index");
        }

        // GET: Läsnäolotieto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Läsnäolotiedot läsnäolotiedot = db.Läsnäolotiedot.Find(id);
            if (läsnäolotiedot == null)
            {
                return HttpNotFound();
            }
            return View(läsnäolotiedot);
        }

        // POST: Läsnäolotieto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Läsnäolotiedot läsnäolotiedot = db.Läsnäolotiedot.Find(id);
            db.Läsnäolotiedot.Remove(läsnäolotiedot);
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