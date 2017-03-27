using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class ProfilesController : Controller
    {
        private VoilaEntities db = new VoilaEntities();

        // GET: Profiles
        public ActionResult Index()
        {
            var profiles = db.Profiles.Include(p => p.City).Include(p => p.Gender).Include(p => p.Price).Include(p => p.Proffesion).Include(p => p.Speciality);
            return View(profiles.ToList());
        }

        // GET: Profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "CityId", "CityName");
            ViewBag.GenderID = new SelectList(db.Genders, "GenderId", "GenderName");
            ViewBag.PriceID = new SelectList(db.Prices, "PriceId", "Price1");
            ViewBag.ProffesionID = new SelectList(db.Proffesions, "ProffesionId", "ProffesionName");
            ViewBag.SpecialityID = new SelectList(db.Specialities, "SpecialityId", "SpecialityName");
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfileId,ProfileName,ProffesionID,CityID,PriceID,SpecialityID,GenderID,Bio,Image,Address,PhoneNumber,ProfileEmail")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "CityId", "CityName", profile.CityID);
            ViewBag.GenderID = new SelectList(db.Genders, "GenderId", "GenderName", profile.GenderID);
            ViewBag.PriceID = new SelectList(db.Prices, "PriceId", "Price1", profile.PriceID);
            ViewBag.ProffesionID = new SelectList(db.Proffesions, "ProffesionId", "ProffesionName", profile.ProffesionID);
            ViewBag.SpecialityID = new SelectList(db.Specialities, "SpecialityId", "SpecialityName", profile.SpecialityID);
            return View(profile);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityId", "CityName", profile.CityID);
            ViewBag.GenderID = new SelectList(db.Genders, "GenderId", "GenderName", profile.GenderID);
            ViewBag.PriceID = new SelectList(db.Prices, "PriceId", "Price1", profile.PriceID);
            ViewBag.ProffesionID = new SelectList(db.Proffesions, "ProffesionId", "ProffesionName", profile.ProffesionID);
            ViewBag.SpecialityID = new SelectList(db.Specialities, "SpecialityId", "SpecialityName", profile.SpecialityID);
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfileId,ProfileName,ProffesionID,CityID,PriceID,SpecialityID,GenderID,Bio,Image,Address,PhoneNumber,ProfileEmail")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityId", "CityName", profile.CityID);
            ViewBag.GenderID = new SelectList(db.Genders, "GenderId", "GenderName", profile.GenderID);
            ViewBag.PriceID = new SelectList(db.Prices, "PriceId", "Price1", profile.PriceID);
            ViewBag.ProffesionID = new SelectList(db.Proffesions, "ProffesionId", "ProffesionName", profile.ProffesionID);
            ViewBag.SpecialityID = new SelectList(db.Specialities, "SpecialityId", "SpecialityName", profile.SpecialityID);
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
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
