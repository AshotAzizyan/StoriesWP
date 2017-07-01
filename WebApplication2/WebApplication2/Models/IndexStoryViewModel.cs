using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class IndexStoryViewModel
    {
        public IEnumerable<Story> Stories { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}