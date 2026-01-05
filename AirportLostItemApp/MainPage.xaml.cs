using System.Collections.ObjectModel;

namespace AirportLostItemApp;

public partial class MainPage : ContentPage
{
    public ObservableCollection<LostItem> Items { get; set; } = new ObservableCollection<LostItem>();
    
    // Geçici fotoğraf yolu
    private string _tempPhotoPath = null;

    public MainPage()
    {
        InitializeComponent();
        ItemsList.ItemsSource = Items;
    }

    // --- KAMERA BUTONU ---
    private async void OnTakePhotoClicked(object sender, EventArgs e)
    {
        try
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);
                await sourceStream.CopyToAsync(localFileStream);

                _tempPhotoPath = localFilePath;

                PreviewImage.Source = ImageSource.FromFile(localFilePath);
                PreviewImage.IsVisible = true;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", $"Kamera açılamadı: {ex.Message}", "Tamam");
        }
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            DisplayAlert("Hata", "Lütfen eşya adını girin!", "Tamam");
            return;
        }

        // GÖRSEL ZEKA
        string girilenIsim = NameEntry.Text.ToLower();
        string secilenSimge = "📦";
        if (girilenIsim.Contains("bavul") || girilenIsim.Contains("çanta")) secilenSimge = "🧳";
        else if (girilenIsim.Contains("telefon") || girilenIsim.Contains("iphone")) secilenSimge = "📱";
        else if (girilenIsim.Contains("laptop") || girilenIsim.Contains("bilgisayar")) secilenSimge = "💻";
        else if (girilenIsim.Contains("cüzdan")) secilenSimge = "👛";

        var newItem = new LostItem
        {
            Id = Items.Count + 1,
            Name = NameEntry.Text,
            Location = LocEntry.Text,
            DateLost = DateEntry.Date.ToString("dd/MM/yyyy"),
            Priority = PriorityPicker.SelectedItem?.ToString() ?? "Normal",
            IsFound = false,
            Icon = secilenSimge,
            PhotoPath = _tempPhotoPath
        };

        Items.Add(newItem);

        if (newItem.Priority == "ACİL")
            DisplayAlert("⚠️ DİKKAT", "Bu kayıt ACİL koduyla girildi!", "Tamam");

        // Temizlik
        NameEntry.Text = string.Empty;
        LocEntry.Text = string.Empty;
        PriorityPicker.SelectedIndex = -1;
        PreviewImage.IsVisible = false;
        _tempPhotoPath = null;
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var item = (LostItem)button.BindingContext;
        Items.Remove(item);
    }

    private async void OnFoundClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var item = (LostItem)button.BindingContext;
        await DisplayAlert("Tebrikler!", $"{item.Name} teslim edildi.", "Tamam");
        Items.Remove(item);
    }

    private async void OnClearAllClicked(object sender, EventArgs e)
    {
        bool cevap = await DisplayAlert("Dikkat", "Tüm liste silinecek.", "Evet, Sil", "Vazgeç");
        if (cevap) Items.Clear();
    }
}