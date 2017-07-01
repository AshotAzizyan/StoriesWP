using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.IProviders
{
    public interface IUserGroupProvider
    {
        IEnumerable<UserGroup> GetAll();
        UserGroup GetById(int id);
        int GetCount(int groupId);
    }
}
