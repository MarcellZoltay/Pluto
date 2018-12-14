using Pluto.Wpf.Views.Dialogs;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Pluto.Wpf.ViewModels.Dialogs
{
    public class CreateOrEditSubjectDialogViewModel : BindableBase
    {
        public string Title { get; private set; }
        public string ButtonContent { get; private set; }

        public string SubjectName { get; set; }
        public int SubjectCredit { get; set; }

        public DelegateCommand CreateSaveCommand { get; private set; }
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
        private CreateOrEditSubjectDialog view;

        public CreateOrEditSubjectDialogViewModel()
        {
            Title = Strings.SubjectDialog_Title_Create;
            ButtonContent = Strings.SubjectDialog_Button_Create;

            InitCommands();
        }
        public CreateOrEditSubjectDialogViewModel(string name, int credit)
        {
            Title = Strings.SubjectDialog_Title_Edit;
            ButtonContent = Strings.SubjectDialog_Button_Save;

            InitCommands();

            SubjectName = name;
            SubjectCredit = credit;
        }

        private void InitCommands()
        {
            CreateSaveCommand = new DelegateCommand(CreateSaveOnClick);
            BackCommand = new DelegateCommand(BackOnClick);
        }

        public bool? ShowDialog()
        {
            view = new CreateOrEditSubjectDialog();
            view.DataContext = this;
            view.ShowDialog();

            return DialogResult;
        }

        private void CreateSaveOnClick()
        {
            DialogResult = true;
        }
        private void BackOnClick()
        {
            DialogResult = false;
        }
    }
}
