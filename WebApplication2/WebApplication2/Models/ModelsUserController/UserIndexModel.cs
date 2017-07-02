using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models.ModelsUserController
{
    public class UserIndexModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "The field must be set")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The length of the Name must be between 3 before 30 characters")]
        public string Name { get; set; }
    }
}