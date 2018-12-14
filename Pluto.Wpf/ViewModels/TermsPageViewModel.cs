using Pluto.BLL.Model;
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
    public class TermsPageViewModel : BindableBase
    {
        private ObservableCollection<Term> terms;
        public ObservableCollection<Term> Terms
        {
            get { return terms; }
            set { SetProperty(ref terms, value); }
        }

        public int SelectedTermIndex { get; set; }
        public Term SelectedTerm { get; set; }

        private bool _isLoading = true;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }


        private ITermService _termService;

        public RelayCommand NewTermCommand { get; private set; }
        public RelayCommand EditTermCommand { get; private set; }
        public RelayCommand DeleteLastTermCommand { get; private set; }
        public RelayCommand CloseTermCommand { get; private set; }

        public TermsPageViewModel(ITermService termService)
        {
            _termService = termService;

            NewTermCommand = new RelayCommand(NewTermOnClick);
            EditTermCommand = new RelayCommand(EditTermOnClick, p => SelectedTermIndex > -1);
            DeleteLastTermCommand = new RelayCommand(DeleteLastTermOnClick, p => Terms.Count > 0);
            CloseTermCommand = new RelayCommand(CloseTermOnClick, p => SelectedTermIndex > -1);

            SelectedTermIndex = -1;

            Terms = new ObservableCollection<Term>();

            var currentDispatcher = Dispatcher.CurrentDispatcher;
            Task.Factory.StartNew(async () =>
            {
                List<Term> terms = await _termService.GetTermsAsync();

                currentDispatcher.Invoke(new Action(() =>
                {
                    Terms.AddRange(terms);
                    IsLoading = false;
                }));
            });
        }

        private async void NewTermOnClick(object obj)
        {
            var termName = (Terms.Count + 1).ToString();
            var dialogViewModel = new CreateOrEditTermDialogViewModel(termName);
            if (dialogViewModel.ShowDialog() == true)
            {
                try
                {
                    var term = new Term(dialogViewModel.TermName, dialogViewModel.TermIsActive, new Period(dialogViewModel.SelectedStartDate, dialogViewModel.SelectedEndDate));

                    Terms.Add(term);
                    await _termService.AddTermAsync(term);
                }
                catch(InvalidOperationException e)
                {
                    MessageBox.Show(e.Message, Strings.TermDialog_Title_CreateTerm, MessageBoxButton.OK);
                }
            }
        }
        private async void EditTermOnClick(object obj)
        {
            var term = SelectedTerm;

            DateTime startDate, endDate;

            if (term.Period != null)
            {
                startDate = term.Period.StartDate;
                endDate = term.Period.EndDate;
            }
            else
            {
                startDate = DateTime.Today;
                endDate = DateTime.Today;
            }

            var dialogViewModel = new CreateOrEditTermDialogViewModel(term.Name, term.IsActive, startDate, endDate);
            if (dialogViewModel.ShowDialog() == true)
            {
                try
                {
                    if (dialogViewModel.TermIsActive)
                        term.SetActive(new Period(dialogViewModel.SelectedStartDate, dialogViewModel.SelectedEndDate));
                    else
                        term.SetPassive();

                    await _termService.UpdateTermAsync(term);
                }
                catch (InvalidOperationException e)
                {
                    MessageBox.Show(e.Message, Strings.TermDialog_Title_EditTerm, MessageBoxButton.OK);
                }

                SelectedTermIndex = -1;
            }
        }
        private async void DeleteLastTermOnClick(object obj)
        {
            var result = MessageBox.Show(Strings.TermDialog_Question_DeleteLastTerm + "?", Strings.TermDialog_Title_DeleteLastTerm, MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                var deletable = await _termService.DeleteLastTermAsync();
                if (deletable)
                    Terms.RemoveAt(Terms.Count - 1);
                else
                    MessageBox.Show(Strings.TermDIalog_Meassage_DeleteLastTerm + ".", Strings.TermDialog_Title_DeleteLastTerm, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private async void CloseTermOnClick(object obj)
        {
            var term = SelectedTerm;

            var result = MessageBox.Show(Strings.TermDialog_Question_CloseTerm + "?", Strings.TermDialog_Title_CloseTerm, MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                var canBeClosed = await _termService.CloseTermAsync(term);
                if (!canBeClosed)
                    MessageBox.Show(Strings.TermDialog_Message_CloseTerm + "!", Strings.TermDialog_Title_CloseTerm, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
