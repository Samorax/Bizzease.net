using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_Webease_.Models
{
    public class Blog
    {
       
        public virtual int BlogId { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Title")]
        public virtual string BlogTitle { get; set; }

        [Display(Name ="Date")]
        [DataTypeAttribute(DataType.Date)]
        //[Required(ErrorMessage = "This field is required")]
        public virtual string BlogDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.MultilineText)]
        [Display(Name ="Summary")]
        public virtual string BlogSummary { get; set; }

        [Display(Name ="Tag")]
        [Required(ErrorMessage = "This field is required")]
        public virtual string BlogTag { get; set; }


        [Display(Name ="Blog")]
        [DataTypeAttribute(DataType.Upload)]
        [Required(ErrorMessage = "This field is required")]
        public virtual string BlogBody { get; set; }

        [Display(Name = "Comment")]
        [DataType(DataType.MultilineText)]
        public IEnumerable<Comment> BlogComment { get; set; }

        [Display(Name = "Author")]
        [Required(ErrorMessage ="This field is required")]
        public virtual string BlogAuthor { get; set; }

    }

    public class Comment
    {
        
        public virtual int CommentId { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [Display(Name ="Name")]
        public virtual string CommenterName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Comment")]
        [DataType(DataType.MultilineText)]
        public virtual string CommentBody { get; set; }

        
        public virtual DateTime CommentDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public virtual string CommenterEmailAddress { get; set; }

        public virtual int BlogId { get; set; }
    }
}
