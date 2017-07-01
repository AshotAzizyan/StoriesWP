using BusniessLogic.ILogic;
using DataModel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication2.Controllers;
using WebApplication2.Models.ModelsGroupController;

namespace TestStoryWS.ControllersTest
{
    [TestClass]
    public  class GroupControllerTest
    {
        [TestMethod]
        public void GroupIndexViewResaultNotNull()
        {
            var mockG =new  Mock<IGroupBL>();
            mockG.Setup(a => a.FindeGroups(1, 2)).Returns(new List<Group>());
            var mockUG =new  Mock<IUserGroupBL>();
            mockUG.Setup(a => a.GetUserGroupCount(new List<Group>()));

            var groupController = new GroupController( mockG.Object, mockUG.Object);

            var result = groupController.Index(-1,-1) as ViewResult;

            Assert.IsNotNull(result);
        }
      
    }
}
