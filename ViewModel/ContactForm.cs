using System.ComponentModel.DataAnnotations;


namespace webease.Models.ViewModel
{
    public class ContactForm
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage="This field is required")]
        public virtual string FirstName {get;set;}

        [Display(Name = "Last Name")]
        [Required(ErrorMessage="This field is required")]
        public virtual string LastName { get; set; }

        [Display(Name ="Email Address")]
        [Required(ErrorMessage="This field is required")]
        [EmailAddress]
        public virtual string Email { get; set; }
        
        [Phone(ErrorMessage ="This does not look like a phone number")]
        public virtual string Tel { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public virtual string Message { get; set; }
    }
}