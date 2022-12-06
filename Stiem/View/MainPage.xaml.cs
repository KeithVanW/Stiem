namespace Stiem.View;

public partial class MainPage : ContentPage
{
    public MainPage(GamesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    //private void searchByNameEntry_Unfocused(object sender, FocusEventArgs e)
    //{
    //    searchByNameEntry.Text = string.Empty;
    //}

    //private void searchByGenreEntry_Unfocused(object sender, FocusEventArgs e)
    //{
    //    searchByGenreEntry.Text = string.Empty;
    //}
}