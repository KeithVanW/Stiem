using Stiem.Services;
using Stiem.View;

namespace Stiem.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly UserService _userService;

        [ObservableProperty]
        private string errorMessage = "";

        public LoginViewModel(UserService userService)
        {
            Title = "Login";
            _userService = userService;
        }

        [RelayCommand]
        private async Task GoToMain()
        {
            await Shell.Current.GoToAsync(nameof(MainPage));
        }

        [RelayCommand]
        private async Task GoToRegister()
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }

        [RelayCommand]
        private async Task Login()
        {
            if (await _userService.Login())
            {
                await Shell.Current.GoToAsync(nameof(MainPage));
            }
            else
            {
                ErrorMessage = "Login Failed!";
            }
        }
    }
}