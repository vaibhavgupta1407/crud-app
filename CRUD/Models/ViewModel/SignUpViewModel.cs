using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models.ViewModel
{
    public class SignUpViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        [RegularExpression(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage ="Please enter Valid mail.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Please Enter Your Mobile Number")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage="Please Enter Valid Mobile number")]
        public long? Mobile { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter Your ConfirmPassword")]
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Remember me")]
        public bool IsRemember { get; set; }
    }
}
