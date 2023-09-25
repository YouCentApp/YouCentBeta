namespace BlazorApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(WebTest), typeof(WebTest));
		Routing.RegisterRoute(nameof(AppPage), typeof(AppPage));
    }
}

