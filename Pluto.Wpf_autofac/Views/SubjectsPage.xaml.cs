using System.Windows.Controls;
using System.Windows.Data;

namespace Pluto.Wpf_autofac.Views
{
    /// <summary>
    /// Interaction logic for SubjectsPage
    /// </summary>
    public partial class SubjectsPage : UserControl
    {
        public SubjectsPage()
        {
            InitializeComponent();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvRegsiteredSubjects.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Term.Name");
            view.GroupDescriptions.Add(groupDescription);
        }
    }
}
