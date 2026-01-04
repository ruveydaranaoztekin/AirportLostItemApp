using System.Collections.ObjectModel;

namespace AirportLostItemApp;

public partial class MainPage : ContentPage
{
    public ObservableCollection<LostItem> Items { get; set; } = new ObservableCollection<LostItem>();

    public MainPage()
    {
        InitializeComponent();
        ItemsList.ItemsSource = Items;
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            DisplayAlert("Hata", "Lütfen eşya adını girin!", "Tamam");
            return;
        }

        var newItem = new LostItem
        {
            Id = Items.Count + 1,
            Name = NameEntry.Text,
            Description = DescEntry.Text,
            DateLost = DateEntry.Text,
            Location = LocEntry.Text,
            Priority = PriorityPicker.SelectedItem?.ToString() ?? "Normal",
            IsFound = false
        };

        Items.Add(newItem);

        if (newItem.Priority == "ACİL")
        {
            DisplayAlert("⚠️ DİKKAT", "Bu kayıt ACİL olarak işaretlendi!", "Tamam");
        }

        NameEntry.Text = string.Empty;
        DescEntry.Text = string.Empty;
        DateEntry.Text = string.Empty;
        LocEntry.Text = string.Empty;
        PriorityPicker.SelectedIndex = 0;
    }

    // YENİ: SİLME TUŞU
    private void OnDeleteClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var item = (LostItem)button.BindingContext;

        // Listeden sil
        Items.Remove(item);
    }

    // YENİ: BULUNDU TUŞU
    private void OnFoundClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var item = (LostItem)button.BindingContext;

        // Durumu güncelle
        item.IsFound = true;
        
        // Ekranda rengin değişmesi için küçük bir güncelleme hilesi
        int index = Items.IndexOf(item);
        Items[index] = item; 
        
        DisplayAlert("Harika!", $"{item.Name} bulundu olarak işaretlendi.", "Tamam");
    }
}