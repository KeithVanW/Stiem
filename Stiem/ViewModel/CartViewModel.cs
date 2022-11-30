using Stiem.Services;
using System.Collections.ObjectModel;

namespace Stiem.ViewModel
{
    public partial class CartViewModel : BaseViewModel
    {
        public ObservableCollection<Game> Cart { get; } = new();
        CartService _cartService;
        public CartViewModel(CartService cartService)
        {
            Title = "Steam";
            _cartService = cartService;
        }

        [RelayCommand]
        async Task GetGamesAsync()
        {
            ICollection<Game> games = await _cartService.GetGamesByUserIdAsync();

            foreach (var game in games)
            {
                Cart.Add(game);
            }
        }
    }
}
