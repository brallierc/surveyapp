using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SurveyApp.Views
{
    public partial class StartTestPage : ContentPage
    {
        public StartTestPage()
        {
            InitializeComponent();
        }

        private void MockData_Clicked(object sender, EventArgs e)
        {
            App.StartWithMockData();
        }

        private void ServerData_Clicked(object sender, EventArgs e)
        {
            App.StartWithRealData();
        }
    }
}
