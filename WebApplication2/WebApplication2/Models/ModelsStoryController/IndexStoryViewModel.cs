using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ModelsStoryController
{
    public class IndexStoryViewModel
    {
        public IEnumerable<SubStoryIndexModel> Stories { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}