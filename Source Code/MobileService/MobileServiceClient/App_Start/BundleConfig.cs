using System.Web.Optimization;

namespace MobileServiceClient
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/Menunav.js",
                        "~/Script/Account.min.js",
                        "~/Scripts/Profile-Edit-Form.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive-ajax.js"
                        ));
           
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/font-awesome.css",
                      "~/Content/StyleSheet.css",
                      "~/Content/bootstrap.css",
                      "~/Content/styles_Account.min.css",
                      "~/Content/site.css"));
        }
    }
}
