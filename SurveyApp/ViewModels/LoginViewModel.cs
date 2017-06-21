﻿using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace SurveyApp
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            SignInCommand = new Command(async () => await SignIn());
        }

        string message = string.Empty;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged(); }
        }

        public ICommand NotNowCommand { get; }
        public ICommand SignInCommand { get; }

        async Task SignIn()
        {
            try
            {
                IsBusy = true;
                Message = "Signing In...";

                // Log the user in
                await TryLoginAsync();
            }
            finally
            {
                Message = string.Empty;
                IsBusy = false;

            }
        }

        public static async Task<bool> TryLoginAsync()
        {
            return true;
        }
    }
}
