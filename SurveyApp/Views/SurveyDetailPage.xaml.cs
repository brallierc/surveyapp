﻿using System;
using System.Collections.Generic;
using SurveyApp.Models;
using SurveyApp.ViewModels;
using Xamarin.Forms;

namespace SurveyApp.Views
{
    public partial class SurveyDetailPage : ContentPage
    {
        public SurveyDetailPage(Survey model)
        {
            InitializeComponent();
            BindingContext = new SurveyDetailPageViewModel(model);
        }
    }
}
