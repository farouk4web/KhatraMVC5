using Khatra.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Khatra.Controllers
{
    [Authorize(Roles = RoleName.Admins)]
    public class UsersController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult Index()
        {
            var users = context.Users.OrderByDescending(m => m.Posts.Count).ToList();
            return View(users);
        }

        [AllowAnonymous]
        public ActionResult Account(string id)
        {
            var user = context.Users.Find(id);
            if (user == null)
                return HttpNotFound();

            var _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            ViewBag.isAdmin = _userManager.IsInRole(user.Id, RoleName.Admins);
            ViewBag.isPublisher = _userManager.IsInRole(user.Id, RoleName.Publishers);

            return View(user);
        }

        //Remove user for ever
        public ActionResult Remove(string id)
        {
            var user = context.Users.Find(id);
            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveUser(string id)
        {
            var badUser = context.Users.Find(id);

            var _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var isAdmin = _userManager.IsInRole(id, RoleName.Admins);

            // if any one try to remove admin user
            if (isAdmin == true || badUser.Posts.Count() != 0)
                return RedirectToAction("Account", new { id = badUser.Id });


            // Remove User Image
            var oldImageInDb = Path.Combine(Server.MapPath("~/Uploads/Users/"), badUser.Id + ".png");
            System.IO.File.Delete(oldImageInDb);

            context.Users.Remove(badUser);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        //Roles
        [AllowAnonymous]
        public ActionResult Role(string name)
        {
            var role = context.Roles.SingleOrDefault(m => m.Name == name);
            if (role == null)
                return HttpNotFound();

            //Roles.GetUsersInRole(role.Name);

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUserToRole(string userId, string roleName)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            UserManager.AddToRole(userId, roleName);
            return RedirectToAction("Account", "Users", new { id = userId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveUserFromRole(string userId, string roleName)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            UserManager.RemoveFromRole(userId, roleName);
            return RedirectToAction("Account", "Users", new { id = userId });
        }

    }
}