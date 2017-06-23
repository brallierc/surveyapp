using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using SurveyApp.Models;
using Xamarin.Forms;

namespace SurveyApp.ViewModels
{
    public class SurveyAnswerPageViewModel : BaseViewModel
    {
        private string _description;
        private string _question;
        private string _answer;
        private List<string> _options;
        private ICommand _answerCommand;
        private readonly Survey _survey;
        private readonly IDataStore<Survey> _surveyStore;

        public ICommand AnswerCommand => _answerCommand ??
        (_answerCommand = new Command(async () =>
        {
            try
            {
                IsBusy = true;
                _survey.Answer = Answer;
                _survey.IsAnswered = true;
                var result = await _surveyStore.UpdateItemAsync(_survey);
                if (result)
                {
                    MessagingCenter.Send(this, "GO_BACK", _survey);
                }
            }
            finally
            {
                IsBusy = false;
            }

        }));
        public List<string> Options
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
        public string Answer
        {
            get
            {
                return _answer;
            }
            set
            {
                SetProperty(ref _answer, value);
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
        public SurveyAnswerPageViewModel(Survey survey)
        {
            _survey = survey;
            _surveyStore = DependencyService.Get<IDataStore<Survey>>();
            Title = survey.Title;
            Description = survey.Description;
            Question = survey.Question;
            Options = survey.Options.ToList();
        }
    }
}
