using Khatra.Resources.ModelsResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Khatra.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Display(Name = "Content", ResourceType = typeof(fields))]
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        [MinLength(10, ErrorMessageResourceName = "Min10", ErrorMessageResourceType = typeof(msgs))]
        public string Content { get; set; }

        [Display(Name = "PublishedDate", ResourceType = typeof(fields))]
        public DateTime PublishedDate { get; set; }

        [Display(Name = "Post", ResourceType = typeof(fields))]
        public int PostId { get; set; }


        [Display(Name = "User", ResourceType = typeof(fields))]
        public string UserId { get; set; }

        public virtual Post Post { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}