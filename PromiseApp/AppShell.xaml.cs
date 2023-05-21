namespace PromiseApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(WebTest), typeof(WebTest));
    }
}

