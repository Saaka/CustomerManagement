using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CustomerManagement
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jslibs-header")
                            .Include("~/lib/angular/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/jslibs")
                            .Include("~/lib/angular/angular-animate.js",
                                        "~/lib/angular/angular-ui-router.js",
                                        "~/lib/angular/toaster.js",
                                        "~/lib/bootstrap/js/bootstrap.js",
                                        "~/lib/jquery/jquery.js",
                                        "~/lib/sweetalert/sweetalert.min.js"));

            bundles.Add(new StyleBundle("~/bundles/csslibs")
                            .Include("~/lib/angular/toaster.css",
                                        "~/lib/sweetalert/sweetalert.css")
                            .Include("~/lib/bootstrap/css/bootstrap.css", new CssRewriteUrlTransform())
                            .Include("~/lib/fontawesome/css/font-awesome.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/customer-manager-js")
                            .Include("~/Scripts/customerManager.js",
                                        "~/Scripts/customerManager.config.js",
                                        "~/Scripts/Controllers/customerListCtrl.js",
                                        "~/Scripts/Controllers/customerCtrl.js",
                                        "~/Scripts/Services/customerService.js",
                                        "~/Scripts/Services/alertService.js"));
        }
    }
}