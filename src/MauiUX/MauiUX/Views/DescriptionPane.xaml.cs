namespace MauiUX.Views;

public partial class DescriptionPane : ContentView
{
	public DescriptionPane()
	{
		InitializeComponent();
	}

    public string Text
    {
        get
        {
            return Description.Text;
        }
        set
        {
            Description.Text = value;
        }
    }
}