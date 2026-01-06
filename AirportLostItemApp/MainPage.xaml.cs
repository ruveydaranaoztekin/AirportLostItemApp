namespace AirportLostItemApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    // Fotoğraf Ekleme Simülasyonu
    private async void OnPhotoClicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("Fotoğraf Ekle", "İptal", null, "Kamerayı Aç", "Galeriden Seç");
        if (action == "Kamerayı Aç" || action == "Galeriden Seç")
        {
            await DisplayAlert("Başarılı", "Fotoğraf dosyaya eklendi (Simülasyon)", "Tamam");
        }
    }

    // Kaydetme İşlemi
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // 1. Zorunlu Alan Kontrolü
        if (string.IsNullOrWhiteSpace(NameEntry.Text) || CategoryPicker.SelectedIndex == -1)
        {
            await DisplayAlert("Eksik Bilgi", "Lütfen en azından 'Eşya Adı' ve 'Kategori' alanlarını doldurun.", "Tamam");
            return;
        }

        // 2. Tüm Verileri Topla
        string isim = NameEntry.Text;
        string kategori = CategoryPicker.SelectedItem.ToString();
        string marka = BrandEntry.Text ?? "-"; // Boşsa tire koy
        
        string kayipYeri = LostLocationEntry.Text ?? "Bilinmiyor";
        string olasiYer = PossibleLocationEntry.Text ?? "-";
        string tarih = DateEntry.Date.ToString("dd.MM.yyyy");
        
        string not = UserNoteEditor.Text ?? "Not yok";

        // 3. Özet Mesaj Oluştur
        string ozet = $"📦 Eşya: {isim}\n" +
                      $"🏷️ Marka: {marka}\n" +
                      $"📍 Kayıp Yeri: {kayipYeri}\n" +
                      $"❓ Olası Yer: {olasiYer}\n" +
                      $"📅 Tarih: {tarih}\n" +
                      $"📝 Not: {not}";

        // 4. Onay Ver
        bool cevap = await DisplayAlert("Kaydı Onayla", ozet + "\n\nBilgiler doğru mu?", "Evet, Gönder", "Düzenle");

        if (cevap)
        {
            await DisplayAlert("İşlem Başarılı", "Kayıp bildiriminiz sisteme alındı. Eşleşme olduğunda size haber vereceğiz.", "Teşekkürler");
            
            // Sayfayı temizle
            Temizle();
        }
    }

    void Temizle()
    {
        NameEntry.Text = "";
        BrandEntry.Text = "";
        LostLocationEntry.Text = "";
        PossibleLocationEntry.Text = "";
        UserNoteEditor.Text = "";
        CategoryPicker.SelectedIndex = -1;
    }
}