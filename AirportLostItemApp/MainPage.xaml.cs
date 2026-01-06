namespace AirportLostItemApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // 1. Zorunlu alan kontrolü
        if (string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(LocationEntry.Text))
        {
            await DisplayAlert("Eksik Bilgi", "Lütfen en azından Eşya Adı ve Kaybolduğu Yeri giriniz.", "Tamam");
            return;
        }

        // 2. Yeni Eşya Nesnesini Oluştur (Tüm detaylarıyla)
        var newItem = new LostItem
        {
            Name = NameEntry.Text,
            Location = LocationEntry.Text,
            
            // Tarihi DatePicker'dan alıyoruz
            Date = DateInput.Date.ToString("dd.MM.yyyy"), 
            
            Category = CategoryPicker.SelectedItem?.ToString() ?? "Diğer",
            Status = RadioUrgent.IsChecked ? "ACİL" : "Normal",
            StatusColor = RadioUrgent.IsChecked ? Colors.Red : Colors.Orange,
            
            // Yeni Eklediğimiz Alanlar
            Description = DescriptionEditor.Text,
            NoteToFinder = NoteEntry.Text,

            // Fotoğraf şimdilik temsili (gerçek telefonda galeri izni gerekir, karmaşık olmasın diye bunu kullanıyoruz)
            ImageUrl = "https://images.unsplash.com/photo-1516961642265-531546e84af2?w=200" 
        };

        // 3. Ortak Depoya Ekle
        ItemService.Items.Insert(0, newItem);

        // 4. Formu Temizle
        NameEntry.Text = "";
        LocationEntry.Text = "";
        DescriptionEditor.Text = "";
        NoteEntry.Text = "";
        
        await DisplayAlert("Başarılı", "İlanınız detaylarıyla birlikte yayınlandı!", "Tamam");
        
        // Vitrin sayfasına (ilk tab) otomatik geçiş yapabiliriz istersen:
        // await Shell.Current.GoToAsync("//HomePage"); 
    }
}