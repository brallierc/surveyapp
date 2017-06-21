using System.Collections.Generic;
using SurveyApp.Services;
using SurveyApp.Views;
using Xamarin.Forms;

namespace SurveyApp
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";

        public static IDictionary<string, string> LoginParameters => null;

        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new StartTestPage());
        }


        public static void StartWithMockData()
        {
            UseMockDataStore = true;
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<MockSurveyStore>();

            Current.MainPage = new NavigationPage(new SurveyListPage());

        }

        public static void StartWithRealData()
        {
            UseMockDataStore = false;
            DependencyService.Register<CloudDataStore>();
            DependencyService.Register<CloudSurveyStore>();
            Current.MainPage = new NavigationPage(new SurveyListPage());
        }
    }
}
