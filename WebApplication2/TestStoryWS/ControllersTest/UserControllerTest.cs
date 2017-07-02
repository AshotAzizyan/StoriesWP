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
using WebApplication2.Models.ModelsUserController;

namespace TestStoryWS.ControllersTest
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void UserIndexViewModelNotNull()
        {
            var mock = new Mock<IUserBL>();
            mock.Setup(a => a.GetUsers()).Returns(new List<User>());
            var controller = new UserController(mock.Object);
            
            var result = controller.Index() as ViewResult;
            
            Assert.IsNotNull(result.Model);
        }
        [TestMethod]
        public void UserCreatePostActionModelError()
        {
            var mock = new Mock<IUserBL>();
            var user = new UserIndexModel();
            var controller = new UserController(mock.Object);
            controller.ModelState.AddModelError("Name", "Error models name");
           
            var result = controller.Create(user) as RedirectToRouteResult;
           
            Assert.IsNotNull(result);
        }
    }
}
