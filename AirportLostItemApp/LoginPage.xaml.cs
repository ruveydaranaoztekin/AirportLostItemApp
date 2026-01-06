namespace AirportLostItemApp;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void OnLoginClicked(object sender, EventArgs e)
    {
        // Giriş butonuna basınca Ana Uygulamaya (AppShell) geçiş yap
        Application.Current.MainPage = new AppShell();
    }
}