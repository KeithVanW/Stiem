using Stiem.Services;
using Stiem.View;

namespace Stiem.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly UserService _userService;

        public LoginViewModel(UserService userService)
        {
            Title = "Login";
            _userService = userService;
        }

        [RelayCommand]
        async Task GoToMain()
        {
            await Shell.Current.GoToAsync(nameof(MainPage));
        }

        [RelayCommand]
        async Task Login()
        {
            await _userService.Login();
            await Shell.Current.GoToAsync(nameof(MainPage));
        }
    }
}
