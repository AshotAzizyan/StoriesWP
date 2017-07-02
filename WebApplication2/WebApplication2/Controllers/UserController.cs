using AutoMapper;
using BusniessLogic.ILogic;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.ModelsUserController;
using WebApplication2.Utils;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        IUserBL _bsl;
        public UserController(IUserBL bsl)
        {
            _bsl = bsl;
        }
        
        public ActionResult Index()
        {
            var gu = _bsl.GetUsers();
            var users = MappingHalpers.UserToUserIndexModel(gu);
            Mapper.Initialize(c => c.CreateMap<User, UserIndexModel>());
            ViewBag.UserId=1; // defoult user
            return View(users);
        }
        public ActionResult Create(UserIndexModel userM)
        {
            if (ModelState.IsValid)
            {
                var user = MappingHalpers.UserIndexModelToUser(userM); 
                _bsl.AddUser(user);
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            _bsl.Dispose();
            base.Dispose(disposing);
        }
    }
}