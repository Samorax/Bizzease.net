using System.ComponentModel.DataAnnotations;

namespace WebApplication_Webease_.Models.ViewModels
{
    public class HomeContactForm
    {
        [Required(ErrorMessage  ="This field is required")]
        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage ="This field is required")]
        [Display(Name ="Email Address")]
        public string Email { get; set; }
        
        [Required(ErrorMessage ="This field is required")]
        [Display(Name ="Project Description")]
        public string ProjectDescription { get; set; }
    }
}
