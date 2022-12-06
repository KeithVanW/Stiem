using Stiem.Services;
using Stiem.View;

namespace Stiem.ViewModel
{
    public partial class RegisterViewModel : BaseViewModel
    {
        private readonly UserService _userService;

        [ObservableProperty]
        private string errorMessage = "";

        public RegisterViewModel(UserService userService)
        {
            _userService = userService;
        }
    }
}
