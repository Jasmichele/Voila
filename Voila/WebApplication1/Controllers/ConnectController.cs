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
            looking.City = db.Cities.ToList();
            looking.Proffesion = db.Proffesions.ToList();
            looking.Price = db.Prices.ToList();

            return View(looking);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetByFilter(FormCollection form)
        {

        }

    }
}