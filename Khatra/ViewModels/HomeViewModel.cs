using Khatra.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Khatra.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Post> NewPosts { get; set; }
        public IEnumerable<Post> TopReadPosts { get; set; }
        public IEnumerable<ApplicationUser> TopUsers { get; set; }

        // this is the main statistics 
        public int UsersNumber { get; set; }
        public int PostsNumber { get; set; }
        public int CategoriesNumber { get; set; }
        public int CommentsNumber { get; set; }

    }
}