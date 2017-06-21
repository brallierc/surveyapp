using System;
using System.Collections.Generic;
using SurveyApp.Models;
using SurveyApp.ViewModels;
using Xamarin.Forms;

namespace SurveyApp.Views
{
    public partial class SurveyListPage : ContentPage
    {
        public SurveyListPage()
        {
            InitializeComponent();
            var viewModel = new SurveyListPageViewModel();
            viewModel.RefreshCommand.Execute(null);
            BindingContext = new SurveyListPageViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((SurveyListPageViewModel)BindingContext).RefreshCommand.Execute(null);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Survey;
            if (item == null)
                return;

            if (item.IsAnswered)
                await Navigation.PushAsync(new SurveyDetailPage(item));
            else
                await Navigation.PushAsync(new SurveyAnswerPage(item));

            // Manually deselect item
            SurveyList.SelectedItem = null;
        }

        async void NewSurvey_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateSurveyPage());
        }
    }
}
