namespace MauiUX.Pages;

public partial class FontsPage : ContentPage
{
	public FontsPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		LineSpacingSlider.Value = 1;
		CharacterSpacingSlider.Value = 0;
    }
}