using Prism.Mvvm;

namespace Pluto.Wpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Pluto";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
