using Pluto.BLL.Model;
using Pluto.Wpf.Views.Dialogs;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;

namespace Pluto.Wpf.ViewModels.Dialogs
{
    public class RegisterSubjectDialogViewModel : BindableBase
    {
        public string Title { get; private set; }
        public string RegisterSubjectName { get; private set; }

        public List<Term> ActiveTerms { get; private set; }
        public Term SelectedTerm { get; private set; }
        public int SelectedTermIndex { get; set; }

        public DelegateCommand RegisterSubjectCommand { get; private set; }
        public DelegateCommand BackCommand { get; private set; }

        private bool? dialogResult;
        public bool? DialogResult
        {
            get { return dialogResult; }
            private set
            {
                dialogResult = value;
                view.DialogResult = dialogResult;
            }
        }
        private RegisterSubjectDialog view;

        public RegisterSubjectDialogViewModel(string registerSubjectName, List<Term> activeTerms)
        {
            Title = "Register subject";
            RegisterSubjectName = registerSubjectName;
            ActiveTerms = activeTerms;

            RegisterSubjectCommand = new DelegateCommand(RegisterSubjectOnClick);
            BackCommand = new DelegateCommand(BackOnClick);

            SelectedTermIndex = 0;
        }

        public bool? ShowDialog()
        {
            var dataContext = this;
            view = new RegisterSubjectDialog(dataContext);
            view.ShowDialog();

            return DialogResult;
        }

        private void RegisterSubjectOnClick()
        {
            SelectedTerm = ActiveTerms.ElementAt(SelectedTermIndex);

            DialogResult = true;
        }
        private void BackOnClick()
        {
            DialogResult = false;
        }
    }
}
