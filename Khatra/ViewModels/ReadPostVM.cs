using Khatra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Khatra.ViewModels
{
    public class ReadPostVM
    {
        public Post Post { get; set; }
        public IEnumerable<Post> LatestPosts { get; set; }
        public IEnumerable<Post> AuthorPosts { get; set; }
        public Comment Comment { get; set; }
    }
}