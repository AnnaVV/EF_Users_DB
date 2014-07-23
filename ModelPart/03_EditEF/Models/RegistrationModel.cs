using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelPart.Models
{
    public class RegistrationModel
    {
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "User Name")]
        public string Name { get; set; }

        [Display(Name = "Select Your country")]
        public string City { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }

        [Display(Name = "Remember me?")]
        public bool Remember { get; set; }

        [Display(Name = "Select Your age")]
        public int Age { get; set; }
    }
}