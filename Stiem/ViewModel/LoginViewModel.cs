using Stiem.View;

namespace Stiem.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {

        public LoginViewModel()
        {
            Title = "Login";
        }

        [RelayCommand]
        async Task GoToMain()
        {
            await Shell.Current.GoToAsync(nameof(MainPage));
        }
    }
}
