using Khatra.Resources.ModelsResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Khatra.Models
{
    public class ContactForm
    {
        [Display(Name ="Name", ResourceType =typeof(fields))]
        public string Name { get; set; }

        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(fields))]
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        public string Email { get; set; }

        [Display(Name = "Supject", ResourceType = typeof(fields))]
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        public string Supject { get; set; }

        [Display(Name = "Message", ResourceType = typeof(fields))]
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        public string Message { get; set; }
    }
}