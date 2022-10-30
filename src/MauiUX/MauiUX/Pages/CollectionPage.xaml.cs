using MauiUX.CardStyles;

namespace MauiUX.Pages;

public partial class CollectionPage : ContentPage
{
	public CollectionPage()
	{
		InitializeComponent();

        myCollection.ItemsSource = Data.DataService.GetData();
    }

	private void Button_Clicked(object sender, EventArgs e)
	{
        myCollection.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
        {
            ItemSpacing = 0
        };

        myCollection.ItemTemplate = (DataTemplate)Resources["Card1"];
    }

	private void Button_Clicked_1(object sender, EventArgs e)
	{
        myCollection.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
        {
            ItemSpacing = 0
        };
        myCollection.ItemTemplate = (DataTemplate)Resources["Card2"];
    }
    private void Button_Clicked_2(object sender, EventArgs e)
    {
        myCollection.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal)
        {
            ItemSpacing = 0
        };
        myCollection.ItemTemplate = (DataTemplate)Resources["Card3"];
    }
    private void Button_Clicked_3(object sender, EventArgs e)
    {
        myCollection.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
        {
            ItemSpacing = 0
        };
        myCollection.ItemTemplate = (DataTemplate)Resources["GradientCard"];
    }

    private void Button_Clicked_4(object sender, EventArgs e)
    {
        myCollection.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
        {
            ItemSpacing = 0
        };

        myCollection.ItemTemplate = (DataTemplate)Resources["ColorCard"];
    }
}