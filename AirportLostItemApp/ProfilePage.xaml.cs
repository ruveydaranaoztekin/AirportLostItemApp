namespace AirportLostItemApp;

public partial class ProfilePage : ContentPage
{
    private bool isDarkMode = false;

    public ProfilePage()
    {
        InitializeComponent();
    }

    // 1. Bilgileri Düzenle Butonu
    private async void OnEditProfileClicked(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Düzenle", "Adınız Soyadınız nedir?");
        if (!string.IsNullOrWhiteSpace(result))
        {
            UserNameLabel.Text = result; // İsmi günceller
            await DisplayAlert("Başarılı", "Profil bilgileriniz güncellendi.", "Tamam");
        }
    }

    // 2. Gece Modu Butonu (Basit Simülasyon)
    private void OnDarkModeClicked(object sender, EventArgs e)
    {
        isDarkMode = !isDarkMode;
        if (isDarkMode)
        {
            this.BackgroundColor = Color.FromArgb("#121212"); // Koyu Gri
            DisplayAlert("Mod", "Gece modu açıldı 🌙", "Tamam");
        }
        else
        {
            this.BackgroundColor = Colors.White;
            DisplayAlert("Mod", "Gündüz modu açıldı ☀️", "Tamam");
        }
    }

    // 3. Hakkında Butonu
    private async void OnAboutClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Hakkında", "Havaalanı Kayıp Eşya Sistemi v1.0\nGeliştirici: [Senin Adın]", "Kapat");
    }

    // 4. Çıkış Yap Butonu
    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Çıkış", "Uygulamadan çıkmak istiyor musunuz?", "Evet", "Hayır");
        if (answer)
        {
            // Gerçek uygulamada Login sayfasına atar, şimdilik uyarı verelim
            await DisplayAlert("Güle Güle", "Çıkış yapılıyor...", "Tamam");
        }
    }
}