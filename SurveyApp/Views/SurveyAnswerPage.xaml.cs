﻿using System;
using System.Collections.Generic;
using SurveyApp.Models;
using SurveyApp.ViewModels;
using Xamarin.Forms;

namespace SurveyApp.Views
{
    public partial class SurveyAnswerPage : ContentPage
    {
        public SurveyAnswerPage(Survey model)
        {
            InitializeComponent();
            BindingContext = new SurveyAnswerPageViewModel(model);
            MessagingCenter.Subscribe<SurveyAnswerPageViewModel, Survey>(BindingContext, "GO_BACK", (vm, survey) =>
            {
                Navigation?.PopAsync();
            });
        }
    }
}
