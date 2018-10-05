using Pluto.Wpf.ViewModels.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pluto.Wpf.Views.Dialogs
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
