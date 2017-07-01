using BusinessLogic.Logic;
using BusniessLogic.ILogic;
using BusniessLogic.Logic;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Utils
{
    public class NinjectDR : IDependencyResolver
    {
        private IKernel _kernel;
        public NinjectDR(IKernel kernel)
        {
            _kernel = kernel;
            AddBind();
        }

        private void AddBind()
        {
            _kernel.Bind<IGroupBL>().To<GroupBL>();
            _kernel.Bind<IStoryBL>().To<StoryBL>();
            _kernel.Bind<IUserBL>().To<UserBL>();
            _kernel.Bind<IUserGroupBL>().To<UserGroupBL>();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}