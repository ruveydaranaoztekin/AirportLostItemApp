using System.Collections.ObjectModel;

namespace AirportLostItemApp;

public partial class HomePage : ContentPage
{
    // Ekranda Görünen Liste
    public ObservableCollection<LostItem> DisplayItems { get; set; } = new ObservableCollection<LostItem>();

    public HomePage()
    {
        InitializeComponent();
        
        // Bu sayfanın veri kaynağı kendisidir diyoruz
        BindingContext = this;
        
        // Listeyi ekrana bağlıyoruz
        LostItemsCollection.ItemsSource = DisplayItems;
    }

    // SİHİRLİ KISIM: Sayfa her ekrana geldiğinde burası çalışır
    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        // Listeyi temizle ve Ortak Depo'dan (ItemService) her şeyi yeniden çek
        DisplayItems.Clear();
        foreach (var item in ItemService.Items)
        {
            DisplayItems.Add(item);
        }
    }

    // 1. DETAY GÖR BUTONU
    private async void OnDetailsClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var item = button.BindingContext as LostItem;
        
        if (item != null)
        {
            await Navigation.PushAsync(new DetailPage(item));
        }
    }

    // 2. BULDUM BUTONU (Mesajsız, direkt geçiş)
    private async void OnFoundItemClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var item = button.BindingContext as LostItem;

        if (item != null)
        {
            await Navigation.PushAsync(new DetailPage(item));
        }
    }

    // 3. KATEGORİ FİLTRELEME
    private void OnCategoryClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button == null) return;

        string categoryName = button.Text.Replace("💻 ", "").Replace("🧳 ", "").Replace("🛂 ", "").Trim();
        
        // Ekranı temizle
        DisplayItems.Clear();

        if (categoryName == "Tümü")
        {
            // Ortak depodaki her şeyi geri yükle
            foreach (var item in ItemService.Items) DisplayItems.Add(item);
        }
        else
        {
            // Sadece kategorisi uyanları yükle
            foreach (var item in ItemService.Items)
            {
                // Kategori eşleşiyorsa ekle
                if (item.Category == categoryName)
                {
                    DisplayItems.Add(item);
                }
            }
        }
    }
    
    // Listeden bir elemana tıklanınca (Resmin üzerine vs.)
    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as LostItem;
        if (selectedItem == null) return;

        ((CollectionView)sender).SelectedItem = null; // Seçimi kaldır
        await Navigation.PushAsync(new DetailPage(selectedItem));
    }
}