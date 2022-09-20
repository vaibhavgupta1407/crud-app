using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models.ViewModel
{
    public class LoginSignUpViewModel
    {
      
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
