using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace we_sessions_prac.Models
{
    public class Register
    {
        [Required,Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required, Display(Name = "Username")]
        public string UserName { get; set; }
        [Required, Display(Name = "Email"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required,Display(Name = "Password"),DataType(DataType.Password)]
        public string Password { get; set; }
    }
}