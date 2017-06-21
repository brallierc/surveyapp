﻿using System;
using SurveyApp.Models;

namespace SurveyApp.ViewModels
{
    public class SurveyDetailPageViewModel : BaseViewModel
    {
        public SurveyDetailPageViewModel(Survey survey)
        {
            Title = survey.Title;
        }
    }
}
