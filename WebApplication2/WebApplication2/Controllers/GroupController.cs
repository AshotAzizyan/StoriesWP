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
    public class GroupController : Controller
    {
        IGroupBL _bsl;
        IUserGroupBL _ugBsl;
        public GroupController(IGroupBL bsl, IUserGroupBL ugBs)
        {
            _bsl = bsl;
            _ugBsl = ugBs;
        }

        public ActionResult Index(int userId, int page=1)
        {
            int pageSize = 3; 
            IEnumerable<Group> gropsFinde = _bsl.FindeGroups(page-1, pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = _bsl.GetGroupCount() };
            var storyCounts = _bsl.GetGroupStoriesCount(gropsFinde).ToList();
            var userCounts = _ugBsl.GetUserGroupCount(gropsFinde).ToList();
            IndexGroupViewModel gvm = new IndexGroupViewModel { PageInfo = pageInfo, StoryCount= storyCounts, UserCount = userCounts,  Groups = gropsFinde };
            ViewBag.UserId = userId;
            return View(gvm);
        }
    }
}