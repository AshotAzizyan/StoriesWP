using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataModel.Models
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
        public Group()
        {
            Stories = new List<Story>();
            Users = new List<User>();
        }
      
    }
}