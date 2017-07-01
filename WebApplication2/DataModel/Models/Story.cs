using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataModel.Models
{
    public class Story
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Titel { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [MaxLength(5000)]
        public string Content { get; set; }
        public bool PostedOn { get; set; }
        public virtual User User { get; set; }
        public int? UserId { get; set; }
        public virtual Group Group {get;set;}
        public int? GroupId { get; set; }
    }
}