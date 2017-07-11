using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models;
using DataProvider.IProviders;
using DataProvider.Context;
using DataProvider.Providers;

namespace DataProvider.Unit
{
    public class UnitOfWork : IUnitOfWork
    {
        private StoryContext dbContex;
        private GroupProvider groupProvider;
        private StoryProvider storyProvider;
        private UserProvider userProvider;
        private UserGroupProvider userGroupProvider;
        public UnitOfWork(string conectionString)
        {
            dbContex = new StoryContext(conectionString); // tam defoult
         
        }
        public IProvider<Story> Stories {
            get
            {
                if (storyProvider == null)
                {
                    storyProvider = new StoryProvider(dbContex);
                }
                return storyProvider;
            }
        }
        public IProvider<Group> Groups {
            get
            {
                if(groupProvider==null)
                {
                    groupProvider = new GroupProvider(dbContex);
                }
                return groupProvider;
            }       
        } 
        public IUserProvider Users {
            get
            {
                if(userProvider==null)
                {
                    userProvider = new UserProvider(dbContex);
                }
                return userProvider;
            }
        }
        public IUserGroupProvider UserGroups
        {
            get
            {
                if (userProvider == null)
                {
                    userGroupProvider = new UserGroupProvider(dbContex);
                }
                return userGroupProvider;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContex.Dispose();
                }
                this.disposed = true;
            }
        }


        public void Save()
        {
            dbContex.SaveChanges();
        }
   
    }
}
