using System;
using System.Collections.Generic;
using SurveyApp.ViewModels;
using Xamarin.Forms;

namespace SurveyApp.Views
{
    public partial class CreateSurveyPage : ContentPage
    {
        public CreateSurveyPage()
        {
            InitializeComponent();
            BindingContext = new CreateSurveyPageViewModel();
        }
    }
}
