using Stiem.Services;
using System.Collections.ObjectModel;

namespace Stiem.ViewModel
{
    public partial class CartViewModel : BaseViewModel
    {
        public ObservableCollection<Game> CartGames { get; } = new();

        [ObservableProperty]
        private double totalPrice;

        private CartService _cartService;

        public CartViewModel(CartService cartService)
        {
            Title = "Cart";
            _cartService = cartService;
            _ = GetGamesAsync();
        }

        private async Task GetGamesAsync()
        {
            CartOverview cart = await _cartService.GetGamesInCartAsync();
            IEnumerable<Game> games = cart.Games;
            TotalPrice = cart.TotalPrice;

            CartGames.Clear();

            foreach (var game in games)
            {
                CartGames.Add(game);
            }
        }

        [RelayCommand]
        private async Task RemoveFromCart(int gameID)
        {
            await _cartService.RemoveFromCart(gameID);
            await GetGamesAsync();
        }

        [RelayCommand]
        private async Task ClearCart()
        {
            await _cartService.ClearCart();
            await GetGamesAsync();
        }
    }
}