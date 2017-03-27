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
    public class ProffesionsController : Controller
    {
        private VoilaEntities db = new VoilaEntities();

        // GET: Proffesions
        public ActionResult Index()
        {
            return View(db.Proffesions.ToList());
        }

        // GET: Proffesions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proffesion proffesion = db.Proffesions.Find(id);
            if (proffesion == null)
            {
                return HttpNotFound();
            }
            return View(proffesion);
        }

        // GET: Proffesions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proffesions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProffesionId,ProffesionName")] Proffesion proffesion)
        {
            if (ModelState.IsValid)
            {
                db.Proffesions.Add(proffesion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proffesion);
        }

        // GET: Proffesions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proffesion proffesion = db.Proffesions.Find(id);
            if (proffesion == null)
            {
                return HttpNotFound();
            }
            return View(proffesion);
        }

        // POST: Proffesions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProffesionId,ProffesionName")] Proffesion proffesion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proffesion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proffesion);
        }

        // GET: Proffesions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proffesion proffesion = db.Proffesions.Find(id);
            if (proffesion == null)
            {
                return HttpNotFound();
            }
            return View(proffesion);
        }

        // POST: Proffesions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proffesion proffesion = db.Proffesions.Find(id);
            db.Proffesions.Remove(proffesion);
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
