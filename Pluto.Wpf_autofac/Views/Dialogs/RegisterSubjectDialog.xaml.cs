using Pluto.Wpf_autofac.ViewModels.Dialogs;
using System.Windows;

namespace Pluto.Wpf_autofac.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for RegisterSubjectDialog.xaml
    /// </summary>
    public partial class RegisterSubjectDialog : Window
    {
        public RegisterSubjectDialog(RegisterSubjectDialogViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
