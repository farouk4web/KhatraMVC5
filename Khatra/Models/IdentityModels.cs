using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Khatra.Resources.ModelsResources;
using System.Security.Claims;
using System.Collections.Generic;

namespace Khatra.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        // custom props
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(msgs))]
        [Display(Name = "FullName", ResourceType = typeof(fields))]
        public string FullName { get; set; }

        public string UserImageSrc { get; set; }

        [MinLength(10, ErrorMessageResourceName = "Min10", ErrorMessageResourceType = typeof(msgs))]
        public string AboutMe { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }



        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}