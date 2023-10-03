namespace BlazorApp;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    private async void EnterPromiseLandClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AppPage));
    }
}

