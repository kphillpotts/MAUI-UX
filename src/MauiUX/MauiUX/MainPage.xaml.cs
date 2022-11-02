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

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Pages.AnimationPage());
	}

	private async void Button_Clicked_1(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Pages.CollectionPage());
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.SkiaPage());
    }
}

