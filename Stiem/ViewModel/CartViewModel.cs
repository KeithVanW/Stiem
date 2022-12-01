using Stiem.Services;
using System.Collections.ObjectModel;

namespace Stiem.ViewModel
{
    public partial class CartViewModel : BaseViewModel
    {
        public ObservableCollection<Game> CartGames { get; } = new();
        CartService _cartService;
        public CartViewModel(CartService cartService)
        {
            Title = "Cart";
            _cartService = cartService;
            _ = GetGamesAsync();
        }

        [RelayCommand]
        async Task GetGamesAsync()
        {
            ICollection<Game> games = await _cartService.GetGamesInCartAsync();

            foreach (var game in games)
            {
                CartGames.Add(game);
            }
        }
        [RelayCommand]
        async Task RemoveFromCart(int gameID)
        {
            await _cartService.RemoveFromCart(gameID);
            CartGames.Remove(new Game { GameID = gameID });

            // Remove from observable collection
        }
    }
}
