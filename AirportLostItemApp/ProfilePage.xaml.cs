namespace AirportLostItemApp;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Çıkış", "Uygulamadan çıkış yapmak istediğinize emin misiniz?", "Evet", "Hayır");
        if (answer)
        {
            // Login sayfasına geri yönlendir (Uygulama yapına göre değiştirilebilir)
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}