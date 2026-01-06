using System.Collections.ObjectModel;

namespace AirportLostItemApp;

public partial class HomePage : ContentPage
{
    public ObservableCollection<LostItem> VitrinItems { get; set; } = new ObservableCollection<LostItem>();
    private List<LostItem> TumListe = new List<LostItem>();

    public HomePage()
    {
        InitializeComponent();
        VitrinList.ItemsSource = VitrinItems;

        // --- VERİLER ---
        TumListe.Add(new LostItem { Icon="🧸", Name="Peluş Ayıcık", Location="Dış Hatlar", DateLost="09:00", Priority="Normal", Category="Oyuncak" });
        TumListe.Add(new LostItem { Icon="💻", Name="MacBook Pro", Location="Starbucks", DateLost="Dün", Priority="ACİL", Category="Elektronik" });
        TumListe.Add(new LostItem { Icon="🛂", Name="Yeşil Pasaport", Location="Gümrük", DateLost="Dün", Priority="ACİL", Category="Pasaport" });
        TumListe.Add(new LostItem { Icon="🕶️", Name="RayBan Gözlük", Location="Tuvalet", DateLost="04.01", Priority="Normal", Category="Aksesuar" });
        TumListe.Add(new LostItem { Icon="🔑", Name="BMW Anahtarı", Location="Otopark", DateLost="05.01", Priority="ACİL", Category="Elektronik" });
        TumListe.Add(new LostItem { Icon="💊", Name="İlaç Çantası", Location="Eczane", DateLost="10:00", Priority="ACİL", Category="Sağlık" });
        TumListe.Add(new LostItem { Icon="🧢", Name="Mavi Şapka", Location="Giriş", DateLost="03.01", Priority="Normal", Category="Kıyafet" });

        ListeyiGuncelle(TumListe);
    }

    void ListeyiGuncelle(List<LostItem> veri)
    {
        VitrinItems.Clear();
        foreach (var item in veri) VitrinItems.Add(item);
    }

    // KATEGORİ FİLTRELEME
    private void OnCategoryClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        string secilen = button.CommandParameter.ToString();

        if (secilen == "Tümü") ListeyiGuncelle(TumListe);
        else ListeyiGuncelle(TumListe.Where(x => x.Category == secilen).ToList());
    }

    // ARAMA YAPMA
    private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        var kelime = e.NewTextValue?.ToLower() ?? "";
        var sonuc = TumListe.Where(item => item.Name.ToLower().Contains(kelime)).ToList();
        ListeyiGuncelle(sonuc);
    }

    // --- İŞTE BURASI: DETAYA GİTME KODU ---
    private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {
        // Eğer seçilen bir şey yoksa (null ise) işlem yapma
        if (e.CurrentSelection.FirstOrDefault() is not LostItem secilenEsya)
            return;

        // Detay Sayfasına git ve seçilen eşyayı da beraberinde götür
        await Navigation.PushAsync(new DetailPage(secilenEsya));

        // Listenin seçimini kaldır (ki tekrar tıklanabilsin)
        ((CollectionView)sender).SelectedItem = null;
    }
}