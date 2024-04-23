using Khatra.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Khatra.Controllers
{
    [Authorize(Roles = RoleName.AdminsOrPublishers)]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext context;

        public CategoriesController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Categories
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(context.Categories.OrderByDescending(m => m.Posts.Count()).ToList());
        }

        [AllowAnonymous]
        public ActionResult AllPosts(int id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
                return HttpNotFound();

            return View(category);
        }

        public ActionResult New()
        {
            var category = new Category();
            return View("CategoryForm", category);
        }

        public ActionResult Update(int id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
                return HttpNotFound();

            var currentUserId = User.Identity.GetUserId();

            if (currentUserId == category.UserId || User.IsInRole(RoleName.Admins))
                return View("CategoryForm", category);

            return RedirectToAction("AllPosts", new { id = category.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Category category)
        {
            if (!ModelState.IsValid)
                return View("CategoryForm", category);

            if (category.Id == 0) //new category
            {
                category.UserId = User.Identity.GetUserId();
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var categoryInDb = context.Categories.Find(category.Id);
                categoryInDb.Name = category.Name;
                categoryInDb.Description = category.Description;
                context.SaveChanges();
                return RedirectToAction("AllPosts", new { id = category.Id });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {
            var category = context.Categories.Find(id);
            var currentUserId = User.Identity.GetUserId();

            if (User.IsInRole(RoleName.Admins) && category.Posts.Count() == 0)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("AllPosts", new { id = id });
        }
    }
}