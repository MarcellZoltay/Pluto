using Pluto.BLL.Model.Subjects;
using Pluto.BLL.Services.Interfaces;
using Pluto.Wpf.Command;
using Pluto.Wpf.ViewModels.Dialogs;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Pluto.Wpf.ViewModels
{
    public class CurriculumPageViewModel : BindableBase
    {
        private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects
        {
            get { return subjects; }
            set { SetProperty(ref subjects, value); }
        }

        public int SelectedSubjectIndex { get; set; }
        public Subject SelectedSubjectItem { get; set; }

        private bool _isLoading = true;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private ISubjectService _subjectService;
        private ITermService _termService;
        private IRegisteredSubjectService _registeredSubjectService;

        public RelayCommand NewSubjectCommand { get; private set; }
        public RelayCommand EditSubjectCommand { get; private set; }
        public RelayCommand DeleteSubjectCommand { get; private set; }
        public RelayCommand RegisterSubjectCommand { get; private set; }
        public RelayCommand UnregisterSubjectCommand { get; private set; }

        public CurriculumPageViewModel(ISubjectService subjectService,
                                       ITermService termService,
                                       IRegisteredSubjectService registeredSubjectService)
        {
            _subjectService = subjectService;
            _termService = termService;
            _registeredSubjectService = registeredSubjectService;

            NewSubjectCommand = new RelayCommand(NewSubjectOnClick);
            EditSubjectCommand = new RelayCommand(EditSubjectOnClick, p => SelectedSubjectIndex > -1);
            DeleteSubjectCommand = new RelayCommand(DeleteSubjectOnClick, p => SelectedSubjectIndex > -1);
            RegisterSubjectCommand = new RelayCommand(RegisterSubjectOnClick, p => SelectedSubjectIndex > -1);
            UnregisterSubjectCommand = new RelayCommand(UnregisterSubjectOnClick, p => SelectedSubjectIndex > -1);

            SelectedSubjectIndex = -1;

            Subjects = new ObservableCollection<Subject>();

            var currentDispatcher = Dispatcher.CurrentDispatcher;
            Task.Factory.StartNew(async () =>
            {
                List<Subject> subjects = await _subjectService.GetSubjectsAsync();

                currentDispatcher.Invoke(new Action(() =>
                {
                    Subjects.AddRange(subjects);
                    IsLoading = false;
                }));
            });
        }

        private async void NewSubjectOnClick(object obj)
        {
            var dialogViewModel = new CreateOrEditSubjectDialogViewModel();
            if (dialogViewModel.ShowDialog() == true)
            {
                var subject = new Subject(dialogViewModel.SubjectName, dialogViewModel.SubjectCredit);

                Subjects.Add(subject);
                await _subjectService.AddSubjectAsync(subject);
            }
        }
        private async void EditSubjectOnClick(object obj)
        {
            var subject = SelectedSubjectItem;

            var dialogViewModel = new CreateOrEditSubjectDialogViewModel(subject.Name, subject.Credit);
            if (dialogViewModel.ShowDialog() == true)
            {
                subject.Name = dialogViewModel.SubjectName;

                try
                {
                    subject.Credit = dialogViewModel.SubjectCredit;
                }
                catch (InvalidOperationException e)
                {
                    MessageBox.Show(e.Message, Strings.SubjectDialog_Title_Edit, MessageBoxButton.OK);
                }

                SelectedSubjectIndex = -1;

                await _subjectService.UpdateSubjectAsync(subject);
            }
        }
        private async void DeleteSubjectOnClick(object obj)
        {
            var subject = SelectedSubjectItem;

            var result = MessageBox.Show(Strings.SubjectDialog_Message_Question + " " + subject.Name + (Strings.SubjectDialog_Question_SubjectWord.Length == 0 ? "" : " ") + Strings.SubjectDialog_Question_SubjectWord + "?", Strings.SubjectDialog_Title_Delete, MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                var deletable = await _subjectService.DeleteSubjectAsync(subject);

                if (deletable)
                    Subjects.Remove(subject);
                else
                    MessageBox.Show(Strings.SubjectDialog_Message_Warning, Strings.SubjectDialog_Title_Delete, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private async void RegisterSubjectOnClick(object obj)
        {
            var subject = SelectedSubjectItem;

            if (subject.IsRegistered)
            {
                MessageBox.Show(Strings.RegisteredSubjectDialog_Message_Registered + ".", Strings.RegisteredSubjectDialog_Title_Register, MessageBoxButton.OK);
            }
            else if (subject.IsCompleted)
            {
                MessageBox.Show(Strings.RegisteredSubjectDialog_Message_Completed + ".", Strings.RegisteredSubjectDialog_Title_Register, MessageBoxButton.OK);
            }
            else
            {
                var activeTerms = await _termService.GetTermsAsync(t => t.IsActive && !t.IsClosed);
                var dialogViewModel = new RegisterSubjectDialogViewModel(subject.Name, activeTerms);
                if (dialogViewModel.ShowDialog() == true)
                {
                    var selectedTerm = dialogViewModel.SelectedTerm;
                    SelectedSubjectIndex = -1;

                    await _registeredSubjectService.RegisterSubjectAsync(subject, selectedTerm);
                }
            }
        }
        private async void UnregisterSubjectOnClick(object obj)
        {
            var subject = SelectedSubjectItem;

            var result = MessageBox.Show(Strings.RegisteredSubjectDialog_Question_Unregister + "?", Strings.RegisteredSubjectDialog_Title_Unregister, MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                var canBeUnregistered = await _registeredSubjectService.UnregisterSubjectAsync(subject);

                if (!canBeUnregistered)
                    MessageBox.Show(Strings.RegisteredSubjectDialog_Message_Unregister + ".", Strings.RegisteredSubjectDialog_Title_Unregister, MessageBoxButton.OK, MessageBoxImage.Warning);

                SelectedSubjectIndex = -1;
            }
        }
    }
}
