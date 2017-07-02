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
using WebApplication2.Models.ModelsStoryController;

namespace TestStoryWS.ControllersTest
{
    [TestClass]
    public class StoryControllerTest
    {
        [TestMethod]
        public void StoryIndexViewModelNotNull()
        {
            var mock = new Mock<IStoryBL>();
            mock.Setup(a => a.FindeStories(-1,-1,0)).Returns(new List<Story>());
            mock.Setup(a => a.GetStoriesCount(-1));
            var controller = new StoryController(mock.Object);

            var result = controller.Index(-1,2) as ViewResult;

            Assert.IsNotNull(result.Model);
        }
        [TestMethod]
        public void StoryCreatePostActionModelError()
        {
            var mock = new Mock<IStoryBL>();
            var story = new CreateStoryViewModel();
            var controller = new StoryController(mock.Object);
            controller.ModelState.AddModelError("Name", "Error models name");

            var result = controller.Create(story) as ViewResult;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void StoryEditPostActionModelError()
        {
            var mock = new Mock<IStoryBL>();
            var story = new EditStoryViewModel();
            var controller = new StoryController(mock.Object);
            controller.ModelState.AddModelError("Name", "Error models name");

            var result = controller.Edit(story) as ViewResult;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void StoryEditViewModelNotNull()
        {
            var mock = new Mock<IStoryBL>();
            mock.Setup(a => a.GetGroups()).Returns(new List<Group>());
            var controller = new StoryController(mock.Object);

            var result = controller.Index(-1, 0) as ViewResult;

            Assert.IsNotNull(result.Model);
        }
        [TestMethod]
        public void StoryDetailsPostActionModelError()
        {
            var mock = new Mock<IStoryBL>();
            var story = new DetailsStoryViewModel();
            var controller = new StoryController(mock.Object);
            controller.ModelState.AddModelError("Name", "Error models name");

            var result = controller.Details(story) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

    }
}
