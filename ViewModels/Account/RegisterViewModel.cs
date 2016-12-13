using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_Webease_.ViewModels.Account
{
    public enum customerType
    {
        [Display(Name = "Individual")]
        Individual,
        [Display(Name = "Organization")]
        Organization
    }

    public class RegisterViewModel
    {
            
        [Required(ErrorMessage ="This field is required")]
        [Display(Name = "Client Type")]
        public  customerType? client { get; set; }

        [Display(Name = "Name of Organization:")]
        public string OrganizationName { get; set; }

        [Display(Name = "Position at Organization")]
        public string PostionAtOrganization { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [Display(Name = "First Line of Address:")]
        public string FirstLineOfAddress { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Second Line of Address:")]
        public string SecondLineOfAddress { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Post Code:")]
        public string PostCode { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare(nameof(RegisterViewModel.Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
