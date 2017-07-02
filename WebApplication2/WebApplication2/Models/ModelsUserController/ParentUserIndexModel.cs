using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ModelsUserController
{
    public class ParentUserIndexModel
    {
        public UserIndexModel userIndexModel { get; set; }
        public IEnumerable<UserIndexModel> userIndexModels { get; set; }
    }
}