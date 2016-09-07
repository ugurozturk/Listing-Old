using System.Web;
using System.Web.Optimization;

namespace mylist
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Content/jtable/jquery.jtable.js",
                        "~/Scripts/jquery-ui.min.js",
                        "~/Scripts/jquery.cascadingDropDown.js",
                        "~/Scripts/jtableyukle.js",
                        "~/Scripts/async.min.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/scripts.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/styles.css",
                      "~/Content/jtable/themes/metro/blue/jtable.min.css",
                      "~/Content/jquery-ui.min.css",
                      "~/Content/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/adminltecc").Include(
                "~/Content/adminltec/AdminLTE.min.css",
                "~/Content/adminltec/skins/skin-blue.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/adminltesc").Include(
                "~/Scripts/adminltes/app.min.js",
                "~/Scripts/adminltes/dashboard2.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/plugincc").Include(
                "~/Content/plugins/iCheck/flat/blue/css",
                "~/Content/plugins/jvectormap/jquery-jvectormap-1.2.2.css",
                "~/Content/plugins/datepicker/datepicker3.css",
                "~/Content/plugins/daterangepicker/daterangepicker-bs3.css",
                "~/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"
                ));
            bundles.Add(new ScriptBundle("~/Content/pluginsc").Include(
                "~/Content/plugins/sparkline/jquery.sparkline.min.js",
                "~/Content/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                "~/Content/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                "~/Content/plugins/chartjs/Chart.min.js",
                 "~/Content/plugins/knob/jquery.knob.js",
                 "~/Content/plugins/daterangepicker/daterangepicker.js",
                 "~/Content/plugins/datepicker/bootstrap-datepicker.js",
                 "~/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                 "~/Content/plugins/slimScroll/jquery.slimscroll.min.js",
                 "~/Content/plugins/fastclick/fastclick.min.js"
                      ));

            //jquery.easing.min
        }
    }
}
