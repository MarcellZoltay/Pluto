using Pluto.Wpf.Views.Dialogs;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.Wpf.ViewModels.Dialogs
{
    public class CreateOrEditAttendanceDialogViewModel : BindableBase
    {
        public string Title { get; private set; }
        public string ButtonContent { get; private set; }

        public string AttendanceName { get; set; }
        public DateTime Date { get; set; }

        private TimeSpan startTime;
        public TimeSpan StartTime
        {
            get => startTime;
            set => SetProperty(ref startTime, value);
        }

        private TimeSpan endTime;
        public TimeSpan EndTime
        {
            get => endTime;
            set => SetProperty(ref endTime, value);
        }

        public DelegateCommand AddSaveCommand { get; private set; }
        public DelegateCommand BackCommand { get; private set; }

        public DelegateCommand IncreaseStartTimeHourCommand { get; private set; }
        public DelegateCommand DecreaseStartTimeHourCommand { get; private set; }
        public DelegateCommand IncreaseStartTimeMinuteCommand { get; private set; }
        public DelegateCommand DecreaseStartTimeMinuteCommand { get; private set; }

        public DelegateCommand IncreaseEndTimeHourCommand { get; private set; }
        public DelegateCommand DecreaseEndTimeHourCommand { get; private set; }
        public DelegateCommand IncreaseEndTimeMinuteCommand { get; private set; }
        public DelegateCommand DecreaseEndTimeMinuteCommand { get; private set; }

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
        private CreateOrEditAttendanceDialog view;

        public CreateOrEditAttendanceDialogViewModel()
        {
            Title = "Add attendance";
            ButtonContent = "Add";

            Date = DateTime.Today;

            InitCommands();
        }
        public CreateOrEditAttendanceDialogViewModel(string name, DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            Title = "Edit attendance";
            ButtonContent = "Save";

            AttendanceName = name;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;

            InitCommands();
        }

        private void InitCommands()
        {
            AddSaveCommand = new DelegateCommand(AddSaveOnClick);
            BackCommand = new DelegateCommand(BackOnClick);

            IncreaseStartTimeHourCommand = new DelegateCommand(IncreaseStartTimeHourOnClick);
            DecreaseStartTimeHourCommand = new DelegateCommand(DecreaseStartTimeHourOnClick);
            IncreaseStartTimeMinuteCommand = new DelegateCommand(IncreaseStartTimeMinuteOnClick);
            DecreaseStartTimeMinuteCommand = new DelegateCommand(DecreaseStartTimeMinuteOnClick);

            IncreaseEndTimeHourCommand = new DelegateCommand(IncreaseEndTimeHourOnClick);
            DecreaseEndTimeHourCommand = new DelegateCommand(DecreaseEndTimeHourOnClick);
            IncreaseEndTimeMinuteCommand = new DelegateCommand(IncreaseEndTimeMinuteOnClick);
            DecreaseEndTimeMinuteCommand = new DelegateCommand(DecreaseEndTimeMinuteOnClick);
        }

        public bool? ShowDialog()
        {
            view = new CreateOrEditAttendanceDialog();
            view.DataContext = this;
            view.ShowDialog();

            return DialogResult;
        }

        private void AddSaveOnClick()
        {
            DialogResult = true;
        }
        private void BackOnClick()
        {
            DialogResult = false;
        }

        private void IncreaseStartTimeHourOnClick()
        {
            StartTime = IncreaseHour(StartTime);
        }
        private void DecreaseStartTimeHourOnClick()
        {
            StartTime = DecreaseHour(StartTime);
        }
        private void IncreaseStartTimeMinuteOnClick()
        {
            StartTime = IncreaseMinute(StartTime);
        }
        private void DecreaseStartTimeMinuteOnClick()
        {
            StartTime = DecreaseMinute(StartTime);
        }

        private void IncreaseEndTimeHourOnClick()
        {
            EndTime = IncreaseHour(EndTime);
        }
        private void DecreaseEndTimeHourOnClick()
        {
            EndTime = DecreaseHour(EndTime);
        }
        private void IncreaseEndTimeMinuteOnClick()
        {
            EndTime = IncreaseMinute(EndTime);
        }
        private void DecreaseEndTimeMinuteOnClick()
        {
            EndTime = DecreaseMinute(EndTime);
        }

        private TimeSpan IncreaseHour(TimeSpan time)
        {
            if (time.Hours == 23)
                return new TimeSpan(0, time.Minutes, time.Seconds);
            else
                return time.Add(new TimeSpan(1, 0, 0));
        }
        private TimeSpan DecreaseHour(TimeSpan time)
        {
            if (time.Hours == 0)
                return new TimeSpan(23, time.Minutes, time.Seconds);
            else
                return time.Subtract(new TimeSpan(1, 0, 0));
        }
        private TimeSpan IncreaseMinute(TimeSpan time)
        {
            if (time.Minutes == 55)
                return new TimeSpan(time.Hours, 0, time.Seconds);
            else
                return time.Add(new TimeSpan(0, 5, 0));
        }
        private TimeSpan DecreaseMinute(TimeSpan time)
        {
            if (time.Minutes == 0)
                return new TimeSpan(time.Hours, 55, time.Seconds);
            else
                return time.Subtract(new TimeSpan(0, 5, 0));
        }
    }
}
