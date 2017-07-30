using System.Web;
using System.Web.Optimization;

namespace Klik
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Content/bower_components/bootstrap-sass/assets/javascripts/bootstrap.js",
                        "~/scripts/datatables/jquery.datatables.js",
                        "~/scripts/datatables/datatables.bootstrap.js",
                        "~/scripts/klik.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/stylesheet/app.css",
                      "~/Content/DataTables/css/jquery.dataTables.min"));
        }
    }
}
