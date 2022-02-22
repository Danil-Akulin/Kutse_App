using Kutse_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kutse_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() //открывает страницу индекс
        {
            ViewBag.Message = "Ootan sind oma peole! Palun tule kindlasti!";
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Tere hommikust!" : "Tere päeva";
            ViewBag.Greeting = hour > 12 ? "Tere õhtul!" : "Tere päeva";
            //ViewData 
            return View();
        }
        [HttpGet]
        public ViewResult Ankeet()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Ankeet(Guest guest)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }
        public void E_mail(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "programmeeriminetthk2@gmail.com";
                WebMail.Password = "2.kuursus tarpv20";
                WebMail.From = "programmerimine@gmail.com";
                WebMail.Send("programmeeriminetthk2@gmail.com", "Vastus kutsele", guest.Name + " vastas " + ((guest.WillAttend ?? false) ?
                    "tuleb poole " : "ei tule poole"));
                    ViewBag.Message = "Kiri on saatnud!";
            }
            catch (Exception)
            {

                ViewBag.Message = "Mul on kahju!Ei saa kitja saada!!!";
            }
        }
        public ActionResult About() //открывает страницу about
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