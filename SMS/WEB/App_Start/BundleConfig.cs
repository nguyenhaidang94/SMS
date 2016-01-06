using System.Web;
using System.Web.Optimization;

namespace WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                       "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/kendo/2015.3.1111/kendo.core.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.data.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.columnsorter.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.calendar.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.popup.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.datepicker.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.userevents.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.validator.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.binder.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.editable.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.draganddrop.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.window.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.calendar.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.popup.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.datepicker.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.userevents.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.numerictextbox.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.list.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.dropdownlist.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.filtermenu.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.datepicker.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.groupable.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.resizable.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.reorderable.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.selectable.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.filtercell.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.autocomplete.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.pager.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.ooxml.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.excel.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.color.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.drawing.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.pdf.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.progressbar.min.js",
                        "~/Scripts/kendo/2015.3.1111/kendo.grid.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
