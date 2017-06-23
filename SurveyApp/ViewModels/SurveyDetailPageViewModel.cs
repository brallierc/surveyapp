using System;
using SurveyApp.Models;

namespace SurveyApp.ViewModels
{
    public class SurveyDetailPageViewModel : BaseViewModel
    {
        private string _description;
        private string _question;
        private string _answer;
        private readonly Survey _survey;
       
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
        public SurveyDetailPageViewModel(Survey survey)
        {
            _survey = survey;
            Title = survey.Title;
            Answer = survey.Answer;
            Description = survey.Description;
            Question = survey.Question;
        }
    }
}
