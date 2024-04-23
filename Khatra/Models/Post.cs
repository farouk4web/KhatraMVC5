using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Khatra.Resources.ModelsResources;

namespace Khatra.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Display(Name = "Title", ResourceType = typeof(fields))]
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        [MinLength(10, ErrorMessageResourceName = "Min10", ErrorMessageResourceType = typeof(msgs))]
        [MaxLength(100, ErrorMessageResourceName = "Max100", ErrorMessageResourceType = typeof(msgs))]
        public string Title { get; set; }

        [AllowHtml]
        [Display(Name = "Content", ResourceType = typeof(fields))]
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        [MinLength(255, ErrorMessageResourceName = "Min255", ErrorMessageResourceType = typeof(msgs))]
        public string Content { get; set; }

        [Display(Name = "PublishedDate", ResourceType = typeof(fields))]
        public DateTime PublishedDate { get; set; }

        [Display(Name = "Views", ResourceType = typeof(fields))]
        public int Views { get; set; }

        [Display(Name = "MainPostImage", ResourceType = typeof(fields))]
        public string ImageSrc { get; set; }

        [Display(Name = "Category", ResourceType = typeof(fields))]
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        public int CategoryId { get; set; }

        [Display(Name = "User", ResourceType = typeof(fields))]
        public string UserId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Category Category { get; set; }
    }
}