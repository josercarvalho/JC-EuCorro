using System.Web.Optimization;

namespace EuCorro.MVC.Site
{
    public class BundleConfig
    {
        // For more information on bundling,
        // visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterLayout(bundles);

            RegisterShared(bundles);

            RegisterAccount(bundles);

            RegisterWebSite(bundles);

            RegisterAdminLTE(bundles);

            RegisterMenus(bundles);

            RegisterBootstrap(bundles);
        }

        private static void RegisterMenus(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Cadastro/Categoria/menu").Include(
                "~/Scripts/Menu/Cadastro/Categoria-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Cadastro/Empresa/menu").Include(
                "~/Scripts/Menu/Empresa/Empresa-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Cadastro/Evento/menu").Include(
                "~/Scripts/Menu/Evento/Evento-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Evento/menu").Include(
                "~/Scripts/Evento/Evento-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Cadastro/EventoTipo/menu").Include(
                "~/Scripts/Menu/Cadastro/EventoTipo-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Cadastro/Modalidade/menu").Include(
                "~/Scripts/Menu/Cadastro/Modalidade-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Cadastro/Atletas/menu").Include(
                "~/Scripts/Menu/Atletas/TodosAtletas-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Cadastro/Dependentes/menu").Include(
                "~/Scripts/Menu/Atletas/Dependentes-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Cadastro/CodDesconto/menu").Include(
                "~/Scripts/Menu/Cadastro/CodDesconto-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Cadastro/Usuario/menu").Include(
                "~/Scripts/Menu/Usuario/Usuario-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Cadastro/NumeroPeito/menu").Include(
                "~/Scripts/Menu/Cadastro/NumeroPeito-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Atletas/EntregaKit/menu").Include(
                "~/Scripts/Menu/Atletas/EntregaKit-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Cadastro/PDV/menu").Include(
                "~/Scripts/Menu/PDV-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Usuario/menu").Include(
                "~/Scripts/Menu/Usuarios/Usuario-menu.js"));
        }

        private static void RegisterBootstrap(BundleCollection bundles)
        {
            // bootstrap
            bundles.Add(new ScriptBundle("~/bootstrap/js").Include(
                                "~/Scripts/bootstrap.min.js",
                                "~/Scripts/bootbox.min.js",
                                "~/Scripts/twitter-bootstrap-hover-dropdown.min.js",
                                "~/Scripts/bootstrap-checkbox.js",
                                "~/Scripts/respond.min.js"));

            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
                                //"~/Content/bootstrap-theme.min.css",
                                "~/Content/bootstrap.min.css",
                                //"~/Content/bootstrap-Paper.min.css",
                                "~/Content/docs.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                                "~/Content/bootstrap.min.css",
                                //"~/Content/bootstrap-theme.min.css",
                                "~/Content/css/custom.min.css",
                                "~/Content/StyleSystem.css"));

            // plugins | bootstrap-lightbox
            bundles.Add(new ScriptBundle("~/lightbox/js").Include(
                                "~/Scripts/bootstrap-lightbox.js"));

            bundles.Add(new StyleBundle("~/lightbox/css").Include(
                                "~/Content/bootstrap-lightbox.css"));

            // plugins | bootstrap-switch
            bundles.Add(new ScriptBundle("~/bootstrap-switch/js").Include(
                                "~/Scripts/bootstrap-switch.js"));

            bundles.Add(new StyleBundle("~/bootstrap-switch/css").Include(
                                "~/Content/bootstrap-switch.css"));

            // plugins | bootstrap-fileupload
            bundles.Add(new ScriptBundle("~/bootstrap-fileupload/js").Include(
                                "~/Scripts/bootstrap-fileupload.js"));

            bundles.Add(new StyleBundle("~/bootstrap-fileupload/css").Include(
                                "~/Content/bootstrap-fileupload.css"));

            // plugins | bootstrap-wizard
            bundles.Add(new ScriptBundle("~/bootstrap-wizard/js").Include(
                                "~/Scripts/jquery.bootstrap.wizard.min.js"));

            //bundles.Add(new StyleBundle("~/bootstrap-wizard/css").Include(
            //                    "~/Content/bootstrap-wizard.css"));

            // plugins | jasny-bootstrap
            bundles.Add(new ScriptBundle("~/jasny-bootstrap/js").Include(
                                "~/Scripts/jasny-bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/jasny-bootstrap/css").Include(
                                "~/Content/jasny-bootstrap.min.css"));
        }

        private static void RegisterShared(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Shared/_Layout").Include(
                                "~/Scripts/Shared/_Layout.js"));
        }

        private static void RegisterLayout(BundleCollection bundles)
        {
            // plugins | jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                "~/Scripts/jquery-{version}.js",
                                "~/Scripts/MyJS/example.js"));
            //"~/Scripts/MyJS/methods_pt.js"));

            // plugins | jquery-validate
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                                "~/Scripts/jquery.unobtrusive*",
                                "~/Scripts/jquery.validate*"));

            // plugins | jquery-imputmask
            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                                "~/Scripts/jquery.mask.js"));                                        

            // plugins | MVC Ajax
            bundles.Add(new ScriptBundle("~/mvcajax/js").Include(
                                "~/Scripts/MicrosoftAjax.min.js",
                                "~/Scripts/MicrosoftMvcAjax.min.js",
                                "~/Scripts/MicrosoftMvcValidation.min.js"));

            // plugins | FancyBox
            bundles.Add(new ScriptBundle("~/fancybox/js").Include(
                                "~/Scripts/MyJS/jquery.fancybox.js",
                                "~/Scripts/MyJS/jquery.mousewheel-3.0.6.pack.js"));
            //"~/Scripts/MyJS/fancybox.js"));

            bundles.Add(new StyleBundle("~/fancybox/css").Include(
                                "~/Content/jquery.fancybox.css"));

            // plugins | Knockout
            bundles.Add(new ScriptBundle("~/bundles/knockout/js").Include(
                                "~/Scripts/knockout-{version}.js",
                                "~/Scripts/knockout-{version}.debug.js",
                                "~/Scripts/knockout.validation.js"));

            // plugins | FontAwosome
            bundles.Add(new StyleBundle("~/font-awesome/css").Include(
                               "~/Content/font-awesome.css"));

            // plugins | Flipoclock
            bundles.Add(new StyleBundle("~/flipclock/css").Include(
                               "~/Content/css/flipclock.css"));

            bundles.Add(new ScriptBundle("~/flipclock/js").Include(
                              "~/Scripts/flipclock/flipclock.min.js"));

            // plugins | isotope  
            bundles.Add(new StyleBundle("~/isotope/css").Include(
                               "~/Content/isotope.css",
                               "~/Content/jquery.fancybox.css"));

            bundles.Add(new ScriptBundle("~/isotope/js").Include(
                               "~/Scripts/MyJS/jquery-isotope.js",
                               "~/Scripts/MyJS/isotope.min.js",
                               "~/Scripts/MyJS/jquery.fancybox.js",
                               "~/Scripts/MyJS/main-isotope.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                                "~/Scripts/modernizr-*"));
        }

        private static void RegisterAccount(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Account/Login").Include(
                                         "~/Scripts/Account/Login.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Account/Register").Include(
                                         "~/Scripts/Account/Register.js"));
        }

        private static void RegisterAdminLTE(BundleCollection bundles)
        {
            // bootstrap
            //bundles.Add(new ScriptBundle("~/AdminLTE/bootstrap/js").Include(
            //                            "~/Scripts/bootstrap/js/bootstrap.min.js",
            //                            "~/Scripts/bootbox.min.js"));

            // bootstrap
            bundles.Add(new ScriptBundle("~/AdminLTE/bootstrap/js").Include(
                                        "~/AdminLTE/bootstrap/js/bootstrap.min.js",
                                        "~/Scripts/bootbox.min.js",
                                        "~/Scripts/MyJS/example.js",
                                        "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/bootstrap/css").Include(
                                        "~/AdminLTE/bootstrap/css/bootstrap.min.css"));

            // AdminLTE App 2.4
            bundles.Add(new ScriptBundle("~/AdminLTE/js").Include(
                                        "~/AdminLTE/dist/js/adminlte.min.js",
                                        "~/AdminLTE/dist/js/demo.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/css").Include(
                                        "~/AdminLTE/dist/css/AdminLTE.min.css"));

            // dist
            bundles.Add(new ScriptBundle("~/AdminLTE/dist/js").Include(
                                        "~/AdminLTE/dist/js/app.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/dist/css").Include(
                                        "~/AdminLTE/dist/css/admin-lte.min.css"));

            bundles.Add(new StyleBundle("~/AdminLTE/dist/css/skins").Include(
                                        "~/AdminLTE/dist/css/skins/_all-skins.min.css"));

            // documentation
            bundles.Add(new ScriptBundle("~/AdminLTE/documentation/js").Include(
                                        "~/AdminLTE/documentation/js/docs.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/documentation/css").Include(
                                        "~/AdminLTE/documentation/css/style.css"));

            // plugins | bootstrap-slider
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/bootstrap-slider/js").Include(
                                        "~/AdminLTE/plugins/bootstrap-slider/js/bootstrap-slider.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/bootstrap-slider/css").Include(
                                        "~/AdminLTE/plugins/bootstrap-slider/css/slider.css"));

            // plugins | bootstrap-wysihtml5
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/bootstrap-wysihtml5/js").Include(
                                         "~/AdminLTE/plugins/bootstrap-wysihtml5/js/bootstrap3-wysihtml5.all.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/bootstrap-wysihtml5/css").Include(
                                        "~/AdminLTE/plugins/bootstrap-wysihtml5/css/bootstrap3-wysihtml5.min.css"));

            // plugins | chartjs
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/chartjs/js").Include(
                                         "~/AdminLTE/plugins/chartjs/js/chart.min.js"));

            // plugins | ckeditor
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/ckeditor/js").Include(
                                         "~/AdminLTE/plugins/ckeditor/js/ckeditor.js"));

            // plugins | colorpicker
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/colorpicker/js").Include(
                                         "~/AdminLTE/plugins/colorpicker/js/bootstrap-colorpicker.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/colorpicker/css").Include(
                                        "~/AdminLTE/plugins/colorpicker/css/bootstrap-colorpicker.css"));

            // plugins | datatables
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/datatables/js").Include(
                                         "~/AdminLTE/plugins/datatables/js/jquery.dataTables.min.js",
                                         "~/AdminLTE/plugins/datatables/js/dataTables.bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/datatables/css").Include(
                                        "~/AdminLTE/plugins/datatables/css/dataTables.bootstrap.css"));

            // plugins | datepicker
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/datepicker/js").Include(
                                         "~/AdminLTE/plugins/datepicker/js/bootstrap-datepicker.js",
                                         "~/AdminLTE/plugins/datepicker/js/locales/bootstrap-datepicker*"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/datepicker/css").Include(
                                        "~/AdminLTE/plugins/datepicker/css/datepicker3.css"));

            // plugins | daterangepicker
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/daterangepicker/js").Include(
                                         "~/AdminLTE/plugins/daterangepicker/js/moment.min.js",
                                         "~/AdminLTE/plugins/daterangepicker/js/daterangepicker.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/daterangepicker/css").Include(
                                        "~/AdminLTE/plugins/daterangepicker/css/daterangepicker-bs3.css"));

            // plugins | fastclick
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/fastclick/js").Include(
                                         "~/AdminLTE/plugins/fastclick/js/fastclick.min.js"));

            // plugins | flot
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/flot/js").Include(
                                         "~/AdminLTE/plugins/flot/js/jquery.flot.min.js",
                                         "~/AdminLTE/plugins/flot/js/jquery.flot.resize.min.js",
                                         "~/AdminLTE/plugins/flot/js/jquery.flot.pie.min.js",
                                         "~/AdminLTE/plugins/flot/js/jquery.flot.categories.min.js"));

            // plugins | font-awesome
            bundles.Add(new StyleBundle("~/AdminLTE/plugins/font-awesome/css").Include(
                                        "~/AdminLTE/plugins/font-awesome/css/font-awesome.min.css"));

            // plugins | fullcalendar
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/fullcalendar/js").Include(
                                         "~/AdminLTE/plugins/fullcalendar/js/fullcalendar.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/fullcalendar/css").Include(
                                        "~/AdminLTE/plugins/fullcalendar/css/fullcalendar.min.css"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/fullcalendar/css/print").Include(
                                        "~/AdminLTE/plugins/fullcalendar/css/print/fullcalendar.print.css"));

            // plugins | icheck
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/icheck/js").Include(
                                         "~/AdminLTE/plugins/icheck/js/icheck.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/icheck/css").Include(
                                        "~/AdminLTE/plugins/icheck/css/all.css"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/icheck/css/flat").Include(
                                        "~/AdminLTE/plugins/icheck/css/flat/flat.css"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/icheck/css/sqare/blue").Include(
                                        "~/AdminLTE/plugins/icheck/css/sqare/blue.css"));

            // plugins | input-mask
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/input-mask/js").Include(
                                         "~/AdminLTE/plugins/input-mask/js/jquery.inputmask.js",
                                         "~/AdminLTE/plugins/input-mask/js/jquery.inputmask.date.extensions.js",
                                         "~/AdminLTE/plugins/input-mask/js/jquery.inputmask.extensions.js"));

            // plugins | ionicons
            bundles.Add(new StyleBundle("~/AdminLTE/plugins/ionicons/css").Include(
                                        "~/AdminLTE/plugins/ionicons/css/ionicons.min.css"));

            // plugins | ionslider
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/ionslider/js").Include(
                                         "~/AdminLTE/plugins/ionslider/js/ion.rangeSlider.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/ionslider/css").Include(
                                        "~/AdminLTE/plugins/ionslider/css/ion.rangeSlider.css",
                                        "~/AdminLTE/plugins/ionslider/css/ion.rangeSlider.skinNice.css"));

            // plugins | jquery
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/jquery/js").Include(
                                         "~/AdminLTE/plugins/jquery/js/jQuery-2.1.4.min.js"));

            // plugins | jquery-validate
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/jquery-validate/js").Include(
                                        "~/Scripts/jquery.unobtrusive*",
                                         "~/AdminLTE/plugins/jquery-validate/js/jquery.validate*",
                                         "~/Scripts/jquery.validate.pt-br.js"));

            // plugins | jquery-ui
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/jquery-ui/js").Include(
                                         "~/AdminLTE/plugins/jquery-ui/js/jquery-ui.min.js"));

            // plugins | jvectormap
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/jvectormap/js").Include(
                                         "~/AdminLTE/plugins/jvectormap/js/jquery-jvectormap-1.2.2.min.js",
                                         "~/AdminLTE/plugins/jvectormap/js/jquery-jvectormap-world-mill-en.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/jvectormap/css").Include(
                                        "~/AdminLTE/plugins/jvectormap/css/jquery-jvectormap-1.2.2.css"));

            // plugins | knob
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/knob/js").Include(
                                         "~/AdminLTE/plugins/knob/js/jquery.knob.js"));

            // plugins | morris
            bundles.Add(new StyleBundle("~/AdminLTE/plugins/morris/css").Include(
                                        "~/AdminLTE/plugins/morris/css/morris.css"));

            // plugins | momentjs
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/momentjs/js").Include(
                                         "~/AdminLTE/plugins/momentjs/js/moment.min.js"));

            // plugins | pace
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/pace/js").Include(
                                         "~/AdminLTE/plugins/pace/js/pace.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/pace/css").Include(
                                        "~/AdminLTE/plugins/pace/css/pace.min.css"));

            // plugins | slimscroll
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/slimscroll/js").Include(
                                         "~/AdminLTE/plugins/slimscroll/js/jquery.slimscroll.min.js"));

            // plugins | sparkline
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/sparkline/js").Include(
                                         "~/AdminLTE/plugins/sparkline/js/jquery.sparkline.min.js"));

            // plugins | timepicker
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/timepicker/js").Include(
                                         "~/AdminLTE/plugins/timepicker/js/bootstrap-timepicker.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/timepicker/css").Include(
                                        "~/AdminLTE/plugins/timepicker/css/bootstrap-timepicker.min.css"));

            // plugins | raphael
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/raphael/js").Include(
                                         "~/AdminLTE/plugins/raphael/js/raphael-min.js"));

            // plugins | select2
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/select2/js").Include(
                                         "~/AdminLTE/plugins/select2/js/select2.full.min.js"));

            bundles.Add(new StyleBundle("~/AdminLTE/plugins/select2/css").Include(
                                        "~/AdminLTE/plugins/select2/css/select2.min.css"));

            // plugins | morris
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/morris/js").Include(
                                         "~/AdminLTE/plugins/morris/js/morris.min.js"));
        }

        private static void RegisterWebSite(BundleCollection bundles)
        {
            // layout Website
            bundles.Add(new StyleBundle("~/website/css").Include(
                                "~/Content/font-awesome.css",
                                "~/Content/animate.css",
                                "~/Content/Carroucel.css",
                                "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/website/js").Include(
                                "~/Scripts/MyJS/MenuFixo.js",
                                "~/Scripts/MyJS/BotaoInicioPagina.js",
                                "~/Scripts/animate.js",
                                "~/Scripts/MyJS/wow.js"));
            // Home
            bundles.Add(new ScriptBundle("~/Scripts/Home/menu").Include(
                            "~/Scripts/Home/Home-menu.js",
                            "~/Scripts/Home/Home.js"));

            // Empresa
            bundles.Add(new ScriptBundle("~/Scripts/Empresa/menu").Include(
                            "~/Scripts/Home/Empresa-menu.js",
                            "~/Scripts/Home/Empresa.js"));

            // Portifólio                                              
            bundles.Add(new ScriptBundle("~/Scripts/Portifolio/menu").Include(
                            "~/Scripts/Home/Portifolio-menu.js"));

            // Galeria
            bundles.Add(new ScriptBundle("~/Scripts/Galeria/menu").Include(
                            "~/Scripts/Home/Galeria-menu.js",
                            "~/Scripts/Home/Galeria.js"));

            // Contato
            bundles.Add(new ScriptBundle("~/Scripts/Contato/menu").Include(
                            "~/Scripts/Home/Contato-menu.js",
                            "~/Scripts/Home/Contato.js"));

            // Sobre | About
            bundles.Add(new ScriptBundle("~/Scripts/Sobre/menu").Include(
                            "~/Scripts/Home/Sobre-menu.js",
                            "~/Scripts/Home/Sobre.js"));

            // WIZARD - jquery steps
            bundles.Add(new StyleBundle("~/Content/jquerysteps").Include("~/Content/jquery.steps.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquerysteps").Include("~/Scripts/jquery.steps.js"));
        }

        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        //public static void RegisterBundles(BundleCollection bundles)
        //{
        //    bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
        //                "~/Scripts/jquery-{version}.js"));

        //    bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
        //                "~/Scripts/jquery.validate*"));

        //    bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
        //    //~/Scripts/Inputmask/dependencyLibs/inputmask.dependencyLib.js",  //if not using jquery
        //    "~/Scripts/Inputmask/inputmask.js",
        //    "~/Scripts/Inputmask/jquery.inputmask.js",
        //    "~/Scripts/Inputmask/inputmask.extensions.js",
        //    "~/Scripts/Inputmask/inputmask.date.extensions.js",
        //    //and other extensions you want to include
        //    "~/Scripts/Inputmask/inputmask.numeric.extensions.js"));

        //    // Use the development version of Modernizr to develop with and learn from. Then, when you're
        //    // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
        //    bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
        //                "~/Scripts/modernizr-*"));

        //    bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
        //              "~/Scripts/bootstrap.js",
        //              "~/Scripts/respond.js"));

        //    bundles.Add(new StyleBundle("~/Content/css").Include(
        //              "~/Content/bootstrap.css",
        //              "~/Content/site.css"));

        //    // layout Website
        //    bundles.Add(new StyleBundle("~/website/css").Include(
        //                        "~/Content/font-awesome.css",
        //                        "~/Content/animate.css",
        //                        "~/Content/site.css"));

        //    bundles.Add(new ScriptBundle("~/website/js").Include(
        //                        "~/Scripts/MyJS/MenuFixo.js",
        //                        "~/Scripts/MyJS/BotaoInicioPagina.js",
        //                        "~/Scripts/animate.js",
        //                        "~/Scripts/MyJS/wow.js"));

        //    // bootstrap
        //    bundles.Add(new ScriptBundle("~/bootstrap/js").Include(
        //                        "~/Scripts/bootstrap.min.js",
        //                        "~/Scripts/bootbox.min.js",
        //                        "~/Scripts/twitter-bootstrap-hover-dropdown.js",
        //                        "~/Scripts/respond.js"));

        //    bundles.Add(new StyleBundle("~/bootstrap/css").Include(
        //                        "~/Content/bootstrap.css",
        //                        "~/Scripts/bootstrap-theme.min.css"));
        //}
    }
}
