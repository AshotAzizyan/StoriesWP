using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class IndexGroupViewModel
    {
        public IEnumerable<Group> Groups { get; set; }
        public PageInfo PageInfo { get; set; }
        public List<int> UserCount { get; set; }
        public List<int> StoryCount { get; set; }
    }
}
