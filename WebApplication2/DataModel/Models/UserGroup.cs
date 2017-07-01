using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class UserGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int? UserId { get; set; }
        [Required]
        public int? GroupId { get; set; }
    }
}
