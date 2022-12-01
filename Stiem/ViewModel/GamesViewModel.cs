using Stiem.Services;
using Stiem.View;
using System.Collections.ObjectModel;

namespace Stiem.ViewModel
{
    public partial class GamesViewModel : BaseViewModel
    {
        public ObservableCollection<Game> Games { get; } = new();
        public CartService _cartService { get; }

        GameService _gameService;
        public GamesViewModel(GameService gameService, CartService cartService)
        {
            Title = "Stiem";
            _gameService = gameService;
            _cartService = cartService;
            _ = GetGamesAsync();

        }

        [RelayCommand]
        async Task GetGamesAsync()
        {
            ICollection<Game> games = await _gameService.GetAllGames();

            foreach (var game in games)
            {
                Games.Add(game);
            }
        }

        [RelayCommand]
        async Task GoToCart()
        {
            await Shell.Current.GoToAsync(nameof(CartPage));
        }

        [RelayCommand]
        async Task AddToCart(int gameID)
        {
            await _cartService.AddGameToCart(gameID);
        }


    }
}