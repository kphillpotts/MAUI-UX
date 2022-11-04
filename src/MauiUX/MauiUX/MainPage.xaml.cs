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
		await Navigation.PushAsync(new Pages.FontsPage());
	}

	private async void Button_Clicked_1(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Pages.CollectionPage());
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.SkiaPage());
    }

    private async void Button_Clicked_3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.LottiePage());
    }

    private async void Button_Clicked_Themes(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.ThemePage());
    }

}

