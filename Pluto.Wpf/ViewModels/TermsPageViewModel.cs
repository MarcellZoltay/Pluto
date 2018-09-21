using Pluto.BLL.Model;
using Pluto.BLL.Services;
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

namespace Pluto.Wpf.ViewModels
{
    public class TermsPageViewModel : BindableBase
    {
        private string _title = "Terms page";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private AsyncObservableCollection<Term> terms;
        public AsyncObservableCollection<Term> Terms
        {
            get { return terms; }
            set { SetProperty(ref terms, value); }
        }

        public int SelectedTermIndex { get; set; }

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

            Terms = new AsyncObservableCollection<Term>();

            Task.Factory.StartNew(async () => {
                List<Term> terms = await _termService.GetTermsAsync();
                //Terms = new ObservableCollection<Term>();
                Terms.AddRange(terms);

                IsLoading = false;
            });
        }

        private async void NewTermOnClick(object obj)
        {
            var termName = (Terms.Count + 1).ToString() + ". term";
            var dialogViewModel = new CreateOrEditTermDialogViewModel(termName);
            if(dialogViewModel.ShowDialog() == true)
            {
                var term = new Term(dialogViewModel.TermName, dialogViewModel.TermIsActive);

                Terms.Add(term);
                await _termService.AddTermAsync(term);
            }
        }
        private async void EditTermOnClick(object obj)
        {
            var term = Terms.ElementAt(SelectedTermIndex);

            var dialogViewModel = new CreateOrEditTermDialogViewModel(term.Name, term.IsActive);
            if(dialogViewModel.ShowDialog() == true)
            {
                term.IsActive = dialogViewModel.TermIsActive;
                SelectedTermIndex = -1;

                await _termService.UpdateTermAsync(term);
            }
        }
        private async void DeleteLastTermOnClick(object obj)
        {
            var result = MessageBox.Show("Are you sure you want to delete the last term?", "Delete term", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                var deletable = await _termService.DeleteLastTermAsync();
                if(deletable)
                    Terms.RemoveAt(Terms.Count - 1);
                else
                    MessageBox.Show("This term cannot be deleted! Only not closed and empty term can be deleted.", "Delete term", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private async void CloseTermOnClick(object obj)
        {
            var term = Terms.ElementAt(SelectedTermIndex);

            var result = MessageBox.Show("Are you sure you want to close this term?", "Close term", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                var canBeClosed = await _termService.CloseTermAsync(term);
                if(!canBeClosed)
                    MessageBox.Show("This term cannot be closed!", "Close term", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
