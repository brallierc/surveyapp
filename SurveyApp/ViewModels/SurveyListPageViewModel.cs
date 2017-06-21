using System;
using System.Windows.Input;
using SurveyApp.Models;
using Xamarin.Forms;

namespace SurveyApp.ViewModels
{
    public class SurveyListPageViewModel : BaseViewModel
    {
        private readonly IDataStore<Survey> _surveyStore;
        private ObservableRangeCollection<Survey> _surveys;
        private ICommand _refreshCommand;


        public ICommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new Command(async () =>
        {
            try
            {
                IsBusy = true;
                var items = await _surveyStore.GetItemsAsync(true);
                if (items != null)
                {
                    Surveys.Clear();
                    Surveys.AddRange(items);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }));
        public ObservableRangeCollection<Survey> Surveys
        {
            get
            {
                return _surveys;
            }
            set
            {
                SetProperty(ref _surveys, value);
            }
        }

        public SurveyListPageViewModel()
        {
            Surveys = new ObservableRangeCollection<Survey>();
            _surveyStore = DependencyService.Get<IDataStore<Survey>>();
            Title = "Surveys";
        }
    }
}
