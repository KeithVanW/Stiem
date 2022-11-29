using Microsoft.Maui.Controls;
using Stiem.Services;
using Stiem.View;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;

namespace Stiem.ViewModel
{
    public partial class GamesViewModel : BaseViewModel
    {
        public ObservableCollection<Game> Games { get; } = new();
        GameService _gameService;
        public GamesViewModel(GameService gameService)
        {
            Title = "Stiem";
            _gameService = gameService;
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
        async Task GoToDetails(GameService game)
        {
            if (game == null)
            {
                return;
            }

            await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
            {
                { "Game", game }
            });
        }

        [RelayCommand]
        async Task GoToHome()
        {

        }

        [RelayCommand]
        async Task GoToCart()
        {

        }


    }
}