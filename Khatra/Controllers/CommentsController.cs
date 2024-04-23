using Khatra.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Khatra.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Comments
        [Authorize(Roles = RoleName.AdminsOrPublishers)]
        public ActionResult Index()
        {
            var comments = context.Comments.OrderByDescending(m => m.PublishedDate).ToList();
            return View(comments);
        }

        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveNewComment(Comment comment, int PostId)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Read", "Posts", new { id = PostId });

            comment.UserId = User.Identity.GetUserId();
            comment.PublishedDate = DateTime.Now;
            comment.PostId = PostId;

            context.Comments.Add(comment);
            context.SaveChanges();

            return RedirectToAction("Read", "Posts", new { id = PostId });
        }


        public ActionResult Edit(int id)
        {
            var comment = context.Comments.Find(id);
            if (comment == null)
                return HttpNotFound();

            var currentUserId = User.Identity.GetUserId();
            if (currentUserId == comment.UserId || User.IsInRole(RoleName.Admins))
                return View(comment);

            return RedirectToAction("Read", "Posts", new { id = comment.PostId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveComment(Comment comment)
        {
            if (!ModelState.IsValid)
                return View("Edit", comment);

            var oldComment = context.Comments.Find(comment.Id);
            oldComment.Content = comment.Content;
            context.SaveChanges();
            return RedirectToAction("Read", "Posts", new { id = oldComment.PostId });
        }

        [HttpPost]
        public void Remove(int id)
        {
            var comment = context.Comments.Find(id);

            if (comment != null)
            {
                var currentUserId = User.Identity.GetUserId();

                if (comment.UserId == currentUserId || User.IsInRole(RoleName.Admins))
                    context.Comments.Remove(comment);

                context.SaveChanges();
            }
        }
    }
}