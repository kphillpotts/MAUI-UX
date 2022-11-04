namespace MauiUX;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void TransformsPage_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Pages.TransformsPage());
	}

	private async void FontsPage_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Pages.FontsPage());
	}

	private async void CollectionPage_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Pages.CollectionPage());
    }

    private async void SkiaPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.SkiaPage());
    }

    private async void LottiePage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.LottiePage());
    }

    private async void ThemPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.ThemePage());
    }

}

