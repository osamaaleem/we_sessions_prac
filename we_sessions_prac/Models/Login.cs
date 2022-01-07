using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace we_sessions_prac.Models
{
    public class Login
    {
        [Required, Display(Name = "Username")]
        public string Username { get; set; }
        [Required, Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}