using Stiem.Services;
using Stiem.View;

namespace Stiem.ViewModel
{
    public partial class RegisterViewModel : BaseViewModel
    {
        [ObservableProperty]
        private RegisterUser registerUser = new();

        private readonly UserService _userService;

        [ObservableProperty]
        private string errorMessage = "";

        public RegisterViewModel(UserService userService)
        {
            _userService = userService;
        }

        [RelayCommand]
        private async Task Register()
        {
            if (await _userService.Register(RegisterUser))
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
