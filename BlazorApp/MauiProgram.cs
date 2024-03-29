﻿using Microsoft.Extensions.Logging;
using Microsoft.Fast.Components.FluentUI;
using PromiseLib.Weather;
using Microsoft.Fast.Components.FluentUI.Infrastructure;

namespace BlazorApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Nunito.ttf", "Nunito");
			});

		builder.Services.AddMauiBlazorWebView();

        builder.Services.AddFluentUIComponents(options =>
		{
            options.HostingModel = BlazorHostingModel.Hybrid;
        });

        builder.Services.AddSingleton<IStaticAssetService, FileBasedStaticAssetService>();

#if DEBUG
        builder.Logging.AddDebug();
		builder.Services.AddBlazorWebViewDeveloperTools();
		
#endif

		return builder.Build();
	}
}

