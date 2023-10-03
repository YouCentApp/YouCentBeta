namespace BlazorApp;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    private async void OnWebFluentButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AppPage));
    }
}

