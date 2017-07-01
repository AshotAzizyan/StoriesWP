using BusinessLogic.Logic;
using BusniessLogic.ILogic;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StoryController : Controller
    {
        // GET: Story
        IStoryBL _bsl;

        public StoryController(IStoryBL bsl)
        {
            _bsl = bsl;
        }
        public ActionResult Index(int userId, int page=1)
        {
            int pageSize = 3;
            IEnumerable<Story> storiesFinde = _bsl.FindeStories(userId, page - 1, pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = _bsl.GetStoriesCount(userId) };

            IndexStoryViewModel svm = new IndexStoryViewModel { PageInfo = pageInfo, Stories = storiesFinde };
            ViewBag.UserId = userId;
            return View(svm);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var story= _bsl.FindeStory(id);
            ViewBag.UserId = story.UserId;
            return View(story);
        }
        [HttpPost]
        public ActionResult Details(Story story)
        {
            return RedirectToAction("Index", new { userId = story.UserId , page = 1 });
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SelectList groups = new SelectList(_bsl.GetGroups(), "Id", "Name");
            ViewBag.Groups = groups;
            var story = _bsl.FindeStory(id);
            ViewBag.UserId = story.UserId;
            return View(story);
        }
        [HttpPost]
        public ActionResult Edit(Story story)
        {
            _bsl.UpdateStory(story);
            return RedirectToAction("Index", new { userId = story.UserId, page = 1 });
        }
        [HttpGet]
        public ActionResult Create(int userId)
        {
            SelectList groups = new SelectList(_bsl.GetGroups(), "Id", "Name");
            ViewBag.Groups = groups;
            ViewBag.UserId = userId;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Story story)
        {
            _bsl.AddStory(story);
            return RedirectToAction("Index",new {userId= story.UserId, page = 1 });
        }
    }
}