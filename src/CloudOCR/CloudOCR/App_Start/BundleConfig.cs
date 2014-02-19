using System.Web;
using System.Web.Optimization;

namespace CloudOCR
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, consulte http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/swfobject").Include(
                        "~/Scripts/swfobject.js"));

            bundles.Add(new ScriptBundle("~/Content/UploadifyContent/jquery-uplodify").Include(
                        "~/Content/UploadifyContent/jquery.uploadify.js"));

            bundles.Add(new ScriptBundle("~/Content/UploadifyContent/jquery-uplodify-min").Include(
                        "~/Content/UploadifyContent/jquery.uploadify.min.js"));

            bundles.Add(new ScriptBundle("~/Content/UploadifyContent/CSSuplodify").Include(
                        "~/Content/UploadifyContent/uploadify.css"));


            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-theme.css",
                      "~/Content/site.css"));
        }
    }
}
