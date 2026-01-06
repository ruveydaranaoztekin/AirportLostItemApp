namespace AirportLostItemApp;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    // 'async' kelimesini kaldırdık, çünkü await kullanmıyoruz.
    private void OnLoginClicked(object sender, EventArgs e)
    {
        // Butona basılınca direkt Ana Menüye (AppShell) geç
        Application.Current.MainPage = new AppShell();
    }
}