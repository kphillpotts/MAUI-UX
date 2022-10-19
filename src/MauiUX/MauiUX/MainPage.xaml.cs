namespace MauiUX;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void OnTransformsClicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Pages.TransformsPage());
	}
}

