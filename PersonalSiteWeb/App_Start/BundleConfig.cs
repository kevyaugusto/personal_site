using System;
using System.Web;
using System.Web.Optimization;

namespace PersonalSiteWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/classie.js",
                "~/Scripts/cbpAnimatedHeader.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include("~/Scripts/Site.js"));

            //STYLES
            bundles.Add(new StyleBundle("~/Content/styles")
                .Include("~/Content/Css/bootstrap.css")
                .Include("~/Content/Css/font-awesome.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/site").Include("~/Content/Css/site.css", new CssRewriteUrlTransform()));
            
            //BundleTable.EnableOptimizations = false;
        }
    }
}