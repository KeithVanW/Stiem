using Stiem.Services;
using Stiem.View;
using System.Collections.ObjectModel;

namespace Stiem.ViewModel
{
    public partial class GamesViewModel : BaseViewModel
    {
        private string _nameParam;

        public string NameParam
        {
            get { return _nameParam; }
            set
            {
                _nameParam = value;
                SearchByNameCommand.Execute(_nameParam);
                OnPropertyChanged();
            }
        }

        private string _genreParam;

        public string GenreParam
        {
            get { return _genreParam; }
            set
            {
                _genreParam = value;
                SearchByGenreCommand.Execute(_genreParam);
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Game> Games { get; } = new();
        public CartService _cartService { get; }

        private GameService _gameService;

        public GamesViewModel(GameService gameService, CartService cartService)
        {
            Title = "Stiem";
            _gameService = gameService;
            _cartService = cartService;
            _ = GetGamesAsync();
        }

        [RelayCommand]
        private async Task GetGamesAsync()
        {
            ICollection<Game> games = await _gameService.GetAllGames();

            foreach (var game in games)
            {
                Games.Add(game);
            }
        }

        [RelayCommand]
        private async Task GoToCart()
        {
            await Shell.Current.GoToAsync(nameof(CartPage));
        }

        [RelayCommand]
        private async Task AddToCart(int gameID)
        {
            await _cartService.AddGameToCart(gameID);
        }

        [RelayCommand]
        private async Task SearchByName(string nameParam)
        {
            if (string.IsNullOrEmpty(nameParam))
            {
                await GetGamesAsync();
            }
            else
            {
                ICollection<Game> games = await _gameService.SearchByName(nameParam);

                Games.Clear();

                if (games != null)
                {
                    foreach (var game in games)
                    {
                        Games.Add(game);
                    }
                }
            }
        }

        [RelayCommand]
        private async Task SearchByGenre(string genreParam)
        {
            if (string.IsNullOrEmpty(genreParam))
            {
                await GetGamesAsync();
            }
            else
            {
                ICollection<Game> games = await _gameService.SearchByGenre(genreParam);

                Games.Clear();

                if (games != null)
                {
                    foreach (var game in games)
                    {
                        Games.Add(game);
                    }
                }
            }
        }
    }
}