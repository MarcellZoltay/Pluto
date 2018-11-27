using Prism.Commands;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pluto.Wpf.Views
{
    /// <summary>
    /// Interaction logic for NavigationBar.xaml
    /// </summary>
    public partial class NavigationBar : UserControl
    {
        public DelegateCommand CurriculumPageCommand
        {
            get { return (DelegateCommand)GetValue(NavigationBar.CurriculumPageCommandProperty); }
            set { SetValue(NavigationBar.CurriculumPageCommandProperty, value); }
        }
        public static readonly DependencyProperty CurriculumPageCommandProperty = DependencyProperty.Register(
            nameof(CurriculumPageCommand),
            typeof(DelegateCommand),
            typeof(NavigationBar));

        public DelegateCommand TermsPageCommand
        {
            get { return (DelegateCommand)GetValue(NavigationBar.TermsPageCommandProperty); }
            set { SetValue(NavigationBar.TermsPageCommandProperty, value); }
        }
        public static readonly DependencyProperty TermsPageCommandProperty = DependencyProperty.Register(
            nameof(TermsPageCommand),
            typeof(DelegateCommand),
            typeof(NavigationBar));

        public DelegateCommand SubjectsPageCommand
        {
            get { return (DelegateCommand)GetValue(NavigationBar.SubjectsPageCommandProperty); }
            set { SetValue(NavigationBar.SubjectsPageCommandProperty, value); }
        }
        public static readonly DependencyProperty SubjectsPageCommandProperty = DependencyProperty.Register(
            nameof(SubjectsPageCommand),
            typeof(DelegateCommand),
            typeof(NavigationBar));

        public NavigationBar()
        {
            InitializeComponent();
        }
    }
}
