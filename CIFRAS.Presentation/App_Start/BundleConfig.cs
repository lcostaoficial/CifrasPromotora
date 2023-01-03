using System.Web.Optimization;

namespace CIFRAS.Presentation
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            #region Básico
            bundles.Add(new StyleBundle("~/Content/basic-css").Include(                  
                    "~/Content/css/sb-admin.css",
                    "~/Content/css/validation.css",
                    "~/Content/css/personalize.css",
                    "~/Content/css/inputfile.css"));

            bundles.Add(new StyleBundle("~/Content/basic-vendor").Include(
                    "~/Content/vendor/bootstrap/bootstrap.css",
                    "~/Content/vendor/font-awesome/css/font-awesome.css",
                    "~/Content/vendor/sweetalert2/sweetalert.css")); 

            bundles.Add(new ScriptBundle("~/bundles/basic-js").Include(                   
                    "~/Scripts/js/sb-admin-mask.js",
                    "~/Scripts/js/sb-admin-global.js",
                    "~/Scripts/js/sb-admin.js"));

            bundles.Add(new ScriptBundle("~/bundles/basic-vendor").Include(
                   "~/Scripts/vendor/jquery/jquery.js",
                   "~/Scripts/vendor/jquery-easing/jquery.easing.js",
                   "~/Scripts/vendor/bootstrap/bootstrap.bundle.js",
                   "~/Scripts/vendor/sweetalert2/sweetalert.js",
                   "~/Scripts/vendor/jquery-maskedinput/jquery.maskedinput.js",
                   "~/Scripts/vendor/jquery-maskmoney/jquery.maskmoney.js"));
            #endregion           

            #region Datatables
            bundles.Add(new StyleBundle("~/Content/datatables-css").Include(
                    "~/Content/vendor/datatables/dataTables.bootstrap4.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatables-js").Include(
                    "~/Scripts/vendor/datatables/jquery.dataTables.js",
                    "~/Scripts/vendor/datatables/dataTables.bootstrap4.js",
                    "~/Scripts/vendor/datatables/datatables.config.js"));
            #endregion

            #region Datepicker
            bundles.Add(new StyleBundle("~/Content/datepicker-css").Include(
                    "~/Content/vendor/datepicker/bootstrap-datepicker.min.css",
                    "~/Content/vendor/datepicker/bootstrap-datepicker.standalone.min.css",
                    "~/Content/vendor/datepicker/bootstrap-datepicker3.min.css",
                    "~/Content/vendor/datepicker/bootstrap-datepicker3.standalone.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/datepicker-js").Include(
                    "~/Scripts/vendor/datepicker/bootstrap-datepicker.min.js",
                    "~/Scripts/vendor/datepicker/locales/bootstrap-datepicker.pt-BR.min.js",
                    "~/Scripts/vendor/datepicker/datepicker.config.js"));
            #endregion

            #region Correios  
            bundles.Add(new ScriptBundle("~/bundles/correios-js").Include(
                    "~/Scripts/js/sb-admin-correios.js"));
            #endregion

            #region Pdfmake
            bundles.Add(new ScriptBundle("~/bundles/pdfmake-js").Include(
                    "~/Scripts/vendor/pdfmake/pdfmake.js",
                    "~/Scripts/vendor/pdfmake/vfs_fonts.js"));
            #endregion

            #region Ckeditor
            bundles.Add(new ScriptBundle("~/bundles/ckeditor-js").Include(
                    "~/Scripts/vendor/ckeditor/ckeditor.js"));
            #endregion

            #region Site
            bundles.Add(new ScriptBundle("~/bundles/cliente-add-js").Include(
                    "~/Scripts/site/cliente/cliente-add.js"));

            bundles.Add(new ScriptBundle("~/bundles/cliente-update-js").Include(
                     "~/Scripts/site/cliente/cliente-update.js"));

            bundles.Add(new ScriptBundle("~/bundles/cliente-table-js").Include(
                     "~/Scripts/site/cliente/cliente-table.js"));

            bundles.Add(new ScriptBundle("~/bundles/cliente-details-js").Include(
                     "~/Scripts/site/cliente/cliente-details.js"));

            bundles.Add(new ScriptBundle("~/bundles/recibo-add-js").Include(
                     "~/Scripts/site/recibo/recibo-add.js"));

            bundles.Add(new ScriptBundle("~/bundles/recibo-update-js").Include(
                     "~/Scripts/site/recibo/recibo-update.js"));

            bundles.Add(new ScriptBundle("~/bundles/recibo-table-js").Include(
                     "~/Scripts/site/recibo/recibo-table.js"));

            bundles.Add(new ScriptBundle("~/bundles/recibo-pdf-js").Include(
                     "~/Scripts/site/recibo/recibo-pdf.js"));

            bundles.Add(new ScriptBundle("~/bundles/banco-table-js").Include(
                     "~/Scripts/site/banco/banco-table.js"));

            bundles.Add(new ScriptBundle("~/bundles/categoria-arquivo-table-js").Include(
                     "~/Scripts/site/categoria-arquivo/categoria-arquivo-table.js"));

            bundles.Add(new ScriptBundle("~/bundles/corretor-table-js").Include(
                     "~/Scripts/site/corretor/corretor-table.js"));

            bundles.Add(new ScriptBundle("~/bundles/funcionario-table-js").Include(
                     "~/Scripts/site/funcionario/funcionario-table.js"));

            bundles.Add(new ScriptBundle("~/bundles/tipo-contrato-table-js").Include(
                     "~/Scripts/site/tipo-contrato/tipo-contrato-table.js"));

            bundles.Add(new ScriptBundle("~/bundles/tipo-cliente-table-js").Include(
                     "~/Scripts/site/tipo-cliente/tipo-cliente-table.js"));

            bundles.Add(new ScriptBundle("~/bundles/arquivo-table-js").Include(
                     "~/Scripts/site/arquivo/arquivo-table.js"));

            bundles.Add(new ScriptBundle("~/bundles/arquivo-personalize-js").Include(
                     "~/Scripts/site/arquivo/arquivo-personalize.js"));
            #endregion

            BundleTable.EnableOptimizations = false;
        }
    }
}