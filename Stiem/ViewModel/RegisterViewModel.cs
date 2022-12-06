using Stiem.Services;

namespace Stiem.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly UserService _userService;

        public RegisterViewModel(UserService userService)
        {
            _userService = userService;
        }
    }
}
