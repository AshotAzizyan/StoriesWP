using BusinessLogic.Logic;
using BusniessLogic.ILogic;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        IUserBL _bsl;

        public UserController(IUserBL bsl)
        {
            _bsl = bsl;
        }

        // GET: User
        public ActionResult Index()
        {
            var users = _bsl.GetUsers();
            ViewBag.UserId=1;
            return View(users);
        }
        public ActionResult Create(string name)
        {
            var user = new User() {Name=name };
            _bsl.AddUser(user);

            return RedirectToAction("Index");
        }
    }
}