using MauiUX.CardStyles;

namespace MauiUX.Pages;

public partial class CollectionPage : ContentPage
{
	public CollectionPage()
	{
		InitializeComponent();
        myCollection.ItemsSource = Data.DataService.GetData();
    }

	private void Card1_Clicked(object sender, EventArgs e)
	{
        myCollection.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical);
        myCollection.ItemTemplate = (DataTemplate)Resources["Card1"];
    }

	private void Card2_Clicked(object sender, EventArgs e)
	{
        myCollection.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical);
        myCollection.ItemTemplate = (DataTemplate)Resources["Card2"];
    }
    
    private void Card3_Clicked(object sender, EventArgs e)
    {
        myCollection.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal);
        myCollection.ItemTemplate = (DataTemplate)Resources["Card3"];
    }
    
    private void Card4_Clicked(object sender, EventArgs e)
    {
        myCollection.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical);
        myCollection.ItemTemplate = (DataTemplate)Resources["Card4"];
    }

    private void Card5_Clicked(object sender, EventArgs e)
    {
        myCollection.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical);
        myCollection.ItemTemplate = (DataTemplate)Resources["Card5"];
    }
}