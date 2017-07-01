using AutoMapper;
using BusniessLogic.ILogic;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.ModelsUserController;

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
            Mapper.Initialize(c => c.CreateMap<User, UserIndexModel>());

            var users =
               Mapper.Map<IEnumerable<User>, List<UserIndexModel>>(_bsl.GetUsers());
            ViewBag.UserId=1;
            return View(users);
        }
        public ActionResult Create(UserIndexModel userM)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserIndexModel, User>());
            var user = Mapper.Map<UserIndexModel, User>(userM);
            _bsl.AddUser(user);

            return RedirectToAction("Index");
        }
    }
}