using Khatra.Models;
using Khatra.ViewModels;
using Khatra.Resources.ViewsResources;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace Khatra.Controllers
{
    [Authorize(Roles = RoleName.AdminsOrPublishers)]
    public class PostsController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Posts
        [AllowAnonymous]
        public ActionResult Index()
        {
            var posts = context.Posts.OrderByDescending(m => m.PublishedDate).ToList();
            return View(posts);
        }

        [AllowAnonymous]
        public ActionResult Read(int id)
        {
            var post = context.Posts.Find(id);
            if (post == null)
                return HttpNotFound();

            post.Views = post.Views + 1;
            context.SaveChanges();

            var latestPosts = context.Posts.OrderByDescending(m => m.PublishedDate).Take(4);
            var authorPosts = context.Posts.Where(m => m.UserId == post.UserId).Take(4);


            var vm = new ReadPostVM
            {
                Post = post,
                LatestPosts = latestPosts,
                AuthorPosts = authorPosts,
                Comment = new Comment()
            };

            return View(vm);
        }

        public ActionResult New()
        {
            PostsForm viewModel = new PostsForm
            {
                Title = global.NewPost,
                Post = new Post(),
                Categories = context.Categories.ToList()
            };
            return View("PostsForm", viewModel);
        }

        public ActionResult Update(int id)
        {
            var post = context.Posts.Find(id);

            if (post == null)
                return HttpNotFound();

            var currentUserId = User.Identity.GetUserId();

            if (currentUserId == post.UserId || User.IsInRole(RoleName.Admins))
            {
                PostsForm viewModel = new PostsForm
                {
                    Title = global.UpdatePost,
                    Post = post,
                    Categories = context.Categories.ToList()
                };
                return View("PostsForm", viewModel);
            }

            return RedirectToAction("Read", new { id = post.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Post post, HttpPostedFileBase mainPostImage)
        {
            if (!ModelState.IsValid)
            {
                PostsForm viewModel = new PostsForm
                {
                    Post = post,
                    Categories = context.Categories.ToList()
                };
                return View("PostsForm", viewModel);
            }

            if (post.Id == 0)
            {
                post.PublishedDate = DateTime.Now;
                post.UserId = User.Identity.GetUserId();
                post.ImageSrc = "post.png";

                context.Posts.Add(post);
                context.SaveChanges();

                if (mainPostImage != null && mainPostImage.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Uploads/Posts/"), post.Id + ".png");
                    mainPostImage.SaveAs(path);

                    post.ImageSrc = post.Id + ".png";
                    context.SaveChanges();
                }

                return RedirectToAction("Read", new { id = post.Id });
            }
            else
            {
                var postInDb = context.Posts.Find(post.Id);
                postInDb.Title = post.Title;
                postInDb.CategoryId = post.CategoryId;
                postInDb.Content = post.Content;

                if (mainPostImage != null && mainPostImage.ContentLength > 0)
                {
                    // Save new Image
                    var path = Path.Combine(Server.MapPath("~/Uploads/Posts/"), postInDb.Id + ".png");
                    mainPostImage.SaveAs(path);

                    postInDb.ImageSrc = postInDb.Id + ".png";
                }

                context.SaveChanges();
                return RedirectToAction("Read", new { id = postInDb.Id });
            }
        }

        [HttpPost]
        public void Remove(int id)
        {
            var post = context.Posts.Find(id);
            var currentUserId = User.Identity.GetUserId();

            if (currentUserId == post.UserId || User.IsInRole(RoleName.Admins))
            {
                context.Posts.Remove(post);
                context.SaveChanges();

                //remove Post image
                var oldImageInDb = Path.Combine(Server.MapPath("~/Uploads/Posts/"), id + ".png");
                System.IO.File.Delete(oldImageInDb);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemovePost(int id)
        {
            var postInDb = context.Posts.Find(id);
            if (postInDb == null)
                return HttpNotFound();

            var currentUserId = User.Identity.GetUserId();

            if (currentUserId == postInDb.UserId || User.IsInRole(RoleName.Admins))
            {
                context.Posts.Remove(postInDb);
                context.SaveChanges();

                //remove Post image
                var oldImageInDb = Path.Combine(Server.MapPath("~/Uploads/Posts/"), postInDb.Id + ".png");
                System.IO.File.Delete(oldImageInDb);
            }

            return RedirectToAction("Index");
        }

    }
}