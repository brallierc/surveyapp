using System;
using System.Collections.Generic;
using System.Linq;
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

        private void Create_Clicked(object s, EventArgs a)
        {
            var vm = (CreateSurveyPageViewModel)BindingContext;
            var entries = new List<Entry>();
            entries.Add(FirstOptionEntry);
            foreach(StackLayout entryContainer in OptionContainer.Children)
            {
                var entry = entryContainer.Children.FirstOrDefault(view => view.GetType() == typeof(Entry));
                entries.Add((Entry)entry);
            }
            vm.Options = entries.Where(entry => !string.IsNullOrEmpty(entry.Text)).Select(entry => entry.Text);
            vm.CreateCommand.Execute(null);
            Navigation.PopAsync();
        }

        private void AddOption_Clicked(object s, EventArgs a)
        {
            var newOptionContainer = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            var newOptionEntry = new Entry()
            {
                Placeholder = "Option",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            var removeOptionButton = new Button()
            {
                Text = "Delete"
            };
            removeOptionButton.Clicked += (sender, e) =>
            {
                OptionContainer.Children.Remove(newOptionContainer);
            };
            newOptionContainer.Children.Add(newOptionEntry);
            newOptionContainer.Children.Add(removeOptionButton);
            OptionContainer.Children.Add(newOptionContainer);
        }
    }
}
