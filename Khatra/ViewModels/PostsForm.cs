using Khatra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Khatra.ViewModels
{
    public class PostsForm
    {
        public IEnumerable<Category> Categories { get; set; }
        public Post Post { get; set; }
        public string Title { get; set; }
    }
}