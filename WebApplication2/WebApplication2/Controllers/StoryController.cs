using AutoMapper;
using BusniessLogic.ILogic;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.ModelsStoryController;

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
            Mapper.Initialize(c => c.CreateMap<Story, SubStoryIndexModel>());

            var storiesFinde =
               Mapper.Map<IEnumerable<Story>, List<SubStoryIndexModel>>(_bsl.FindeStories(userId, page - 1, pageSize));
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = _bsl.GetStoriesCount(userId) };

            IndexStoryViewModel svm = new IndexStoryViewModel { PageInfo = pageInfo, Stories = storiesFinde };
            ViewBag.UserId = userId;
            return View(svm);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Mapper.Initialize(c => c.CreateMap<Story, DetailsStoryViewModel>());
            
            var story= Mapper.Map<Story,DetailsStoryViewModel>( _bsl.FindeStory(id));
            ViewBag.UserId = story.UserId;
            return View(story);
        }
        [HttpPost]
        public ActionResult Details(DetailsStoryViewModel story)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", new { userId = story.UserId, page = 1 });
            }
            return RedirectToAction("Details", story.Id);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SelectList groups = new SelectList(_bsl.GetGroups(), "Id", "Name");
            ViewBag.Groups = groups;

            Mapper.Initialize(c => c.CreateMap<Story, EditStoryViewModel>());

            var story =
               Mapper.Map<Story, EditStoryViewModel>(_bsl.FindeStory(id));

            ViewBag.UserId = story.UserId;
            return View(story);
        }
        [HttpPost]
        public ActionResult Edit(EditStoryViewModel storyVM)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<EditStoryViewModel, Story>());
                var story = Mapper.Map<EditStoryViewModel, Story>(storyVM);
                _bsl.UpdateStory(story);
                return RedirectToAction("Index", new { userId = story.UserId, page = 1 });
            }
            SelectList groups = new SelectList(_bsl.GetGroups(), "Id", "Name");
            ViewBag.Groups = groups;
            return View("Edit", storyVM);
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
        public ActionResult Create( CreateStoryViewModel storyVM)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<CreateStoryViewModel, Story>());
                var story = Mapper.Map<CreateStoryViewModel, Story>(storyVM);
                _bsl.AddStory(story);
                return RedirectToAction("Index", new { userId = story.UserId, page = 1 });
            }
            SelectList groups = new SelectList(_bsl.GetGroups(), "Id", "Name");
            ViewBag.Groups = groups;
            return View("Create",storyVM);
        }
        protected override void Dispose(bool disposing)
        {
            _bsl.Dispose();
            base.Dispose(disposing);
        }
    }
}