using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Khatra.Resources.ModelsResources;

namespace Khatra.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(fields))]
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        public string Name { get; set; }

        [Display(Name = "Description", ResourceType = typeof(fields))]
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        [MinLength(255, ErrorMessageResourceName = "Min255", ErrorMessageResourceType = typeof(msgs))]
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        [Display(Name = "User", ResourceType = typeof(fields))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}