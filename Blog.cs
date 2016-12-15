using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webease.Models
{
    public class Blog
    {
       
        public virtual int BlogId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Title")]
        public virtual string BlogTitle { get; set; }

        [Display(Name ="Date")]
        [DataType(DataType.Date)]
        //[Required(ErrorMessage = "This field is required")]
        public virtual DateTime BlogDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.MultilineText)]
        [Display(Name ="Summary")]
        [StringLength(maximumLength:250,ErrorMessage ="The summary is beyond the allowed word limit")]
        public virtual string BlogSummary { get; set; }

        [Display(Name ="Tag")]
        [Required(ErrorMessage = "This field is required")]
        public virtual string BlogTag { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name ="Blog")]
        [Required(ErrorMessage = "This field is required")]
        public virtual string BlogBody { get; set; }

        [Display(Name = "Comment")]
        [DataType(DataType.MultilineText)]
        public IEnumerable<Comment> BlogComment { get; set; }

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
