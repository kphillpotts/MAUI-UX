using Microsoft.Maui.Graphics;
using System.Drawing;

namespace MauiUX.Pages;

public partial class AnimationPage : ContentPage
{
	public AnimationPage()
	{
		InitializeComponent();
	}
    bool isExpanded = true;

    async void Handle_Tapped(object sender, System.EventArgs e)
    {
        //Flip(MainImage, MainImage);
        if (isExpanded)
            await AnimateIn();
        else
            await AnimateOut();

        isExpanded = !isExpanded;
    }

    Rect expandedRect;
    Rect detailsRect;
    private uint animationSpeed = 1000;

    private async Task AnimateIn()
    {
        //MainImage.LayoutTo(detailsRect, animationSpeed, Easing.SpringOut);
        MainImage.Layout(detailsRect);
        BottomFrame.TranslateTo(0, 0, animationSpeed, Easing.SpringOut);
        Title.TranslateTo(0, 0, animationSpeed, Easing.SpringOut);
        Title.Opacity = 1;
        await ExpandBar.FadeTo(.01, 250, Easing.SinInOut);
    }

    private async Task AnimateOut()
    {
        //MainImage.LayoutTo(expandedRect, animationSpeed, Easing.SpringOut);
        MainImage.Layout(expandedRect);
        BottomFrame.TranslateTo(0, BottomFrame.Height, animationSpeed, Easing.SpringOut);
        Title.TranslateTo(-Title.Width, 0, animationSpeed, Easing.SpringOut);
        Title.FadeTo(0, animationSpeed, Easing.Linear);
        await ExpandBar.FadeTo(1, 250, Easing.SinInOut);
    }

    private async Task Flip(VisualElement from, VisualElement to)
    {
        await from.RotateYTo(-90, animationSpeed, Easing.SpringIn);
        to.RotationY = 90;
        from.IsVisible = false;
        to.IsVisible = true;
        await to.RotateYTo(0, animationSpeed, Easing.SpringOut);
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        detailsRect = new Rect(0, 0, (int)width, (int)(BottomFrame.Bounds.Top + 20));
        expandedRect = new Rect(0, 0, (int)width, (int)height);
        //detailsRect = new Rect(0, 0, (int)100, (int)(100));
        //expandedRect = new Rect(0, 0, (int)200, (int)200);

        if (isExpanded)
        {
            MainImage.Layout(expandedRect);
            BottomFrame.TranslationY = BottomFrame.Height;
            Title.Opacity = 0;
            Title.TranslationX = -Title.Width;
        }
        else
        {
            MainImage.Layout(detailsRect);
            BottomFrame.TranslationY = 0;
            Title.TranslationX = 0;
        }
    }

}