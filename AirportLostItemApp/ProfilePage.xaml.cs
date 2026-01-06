namespace AirportLostItemApp;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
    }

    private async void OnMyReportsClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Başvurularım", "Aktif olan 2 kayıp eşya ilanınız listeleniyor...", "Tamam");
    }

    private async void OnSupportClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Destek", "7/24 Çağrı Merkezi: 444 1 444\nCanlı destek bağlanıyor...", "Kapat");
    }

    private async void OnSettingsClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Ayarlar", "Bildirim ve dil ayarları sayfası.", "Tamam");
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        bool cevap = await DisplayAlert("Çıkış", "Hesabınızdan çıkış yapmak istiyor musunuz?", "Evet", "Hayır");
        if (cevap)
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}