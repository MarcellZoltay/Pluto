using Pluto.BLL.Model;
using Pluto.BLL.Model.RegisteredSubjects;
using Pluto.BLL.Services.Interfaces;
using Pluto.Wpf.Command;
using Pluto.Wpf.ViewModels.Dialogs;
using Prism.Commands;
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
    public class SubjectsPageViewModel : BindableBase
    {
        private string _title = "Subjects page";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isLoading = true;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private ObservableCollection<RegisteredSubject> registeredSubjects;
        public ObservableCollection<RegisteredSubject> RegisteredSubjects
        {
            get { return registeredSubjects; }
            set { SetProperty(ref registeredSubjects, value); }
        }

        public RegisteredSubject SelectedRegisteredSubject { get; set; }
        public Attendance SelectedAttendance { get; set; }
        public int SelectedAttendanceIndex { get; set; }

        private IRegisteredSubjectService _registeredSubjectService;

        public RelayCommand CompletedCheckboxCheckChangedCommand { get; private set; }
        public RelayCommand AddAttendanceCommand { get; private set; }
        public RelayCommand EditAttendanceCommand { get; private set; }
        public RelayCommand DeleteAttendanceCommand { get; private set; }

        public SubjectsPageViewModel(IRegisteredSubjectService registeredSubjectService)
        {
            _registeredSubjectService = registeredSubjectService;
            _registeredSubjectService.RegisteredSubjectsChanged += _registeredSubjectService_RegisteredSubjectsChanged;

            CompletedCheckboxCheckChangedCommand = new RelayCommand(CompletedCheckboxOnCheckChanged);
            AddAttendanceCommand = new RelayCommand(AddAttendanceOnClick);
            EditAttendanceCommand = new RelayCommand(EditAttendanceOnClick, p => SelectedAttendanceIndex > -1);
            DeleteAttendanceCommand = new RelayCommand(DeleteAttendanceOnClick, p => SelectedAttendanceIndex > -1);

            SelectedAttendanceIndex = -1;

            RegisteredSubjects = new ObservableCollection<RegisteredSubject>();

            var currentDispatcher = Dispatcher.CurrentDispatcher;
            Task.Factory.StartNew(async () =>
            {
                List<RegisteredSubject> registeredSubjects = await _registeredSubjectService.GetRegisteredSubjectsAsync();
                registeredSubjects = new List<RegisteredSubject>(registeredSubjects.OrderBy(s => s.Term.Name));

                currentDispatcher.Invoke(new Action(() =>
                {
                    RegisteredSubjects.AddRange(registeredSubjects);

                    IsLoading = false;
                }));
            });
        }

        private async void _registeredSubjectService_RegisteredSubjectsChanged(object sender, EventArgs e)
        {
            var currentDispatcher = Dispatcher.CurrentDispatcher;
            await Task.Factory.StartNew(async () =>
            {
                List<RegisteredSubject> registeredSubjects = await _registeredSubjectService.GetRegisteredSubjectsAsync();
                registeredSubjects = new List<RegisteredSubject>(registeredSubjects.OrderBy(s => s.Term.Name));

                currentDispatcher.Invoke(new Action(() =>
                {
                    RegisteredSubjects.Clear();
                    RegisteredSubjects.AddRange(registeredSubjects);
                }));
            });
        }

        private async void CompletedCheckboxOnCheckChanged(object obj)
        {
            await _registeredSubjectService.SetRegisteredSubjectCompletionAsync(SelectedRegisteredSubject);
        }

        private async void AddAttendanceOnClick(object obj)
        {
            var dialogViewModel = new CreateOrEditAttendanceDialogViewModel();
            if (dialogViewModel.ShowDialog() == true)
            {
                var attendance = new Attendance(dialogViewModel.AttendanceName)
                { 
                    Date = dialogViewModel.Date,
                    StartTime = dialogViewModel.StartTime,
                    EndTime = dialogViewModel.EndTime
                };

                await _registeredSubjectService.AddAttendanceToRegisteredSubjectAsync(SelectedRegisteredSubject, attendance);
            }
        }
        private async void EditAttendanceOnClick(object obj)
        {
            var attendance = SelectedAttendance;

            var dialogViewModel = new CreateOrEditAttendanceDialogViewModel(attendance.Name, attendance.Date, attendance.StartTime, attendance.EndTime);
            if (dialogViewModel.ShowDialog() == true)
            {
                attendance.Name = dialogViewModel.AttendanceName;
                attendance.Date = dialogViewModel.Date;
                attendance.StartTime = dialogViewModel.StartTime;
                attendance.EndTime = dialogViewModel.EndTime;

                await _registeredSubjectService.UpdateAttendanceAsync(attendance);
            }

            SelectedAttendanceIndex = -1;
        }
        private async void DeleteAttendanceOnClick(object obj)
        {
            var attendance = SelectedAttendance;

            var result = MessageBox.Show("Are you sure you want to delete this attendance?", "Delete subject", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                SelectedRegisteredSubject.RemoveAttendance(attendance);

                await _registeredSubjectService.DeleteAttendanceAsync(attendance);
            }

            SelectedAttendanceIndex = -1;
        }
    }
}
