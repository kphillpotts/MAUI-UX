namespace MauiUX.Pages;

public partial class TransformsPage : ContentPage
{
	public TransformsPage()
	{
		InitializeComponent();
	}

    void Handle_Clicked(object sender, System.EventArgs e)
    {
        ScaleSlider.Value = 1;
        OpacitySlider.Value = 1;
        RotationSlider.Value = 0;
        RotationXSlider.Value = 0;
        RotationYSlider.Value = 0;
        TranslationXSlider.Value = 0;
        TranslationYSlider.Value = 0;
    }

}