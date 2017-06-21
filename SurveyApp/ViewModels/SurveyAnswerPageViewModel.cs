using System;
using SurveyApp.Models;

namespace SurveyApp.ViewModels
{
    public class SurveyAnswerPageViewModel : BaseViewModel
    {
        public SurveyAnswerPageViewModel(Survey survey)
        {
            Title = survey.Title;
        }
    }
}
