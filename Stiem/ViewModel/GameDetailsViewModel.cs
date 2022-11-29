namespace Stiem.ViewModel
{
    [QueryProperty(nameof(Game), "Game")]
    public partial class GameDetailsViewModel : BaseViewModel
    {
        public GameDetailsViewModel()
        {

        }
        [ObservableProperty]
        Game game;
    }
}
