using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Globalization;

namespace Pluto.Wpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

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

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            NavigateToCurriculumPageCommand = new DelegateCommand(NavigateToCurriculumPage);
            NavigateToTermsPageCommand = new DelegateCommand(NavigateToTermsPage);
            NavigateToSubjectsPageCommand = new DelegateCommand(NavigateToSubjectsPage);
            LanguageCommand = new DelegateCommand(ChangeLanguage);
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
            }
            else
            {
                WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.Culture = new CultureInfo("en");
            }
        }
    }
}
