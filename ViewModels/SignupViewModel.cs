﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Game.Services;

namespace Game.ViewModels
{
    public sealed partial class SignupViewModel : ObservableObject
    {
        private readonly IUserService userService;

        [ObservableProperty]
        private string username = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;
        public SignupViewModel(IUserService userService)
        {
            this.userService = userService;
        }

        [RelayCommand]
        private async void CreateUser()
        {
            
            if (string.IsNullOrEmpty(Username))
            {
                return;
            }
            if(Password.Length >= 8)
            {
                await userService.AddNewUser(Username, Password);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Invalid", "Password length needs to be at least 8 characters long", "OK");
            }
            this.Username = string.Empty;
            this.Password = string.Empty;
        }
    }
}
