namespace Stiem.View;

public partial class MainPage : ContentPage
{
	public MainPage(GamesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

