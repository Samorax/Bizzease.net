using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace webease.Models.IdentityModel
{
    public class RegisterModel
    {
        [Display(Name ="UserName")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Text)]
        public string RegisterUsername { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage ="This field is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name ="Password")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name ="Verify Password")]
        [Required(ErrorMessage ="This field is required")]
        [DataType(DataType.Password)]
        [Compare("password",ErrorMessage ="Your passwords do not match")]
        public string VerifyPassword { get; set; }
    }
}
