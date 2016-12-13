using System.ComponentModel.DataAnnotations;


namespace WebApplication_Webease_.Models.ViewModels
{
    public class ContactForm
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage="This field is required")]
        public string FirstName {get;set;}

        [Display(Name = "Last Name")]
        [Required(ErrorMessage="This field is required")]
        public string LastName { get; set; }

        [Display(Name ="Email")]
        [Required(ErrorMessage="This field is required")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Phone(ErrorMessage ="This does not look like a phone number")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Message { get; set; }
    }
}