using System.Collections.ObjectModel;

namespace AirportLostItemApp;

public partial class MainPage : ContentPage
{
    // Eşyaları tutan dinamik liste (Database gibi düşün)
    public ObservableCollection<LostItem> Items { get; set; } = new ObservableCollection<LostItem>();

    public MainPage()
    {
        InitializeComponent();
        
        // Listeyi ekrandaki CollectionView ile bağla
        ItemsList.ItemsSource = Items;
    }

    // KAYDET BUTONUNA BASINCA BURASI ÇALIŞIR
    private void OnSaveClicked(object sender, EventArgs e)
    {
        // 1. Kutucuklar boş mu kontrol et
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            DisplayAlert("Hata", "Lütfen eşya adını girin!", "Tamam");
            return;
        }

        // 2. Yeni eşyayı oluştur
        var newItem = new LostItem
        {
            Id = Items.Count + 1,
            Name = NameEntry.Text,
            Description = DescEntry.Text,
            DateLost = DateEntry.Text,
            Location = LocEntry.Text,
            Priority = PriorityPicker.SelectedItem.ToString(),
            IsFound = false
        };

        // 3. Listeye ekle (Ekrana otomatik düşer)
        Items.Add(newItem);

        // 4. Yaratıcı Özellik: Eğer ACİL ise uyarı ver
        if (newItem.Priority == "ACİL")
        {
            DisplayAlert("⚠️ DİKKAT", "Bu kayıt ACİL olarak işaretlendi!", "Tamam");
        }

        // 5. Kutucukları temizle
        NameEntry.Text = string.Empty;
        DescEntry.Text = string.Empty;
        DateEntry.Text = string.Empty;
        LocEntry.Text = string.Empty;
        PriorityPicker.SelectedIndex = 0;
    }
}