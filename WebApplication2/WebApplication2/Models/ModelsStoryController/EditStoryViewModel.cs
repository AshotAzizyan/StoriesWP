using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ModelsStoryController
{
    public class EditStoryViewModel
    {
        public int Id { get; set; }
        public string Titel { get; set; }
      
        public string Description { get; set; }
        
        public string Content { get; set; }
       
        public int? UserId { get; set; }
    
        public int? GroupId { get; set; }
    }
}