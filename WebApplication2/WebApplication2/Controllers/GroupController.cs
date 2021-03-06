﻿using AutoMapper;
using BusniessLogic.ILogic;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.ModelsGroupController;
using WebApplication2.Utils;

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
            var groupsFinde = _bsl.FindeGroups(page - 1, pageSize);
            if (groupsFinde.Count() == 0)
            {
                return View( "Index");
            }
            var gropsVM= MappingHalpers.GroupToSubGroupIndexModel(groupsFinde);
             PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = _bsl.GetGroupCount() };
            var storyCounts = _bsl.GetGroupStoriesCount(groupsFinde).ToList();
            var userCounts = _ugBsl.GetUserGroupCount(groupsFinde).ToList();
            var gvm = new IndexGroupViewModel { PageInfo = pageInfo, StoryCount = storyCounts, UserCount = userCounts, Groups = gropsVM };
            ViewBag.UserId = userId;
          
            return View(gvm);
        }
        protected override void Dispose(bool disposing)
        {
            _bsl.Dispose();
            _ugBsl.Dispose();
            base.Dispose(disposing);
        }
    }
}