using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pluto.BLL.Model;
using Pluto.BLL.Services;
using Pluto.Wpf.ViewModels.Dialogs;
using Pluto.Wpf.Command;
using System.Windows;
using System.Windows.Threading;
using System;
using System.Threading.Tasks;
using Pluto.BLL.Services.Interfaces;

namespace Pluto.Wpf.ViewModels
{
    public class CurriculumPageViewModel : BindableBase
    {
        private string _title = "Curriculum Page";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects
        {
            get { return subjects; }
            set { SetProperty(ref subjects, value); }
        }

        public int SelectedSubjectIndex { get; set; }

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
        public RelayCommand OrderListCommand { get; private set; }
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
            OrderListCommand = new RelayCommand(OrderListOnClick);
            RegisterSubjectCommand = new RelayCommand(RegisterSubjectOnClick, p => SelectedSubjectIndex > -1);
            UnregisterSubjectCommand = new RelayCommand(UnregisterSubjectOnClick, p => SelectedSubjectIndex > -1);

            SelectedSubjectIndex = -1;

            Subjects = new ObservableCollection<Subject>();

            var currentDispatcher = Dispatcher.CurrentDispatcher;
            Task.Factory.StartNew(async () =>
            {
                List<Subject> subjects = await _subjectService.GetSubjectsAsync();

                currentDispatcher.Invoke(new Action( () =>
                {
                    Subjects.AddRange(subjects);
                    IsLoading = false;
                }));
            });
        }
        
        private async void NewSubjectOnClick(object obj)
        {
            var dialogViewModel = new CreateOrEditSubjectDialogViewModel();
            if(dialogViewModel.ShowDialog() == true)
            {
                var subject = new Subject(dialogViewModel.SubjectName, dialogViewModel.SubjectCredit);

                Subjects.Add(subject);
                await _subjectService.AddSubjectAsync(subject);             
            }
        }
        private async void EditSubjectOnClick(object obj)
        {
            var subject = Subjects.ElementAt(SelectedSubjectIndex);

            var dialogViewModel = new CreateOrEditSubjectDialogViewModel(subject.Name, subject.Credit);
            if (dialogViewModel.ShowDialog() == true)
            {
                subject.Name = dialogViewModel.SubjectName;
                subject.Credit = dialogViewModel.SubjectCredit;

                SelectedSubjectIndex = -1;

                await _subjectService.UpdateSubjectAsync(subject);
            }
        }
        private async void DeleteSubjectOnClick(object obj)
        {
            var subject = Subjects.ElementAt(SelectedSubjectIndex);

            var result = MessageBox.Show("Are you sure you want to delete " + subject.Name + "?", "Delete subject", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                var deletable = await _subjectService.DeleteSubjectAsync(subject);

                if (deletable)
                    Subjects.Remove(subject);
                else
                    MessageBox.Show("This subject cannot be deleted!", "Delete term", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void OrderListOnClick(object obj)
        {
            var subjects = new List<Subject>(Subjects.OrderBy(s => s.Name));
        
            Subjects.Clear();
            Subjects.AddRange(subjects);
        }
        private async void RegisterSubjectOnClick(object obj)
        {
            var subject = Subjects.ElementAt(SelectedSubjectIndex);

            if (subject.IsRegistered)
            {
                MessageBox.Show("This subject is already registered.", "Register subject", MessageBoxButton.OK);
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
            var subject = Subjects.ElementAt(SelectedSubjectIndex);

            var result = MessageBox.Show("Do you want to unregister this subject?", "Unregister subject", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if(result == MessageBoxResult.OK)
            {
                var canBeUnregistered = await _registeredSubjectService.UnregisterSubjectAsync(subject);

                if (!canBeUnregistered)
                    MessageBox.Show("This subject is unregistered.", "Unregister subject", MessageBoxButton.OK, MessageBoxImage.Warning);

                SelectedSubjectIndex = -1;
            }
        }

    }
}
