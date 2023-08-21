﻿using Microsoft.Extensions.Logging;
using Microsoft.Fast.Components.FluentUI;
using PromiseLib.Weather;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.Fast.Components.FluentUI.Infrastructure;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;

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
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

        builder.Services.AddFluentUIComponents(options =>
        {
            options.HostingModel = BlazorHostingModel.WebAssembly;
            options.IconConfiguration = ConfigurationGenerator.GetIconConfiguration();
            options.EmojiConfiguration = ConfigurationGenerator.GetEmojiConfiguration();
        });

        builder.Services.AddFluentUIComponents(options =>
        {
            options.HostingModel = BlazorHostingModel.Hybrid;
        });
        builder.Services.AddSingleton<IStaticAssetService, FileBasedStaticAssetService>();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}

