using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models.ModelsStoryController
{
    public class EditStoryViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "The field must be set")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The length of the Title must be between 2 before 20 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The field must be set")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "The length of the Description must be between 2 before 40 characters")]
        public string Description { get; set; }
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "The length of the Content must be  1000 characters")]
        public string Content { get; set; }
        public int? UserId { get; set; }
    
        public int? GroupId { get; set; }
    }
}