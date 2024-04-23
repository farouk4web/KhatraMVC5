using Khatra.Resources.ModelsResources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Khatra.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        [Display(Name = "Email", ResourceType = typeof(fields))]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        [EmailAddress(ErrorMessageResourceName = "ValidEmail", ErrorMessageResourceType = typeof(msgs))]
        [Display(Name = "Email", ResourceType = typeof(fields))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        [Display(Name = "Password", ResourceType = typeof(fields))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(fields))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [MinLength(6, ErrorMessageResourceName = "Min6", ErrorMessageResourceType = typeof(msgs))]
        [MaxLength(25, ErrorMessageResourceName = "Max25", ErrorMessageResourceType = typeof(msgs))]
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        [Display(Name = "FullName", ResourceType = typeof(fields))]
        public string FullName { get; set; }

        [Display(Name = "UserImage", ResourceType = typeof(fields))]
        public string UserImageSrc { get; set; }
        
        // custom validation to check if user using "gmail, outlook, hotmail, yahoo" U can edit in models folder
        [ValidEmail]
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        [EmailAddress(ErrorMessageResourceName = "ValidEmail", ErrorMessageResourceType = typeof(msgs))]
        [Display(Name = "Email", ResourceType = typeof(fields))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        [StringLength(100, ErrorMessageResourceName ="Min6", ErrorMessageResourceType =typeof(msgs) ,MinimumLength = 6)]
        [Display(Name = "Password", ResourceType = typeof(fields))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword", ResourceType = typeof(fields))]
        [Compare("Password", ErrorMessageResourceName = "ConfirmPasswordMsg", ErrorMessageResourceType =typeof(msgs))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string AboutMe { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        [EmailAddress(ErrorMessageResourceName = "ValidEmail", ErrorMessageResourceType = typeof(msgs))]
        [Display(Name = "Email", ResourceType = typeof(fields))]
        public string Email { get; set; }
    }

    public class ResetPasswordViewModel
    {
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
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
