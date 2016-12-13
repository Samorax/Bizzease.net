using System.ComponentModel.DataAnnotations;

namespace WebApplication_Webease_.Models
{
    public enum Category
    {
        Ecommerce,MobileApplications,OtherProjects
    }
    public class Projects
    {
        
        public virtual int ProjectsId { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [Display(Name ="Name of Project")]
        [StringLength(maximumLength:20,ErrorMessage ="The name of the project is beyond the allowed word limit")]
        public virtual string ProjectName { get; set; }
        
        [DataType(DataType.Upload)]
        [Display(Name ="Upload Image")]
        public virtual string ProjectPicUrl { get; set; }

        [Display(Name ="Project Summary")]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength:250,ErrorMessage ="The Summary is above the word count limit")]
        [Required(ErrorMessage ="This field is required")]
        public virtual string ProjectSummary { get; set; }

        [Display(Name ="Project Description")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "This field is required")]
        public virtual string ProjectDescription { get; set; }

        [Display(Name = "Project Category")]
        [Required(ErrorMessage = "This field is required")]
        public virtual Category? ProjectCategory { get; set; }

        [Display(Name = "Project Url")]
        [DataType(DataType.Url)]
        public virtual string ProjectUrl { get; set; }
    }

    
}
