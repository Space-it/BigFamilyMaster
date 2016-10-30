using System.Web;
using System.Web.Optimization;

namespace BigFamilyWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/script.js"));
            

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new StyleBundle("~/Content/admin_css").Include(
                      "~/Content/AdminStyle.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap_css").Include(
                      "~/Content/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Content/index_css").Include(
                      "~/Content/index.css"));
            bundles.Add(new StyleBundle("~/Content/services_css").Include(
                      "~/Content/services.css"));
            bundles.Add(new StyleBundle("~/Content/footer_css").Include(
                      "~/Content/footer.css"));
        }
    }
}
