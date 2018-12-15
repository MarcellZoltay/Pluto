using Microsoft.Practices.Unity;
using Pluto.Wpf.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Globalization;

namespace Pluto.Wpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer unityContainer;

        private string _title = "Pluto";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand NavigateToCurriculumPageCommand { get; private set; }
        public DelegateCommand NavigateToTermsPageCommand { get; set; }
        public DelegateCommand NavigateToSubjectsPageCommand { get; set; }
        public DelegateCommand LanguageCommand { get; set; }

        public MainWindowViewModel(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            this.regionManager = regionManager;
            this.unityContainer = unityContainer;

            NavigateToCurriculumPageCommand = new DelegateCommand(NavigateToCurriculumPage);
            NavigateToTermsPageCommand = new DelegateCommand(NavigateToTermsPage);
            NavigateToSubjectsPageCommand = new DelegateCommand(NavigateToSubjectsPage);
            LanguageCommand = new DelegateCommand(ChangeLanguage);

            regionManager.RegisterViewWithRegion("MainRegion", () => unityContainer.Resolve<WelcomePage>());

            WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.Culture = new CultureInfo(Properties.Settings.Default.Localization);
        }

        private void NavigateToCurriculumPage()
        {
            regionManager.RequestNavigate("MainRegion", "CurriculumPage");
        }
        private void NavigateToTermsPage()
        {
            regionManager.RequestNavigate("MainRegion", "TermsPage");
        }
        private void NavigateToSubjectsPage()
        {
            regionManager.RequestNavigate("MainRegion", "SubjectsPage");
        }


        private bool language = false;
        private void ChangeLanguage()
        {
            language = !language;

            if (language)
            {
                WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.Culture = new CultureInfo("hu-HU");
                Properties.Settings.Default.Localization = "hu-HU";
                Properties.Settings.Default.Save();
            }
            else
            {
                WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.Culture = new CultureInfo("en");
                Properties.Settings.Default.Localization = "en";
                Properties.Settings.Default.Save();
            }
        }
    }
}
