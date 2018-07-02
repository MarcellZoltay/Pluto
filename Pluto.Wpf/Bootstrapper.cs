using Pluto.Wpf.Views;
using System.Windows;
using Prism.Modularity;
using Autofac;
using Prism.Autofac;
using Pluto.BLL.Services;

namespace Pluto.Wpf
{
    class Bootstrapper : AutofacBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            //moduleCatalog.AddModule(typeof(YOUR_MODULE));
        }

        protected override void ConfigureContainerBuilder(ContainerBuilder builder)
        {
            base.ConfigureContainerBuilder(builder);

            builder.RegisterTypeForNavigation<StartPage>();
            builder.RegisterTypeForNavigation<CurriculumPage>();
            builder.RegisterTypeForNavigation<TermsPage>();

            builder.RegisterType<SubjectService>().As<ISubjectService>();
            builder.RegisterType<TermService>().As<ITermService>();
        }
    }
}
