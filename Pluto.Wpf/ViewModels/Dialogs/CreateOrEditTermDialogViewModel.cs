using Pluto.BLL.Model;
using Pluto.Wpf.Views.Dialogs;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pluto.Wpf.ViewModels.Dialogs
{
    public class CreateOrEditTermDialogViewModel : BindableBase
    {
        public string Title { get; private set; }
        public string ButtonContent { get; private set; }

        public string TermName { get; private set; }
        public bool TermIsActive { get; set; }

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
        private CreateOrEditTermDialog view;

        public CreateOrEditTermDialogViewModel(string name)
        {
            Title = "Create term";
            ButtonContent = "Create";

            InitCommands();

            TermName = name;
        }
        public CreateOrEditTermDialogViewModel(string name, bool isActive)
        {
            Title = "Edit term";
            ButtonContent = "Save";

            InitCommands();

            TermName = name;
            TermIsActive = isActive;
        }

        private void InitCommands()
        {
            CreateSaveCommand = new DelegateCommand(CreateSaveOnClick);
            BackCommand = new DelegateCommand(BackOnClick);
        }

        public bool? ShowDialog()
        {
            view = new CreateOrEditTermDialog();
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
