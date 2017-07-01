using DataModel.Models;
using DataProvider.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.Unit
{
    public interface IUnitOfWork:IDisposable
    {
        IProvider <Story> Stories { get;  }
        IProvider<Group> Groups { get; }
        IUserProvider Users  { get; }
        IUserGroupProvider UserGroups { get; }
        void Save();
    }
}
