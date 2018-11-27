using Pluto.Wpf.Views;
using System.Windows;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Pluto.BLL.Services.Implementations;
using Pluto.BLL.Services.Interfaces;

namespace Pluto.Wpf
{
    class Bootstrapper : UnityBootstrapper
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

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterTypeForNavigation<CurriculumPage>();
            Container.RegisterTypeForNavigation<TermsPage>();
            Container.RegisterTypeForNavigation<SubjectsPage>();

            Container.RegisterType<ISubjectService, SubjectService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ITermService, TermService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IRegisteredSubjectService, RegisteredSubjectService>(new ContainerControlledLifetimeManager());
        }
    }
}
