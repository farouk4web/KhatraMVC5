using Khatra.Models;
using Khatra.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Khatra.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;
        public HomeController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }


        public ActionResult Index()
        {
            var newPosts = context.Posts.OrderByDescending(m => m.PublishedDate).Take(4).ToList();
            var topReadPosts = context.Posts.OrderByDescending(m => m.Views).Include(m => m.Category).Take(6).ToList();
            var topUsers = context.Users.OrderByDescending(m => m.Comments.Count()).Take(6).ToList();

            var viewModel = new HomeViewModel
            {
                NewPosts = newPosts,
                TopReadPosts = topReadPosts,
                TopUsers = topUsers,

                PostsNumber = context.Posts.Count(),
                UsersNumber = context.Users.Count(),
                CategoriesNumber = context.Categories.Count(),
                CommentsNumber = context.Comments.Count()
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactForm contact)
        {
            if (!ModelState.IsValid)
                return View(contact);

            //form Data
            var mail = new MailMessage()
            {
                From = new MailAddress(contact.Email), // Form Email
                Subject = contact.Supject,  // Form Supject
                IsBodyHtml = true,
                // Message Body
                Body =
                "<h3>Email From: " + contact.Name + ", " + contact.Email + "</h3>" +
                "<h4>Message Content : </h4>" + "<p style='font-size:16px'>" + contact.Message + "</p>"
            };

            var siteMail = ConfigurationManager.AppSettings["SiteEmail"].ToString();
            mail.To.Add(new MailAddress(siteMail)); // Resever

            // Sender E-mail
            var siteCredentials = new NetworkCredential
            {
                UserName = siteMail,
                Password = ConfigurationManager.AppSettings["SiteEmailPassword"].ToString(),
            };

            SmtpClient smtpClient = new SmtpClient
            {
                Credentials = siteCredentials,
                Host = "smtp.office365.com",
                Port = 587,
                EnableSsl = true
            };

            smtpClient.Send(mail);

            ViewBag.sentMsgState = true;
            return RedirectToAction("Contact");
        }



        // change default language
        [Authorize(Roles =RoleName.Admins)]
        public ActionResult ChangeLanguage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admins)]
        public ActionResult ChangeLanguage(string language)
        {
            // update langauge in web config
            Configuration configFlie = WebConfigurationManager.OpenWebConfiguration("~");
            AppSettingsSection objAppSettings = (AppSettingsSection)configFlie.GetSection("appSettings");
            if (objAppSettings != null)
            {
                objAppSettings.Settings["Language"].Value = language;
                configFlie.Save();
            }

            return RedirectToAction("ChangeLanguage");
        }
    }
}