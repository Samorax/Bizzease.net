using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace webease.Models.IdentityModel
{
    public class LogInModel
    {
        
        [Display(Name = "UserName")]
        [Required(ErrorMessage ="This field is required")]
        public string Username { get; set; }

        [Display(Name ="Password")]
        [Required(ErrorMessage ="This field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }


    }
}
