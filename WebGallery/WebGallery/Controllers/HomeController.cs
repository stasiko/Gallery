using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGallery.Models;

namespace WebGallery.Controllers
{
    public class HomeController : Controller
    {
        GalleryContext db = new GalleryContext();

        public ActionResult Index()
        {
            IEnumerable<Country> countries = db.Countries;
            IEnumerable<City> cities = db.Cities;
            IEnumerable<Continent> continents = db.Continents;

            ViewBag.Countries = countries.ToList();
            ViewBag.Continents = continents.ToList();
            ViewBag.Cities = cities.ToList();

            return View();
        }

        [HttpGet]
        public ActionResult SetVisited(int id)
        {
            ViewBag.CityId = id;
            return View();
        }

        [HttpGet]
        public ActionResult Set(int id)
        {
            ViewBag.CityId = id;
            return View();
        }

        [HttpPost]
        public string Set(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо," + purchase.Person + ", за изменение данных!";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}