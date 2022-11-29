namespace Stiem.View;

public partial class MainPage : ContentPage
{
	public MainPage(GamesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private void cartButton_Clicked(object sender, EventArgs e)
    {

    }

    private void homeButton_Clicked(object sender, EventArgs e)
    {

    }
}

