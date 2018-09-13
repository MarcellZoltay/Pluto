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

        private ObservableCollection<Term> terms;
        public ObservableCollection<Term> Terms
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

        public TermsPageViewModel(ITermService termService)
        {
            _termService = termService;

            NewTermCommand = new RelayCommand(NewTermOnClick);
            EditTermCommand = new RelayCommand(EditTermOnClick, p => SelectedTermIndex > -1);
            DeleteLastTermCommand = new RelayCommand(DeleteLastTermOnClick);

            SelectedTermIndex = -1;

            Task.Factory.StartNew(async () => {
                List<Term> terms = await _termService.GetTerms();
                Terms = new ObservableCollection<Term>();
                Terms.AddRange(terms);

                IsLoading = false;
            });
        }

        private void NewTermOnClick(object obj)
        {
            var dialogViewModel = new CreateOrEditTermDialogViewModel();
            if(dialogViewModel.ShowDialog() == true)
            {
                var term = dialogViewModel.Term;
                term.Name = (Terms.Count+1).ToString() + ". term";

                _termService.AddTerm(term);
                Terms.Add(term);
            }
        }
        private void EditTermOnClick(object obj)
        {
            var term = Terms.ElementAt(SelectedTermIndex);

            var dialogViewModel = new CreateOrEditTermDialogViewModel(term);
            if(dialogViewModel.ShowDialog() == true)
            {
                _termService.UpdateTerm(term);
            }

            SelectedTermIndex = -1;
        }
        private void DeleteLastTermOnClick(object obj)
        {
            var result = MessageBox.Show("Are you sure you want to delete the last term ", "Delete term", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                _termService.DeleteLastTerm();
                Terms.RemoveAt(Terms.Count - 1);
            }
        }
    }
}
