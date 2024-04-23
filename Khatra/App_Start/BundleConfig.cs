using System.Web;
using System.Web.Optimization;

namespace Khatra
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/custom/site.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/editor").Include(
                        "~/Scripts/tinymce/tinymce.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/postActions").Include(
                        "~/Scripts/custom/postActions.js"));

            bundles.Add(new ScriptBundle("~/bundles/readPost").Include(
                        "~/Scripts/custom/readPost.js"));

            bundles.Add(new ScriptBundle("~/bundles/comments").Include(
                        "~/Scripts/custom/comments.js"));

            bundles.Add(new ScriptBundle("~/bundles/categories").Include(
                        "~/Scripts/custom/categories.js"));




            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/site.css"));

            // bootstrap right to left
            bundles.Add(new StyleBundle("~/Content/css_rtl").Include(
                      "~/Content/bootstrap_rtl.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/site.css",
                      "~/Content/site-rtl.css"));
        }
    }
}
