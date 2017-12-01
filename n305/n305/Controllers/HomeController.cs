using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace n305.Controllers
{
    public abstract class AbstractController:Controller
    {
        public n305.Models.Navigation.MyWebSites INavigation = new n305.Models.Navigation.MyWebSites();
        
        public ActionResult ThisLayout()
        {
            ViewBag.ThisModel = INavigation.SelectedWebSite;
            ViewBag.SiteNames = INavigation.GetList();
            ViewBag.Model = INavigation;

            return PartialView();
        }
 
    }

    public class HomeController : AbstractController
    {
      
        public ActionResult Index()
        {
            ThisLayout();

            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
         
            return View();
            
         }

        public ActionResult Menu()
        {
            ThisLayout();

            ViewBag.Message = "Main Menu";

            return View();
        }

        public ActionResult About()
        {
            ThisLayout();

            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ThisLayout();
                       
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Gallery()
        {
            ThisLayout();

            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            ThisLayout();

            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Lab()
        {
            ThisLayout();

            ViewBag.Message = "Your app description page.";

            return View();
        }

        //public ActionResult AngularDemo1()
        //{
        //    ThisLayout();

        //    ViewBag.Message = "Your app description page.";

        //    return Redirect("http://angularjsdemo1.azurewebsites.net/#/videoView");
        //}

        //[HttpGet,ActionName("Send")]
        public ActionResult Email(String Name, String Email, String Message)
        {
            return RedirectToAction("ProcessRequest", new { 
                GetName = Name, 
                GetEmail = Email, 
                GetMessage = Message });
        }

        public ActionResult ProcessRequest(String GetName, String GetEmail, String GetMessage)
        {
            ViewBag.Name = GetName;
            ViewBag.Email = GetEmail;
            ViewBag.Message = GetMessage;

            ThisLayout();
            return View();
        }

 

        [HttpPost, ActionName("NavTo")]
        public ActionResult NavigationMenu(int SelectedWebSite)
        {
            var NavigateToThisWebSite = INavigation.GetUrl(SelectedWebSite);
            return Redirect(NavigateToThisWebSite);
        }

    }
}
