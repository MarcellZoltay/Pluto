using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Pluto.Wpf_autofac.ViewModels
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

        public DelegateCommand NavigateToStartPageCommand { get; private set; }
        public DelegateCommand NavigateToCurriculumPageCommand { get; private set; }
        public DelegateCommand NavigateToTermsPageCommand { get; set; }
        public DelegateCommand NavigateToSubjectsPageCommand { get; set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            NavigateToStartPageCommand = new DelegateCommand(NavigateToStartPage);
            NavigateToCurriculumPageCommand = new DelegateCommand(NavigateToCurriculumPage);
            NavigateToTermsPageCommand = new DelegateCommand(NavigateToTermsPage);
            NavigateToSubjectsPageCommand = new DelegateCommand(NavigateToSubjectsPage);
        }

        private void NavigateToStartPage()
        {
            regionManager.RequestNavigate("MainRegion", "StartPage");
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
    }
}
