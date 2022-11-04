namespace MauiUX.Pages;

public partial class ThemePage : ContentPage
{
	public ThemePage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // find out the current theme
        AppTheme currentTheme = Application.Current.RequestedTheme;
        this.Title = currentTheme.ToString();

        // respond to theme changes
        Application.Current.RequestedThemeChanged += Current_RequestedThemeChanged;
    }
    
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Application.Current.RequestedThemeChanged -= Current_RequestedThemeChanged;
    }

    private void Current_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
    {
        // find out the current theme
        this.Title = e.RequestedTheme.ToString();
    }

    private void LightThemeButton_Clicked(object sender, EventArgs e)
    {
        // set user specified light theme
        App.Current.UserAppTheme = AppTheme.Light;
    }

    private void DarkThemeButton_Clicked(object sender, EventArgs e)
    {
        App.Current.UserAppTheme = AppTheme.Dark;
    }
    
    private void SystemThemeButton_Clicked(object sender, EventArgs e)
    {
        // set theme to be system controlled
        App.Current.UserAppTheme = AppTheme.Unspecified;
    }
}