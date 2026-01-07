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

    // Sayfa her ekrana geldiğinde listeyi tazeler
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

    // YENİ: Sıralama Seçeneği Değiştiğinde Çalışır
    private void OnSortChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        if (picker?.SelectedItem == null) return;

        string selectedOption = picker.SelectedItem.ToString();
        List<LostItem> sortedList;

        // LINQ kullanarak sıralama mantığı
        switch (selectedOption)
        {
            case "A-Z (İsim)":
                sortedList = DisplayItems.OrderBy(x => x.Name).ToList();
                break;
            case "Aciliyet (Önce Acil olanlar)":
                // Status "ACİL" olanları başa çekiyoruz
                sortedList = DisplayItems.OrderByDescending(x => x.Status == "ACİL").ToList();
                break;
            case "En Eski (Önce)":
                // Liste zaten varsayılan akışta eskiden yeniye doğru olabilir
                sortedList = DisplayItems.ToList(); 
                break;
            case "En Yeni (Önce)":
            default:
                // Mevcut listeyi ters çevirerek en son ekleneni başa alırız
                sortedList = DisplayItems.Reverse().ToList();
                break;
        }

        // Ekranı güncellemek için koleksiyonu yenile
        DisplayItems.Clear();
        foreach (var item in sortedList)
        {
            DisplayItems.Add(item);
        }
    }

    // "BULDUM" BUTONU -> Yeni Form Sayfasına Gider
    private async void OnFoundItemClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var item = button.BindingContext as LostItem;

        if (item != null)
        {
            await Navigation.PushAsync(new FoundItemPage(item));
        }
    }

    // "DETAY GÖR" BUTONU -> Detay Sayfasına Gider
    private async void OnDetailsClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var item = button.BindingContext as LostItem;
    
        if (item != null)
        {
            await Navigation.PushAsync(new DetailPage(item));
        }
    }

    // KATEGORİ FİLTRELEME
    private void OnCategoryClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button == null) return;

        string categoryName = button.Text.Replace("💻 ", "").Replace("🧳 ", "").Replace("🛂 ", "").Trim();
        
        DisplayItems.Clear();

        if (categoryName == "Tümü")
        {
            foreach (var item in ItemService.Items) DisplayItems.Add(item);
        }
        else
        {
            foreach (var item in ItemService.Items)
            {
                if (item.Category == categoryName)
                {
                    DisplayItems.Add(item);
                }
            }
        }
    }
    
    // Listeden bir elemana tıklanınca
    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as LostItem;
        if (selectedItem == null) return;

        ((CollectionView)sender).SelectedItem = null;
        await Navigation.PushAsync(new DetailPage(selectedItem));
    }
}