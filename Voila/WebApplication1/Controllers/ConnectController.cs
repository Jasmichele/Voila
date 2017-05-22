using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ConnectController : Controller
    {
        VoilaEntities db = new VoilaEntities();
        // GET: Connect
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetByFilter()
        {
            ConnectModel looking = new ConnectModel();

            VoilaEntities db = new VoilaEntities();
            looking.Cities = db.Cities.ToList();
            looking.Proffesions = db.Proffesions.ToList();
            looking.Price = db.Prices.ToList();

            return View(looking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetByFilter(FormCollection form)
        {
            string cit = form["City"].ToString();
            string pro = form["Proffesion"].ToString();
            string pri = form["Prie"].ToString();

            return RedirectToAction("GetUsers", new { cid = cit, pid = pro, prid = pri });
        }

        public ActionResult GetUsers(int? cid, int? pid, int? prid)
        {
            var pros = from pr in db.Profiles
                       select pr;

            var filteredPros = pros;

            int tempCid = Convert.ToInt32(cid);
            int tempPid = Convert.ToInt32(pid);
            int tempPrid = Convert.ToInt32(prid);

            if (cid != null)
                filteredPros = filteredPros.Where(s => s.CityID == tempCid);

            if (pid != null)
                filteredPros = filteredPros.Where(s => s.ProffesionID == tempPid);

            if (prid != null)
                filteredPros = filteredPros.Where(s => s.PriceID == tempPrid);

            return View(filteredPros);
        }
    }
}