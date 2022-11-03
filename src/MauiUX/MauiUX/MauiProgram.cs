﻿using SkiaSharp.Views.Maui.Controls.Hosting;

namespace MauiUX;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSkiaSharp()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Alegreya-VariableFont_wght.ttf", "Alegreya");
				fonts.AddFont("SourceSansPro-Regular.ttf", "SourceSansPro");
			});

		return builder.Build();
	}
}
