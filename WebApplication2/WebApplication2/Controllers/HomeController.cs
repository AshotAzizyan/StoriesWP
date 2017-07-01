using BusinessLogic;
using BusinessLogic.Logic;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        //IBusinessLogicAll _bsl;
        //public HomeController(IBusinessLogicAll bsl)
        //{
        //    _bsl = bsl;
        //}
        [HttpGet]
        public ActionResult Index()
        {
            //var users = _bsl.GetUsers();

            return View();
        }
        //[HttpPost]
        //public ActionResult AutentificationUser(string Login, string SigneUp, string action)
        //{
        //    if(action== "login")
        //    {
        //        var user = _bsl.GetUser(Login);
        //        if (user == null)
        //        {
        //            return View("Index"); // messige chka tenc yuser
        //        }
        //        return RedirectToAction("MyPage"); // kanchuma sra get@ // vew kanchuma vew
        //    }
        //    else if(action== "signeUp")
        //    {
        //        var user = new User() { Name = SigneUp };
        //        _bsl.AddUser(user);// mesig vor normal grancvela
        //        return View("Index");
        //    }
        //    return View();
        //}
     
        [HttpGet]
        public ActionResult MyPage(User user)
        {

            return View(); 
        }
        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult About(string f)
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CreateNewStory(Story story)
        {
            ViewBag.Message = "New Story Create.";

           // IUserLogic logic;// =// ninject resolve
         //   logic.PostStory(story);
            return View();
        }
    }
}