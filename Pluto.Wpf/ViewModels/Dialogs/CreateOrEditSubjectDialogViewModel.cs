using Pluto.BLL.Model;
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

        public Subject Subject { get; private set; }

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

        public CreateOrEditSubjectDialogViewModel(Subject subject = null)
        {
            if(subject == null)
            {
                Title = "Create subject";
                ButtonContent = "Create";
                Subject = new Subject();
            }
            else
            {
                Title = "Edit subject";
                ButtonContent = "Save";
                Subject = subject;
            }

            CreateSaveCommand = new DelegateCommand(CreateSaveOnClick);
            BackCommand = new DelegateCommand(BackOnClick);
        }

        public bool? ShowDialog()
        {
            view = new CreateOrEditSubjectDialog();
            view.DataContext = this;
            //view.PreviewTextInput += PreviewCreditTextboxHandler;
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

        private void PreviewCreditTextboxHandler(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]?[0-9]");

            int value;
            Int32.TryParse(e.Text, out value);
            bool accepted = (value >= 0 && value <= 30);

            e.Handled = regex.IsMatch(e.Text) && accepted;
        }
    }
}
