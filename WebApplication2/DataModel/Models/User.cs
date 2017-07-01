using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataModel.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get;set;}
        public virtual ICollection<Story> Stories { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public User()
        {
            Stories = new List<Story>();
            Groups = new List<Group>();
        }
    }
}