using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGallery.Core;

namespace WebGallery.Controllers
{
    public class FrontController : Controller
    {
        // GET: Front
        public ActionResult Index()
        {
            return View();
        }


        public string Square(int a = 10, int h = 3)
        {
            double s = a*h/2;
            return $"<h2> Площадь треугольника с основанием {a} и высотой {h} равна {s} </h2>";
        }

        public string Square()
        {
            int a = Int32.Parse(Request.Params["a"]);
            int h = Int32.Parse(Request.Params["h"]);
            double s = a*h/2;
            return $"<h2> Площадь треугольника с основанием {a} и высотой {h} равна {s} </h2>";
        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("Goziraga!");
        }

        public ActionResult GetImage()
        {
            string path = "../Images/visualstudio.png";
            return new ImageResult(path);
        }

        public RedirectResult TestMethod()
        {
            return Redirect("/Home/Index");
            return RedirectPermanent("/Home/Index");
        }

        public RedirectToRouteResult TestRedirect2()
        {
            return RedirectToRoute(new {controller = "Home", action ="Index"});
            return RedirectToAction("Square,Front",new {a=10,h=12});

        }

        public ActionResult TestErrors(int age)
        {
            if (age<21)
            {
                return new HttpStatusCodeResult(404);
                return HttpNotFound();
                return new HttpUnauthorizedResult();
            }
            return View();
        }

        public FileResult GetFile()
        {
            // Путь к файлу
            string file_path = Server.MapPath("~/Files/PDFIcon.pdf");
            // Тип файла - content-type
            string file_type = "application/pdf";
            // Имя файла - необязательно
            string file_name = "PDFIcon.pdf";
            return File(file_path, file_type, file_name);
        }

        // Отправка массива байтов
        public FileResult GetBytes()
        {
            string path = Server.MapPath("~/Files/PDFIcon.pdf");
            byte[] mas = System.IO.File.ReadAllBytes(path);
            string file_type = "application/pdf";
            string file_name = "PDFIcon.pdf";
            return File(mas, file_type, file_name);
        }


        // Отправка потока
        public FileResult GetStream()
        {
            string path = Server.MapPath("~/Files/PDFIcon.pdf");
            // Объект Stream
            FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "application/pdf";
            string file_name = "PDFIcon.pdf";
            return File(fs, file_type, file_name);
        }


        public ActionResult TestResponse()
        {
            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;

            return new HtmlResult("<p>Browser: " + browser + "</p><p>User-Agent: " + user_agent + "</p><p>Url запроса: " + url +
        "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>");
        }


        public ActionResult TestResult()
        {
            HttpContext.Response.Write("<h1>Hello World</h1>");

            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            return new HtmlResult("<p>User-Agent: " + user_agent + "</p><p>Url запроса: " + url +
                "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>");
        }

        public ActionResult TestUserCoockies()
        {
            bool IsAdmin = HttpContext.User.IsInRole("admin"); // определяем, принадлежит ли пользователь к администраторам
            bool IsAuth = HttpContext.User.Identity.IsAuthenticated; // аутентифицирован ли пользователь
            string login = HttpContext.User.Identity.Name; // логин авторизованного пользователя


            HttpContext.Response.Cookies["id"].Value = "ca-4353w";
            string id = HttpContext.Request.Cookies["id"].Value;

            Session["name"] = "Tom";
            var val = Session["name"];

            return new HtmlResult("Blast!");
        }

    }
}