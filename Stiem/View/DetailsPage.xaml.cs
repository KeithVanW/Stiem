namespace Stiem.View;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(GameDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel; 
    }
}