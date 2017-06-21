using System;
using System.Windows.Input;
using SurveyApp.Models;
using Xamarin.Forms;

namespace SurveyApp.ViewModels
{
    public class CreateSurveyPageViewModel : BaseViewModel
    {
        private readonly IDataStore<Survey> _surveyStore;
        private string _title;
        private string _description;
        private string _question;
        private ObservableRangeCollection<string> _options;
        private ICommand _createCommand;

        public string NewTitle
        {
            get
            {
                return _title;
            }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                SetProperty(ref _description, value);
            }
        }

        public string Question
        {
            get
            {
                return _question;
            }
            set
            {
                SetProperty(ref _question, value);
            }
        }

        public ObservableRangeCollection<string> Options
        {
            get
            {
                return _options;
            }
            set
            {
                SetProperty(ref _options, value);
            }
        }

        public ICommand CreateCommand => _createCommand ?? (_createCommand = new Command(async () =>
        {
            var newSurvey = new Survey
            {
                Title = Title,
                Description = Description,
                Question = Question,
                Options = Options
            };
            await _surveyStore.AddItemAsync(newSurvey);
        }));

        public CreateSurveyPageViewModel()
        {
            _surveyStore = DependencyService.Get<IDataStore<Survey>>();
            Title = "New Survey";
        }
    }
}
