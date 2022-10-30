namespace MauiUX.Views;

public partial class ExpandBar : ContentView
{
	public ExpandBar()
	{
		InitializeComponent();
	}

    public bool IsLabelVisible
    {
        get { return ExpandLabel.IsVisible; }
        set { ExpandLabel.IsVisible = value; }

    }
}