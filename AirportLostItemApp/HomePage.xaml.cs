using System.Collections.ObjectModel;

namespace AirportLostItemApp;

public partial class HomePage : ContentPage
{
    // Ekranda görünecek liste
    public ObservableCollection<LostItem> VitrinItems { get; set; } = new ObservableCollection<LostItem>();

    public HomePage()
    {
        InitializeComponent();
        
        // Tasarımdaki listeyi buradaki veriye bağla
        VitrinList.ItemsSource = VitrinItems;

        // --- SAHTE VERİLER (Sanki doluymuş gibi görünsün) ---
        VitrinItems.Add(new LostItem { Icon="🧸", Name="Peluş Ayıcık", Location="Dış Hatlar Oyun Alanı", DateLost="Bugün 09:00", Priority="Normal" });
        VitrinItems.Add(new LostItem { Icon="💻", Name="MacBook Pro", Location="Starbucks Masa 4", DateLost="Dün 22:15", Priority="ACİL" });
        VitrinItems.Add(new LostItem { Icon="🛂", Name="Yeşil Pasaport", Location="Gümrük Kontrol", DateLost="Dün 14:00", Priority="ACİL" });
        VitrinItems.Add(new LostItem { Icon="🕶️", Name="RayBan Gözlük", Location="Tuvalet", DateLost="04.01.2026", Priority="Normal" });
    }

    // ARAMA YAPMA ÖZELLİĞİ
    private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        var arananKelime = e.NewTextValue.ToLower();
        
        if (string.IsNullOrWhiteSpace(arananKelime))
        {
            VitrinList.ItemsSource = VitrinItems; // Boşsa hepsini göster
        }
        else
        {
            // Filtreleme yap
            var filtrelenmisListe = VitrinItems.Where(item => item.Name.ToLower().Contains(arananKelime)).ToList();
            VitrinList.ItemsSource = filtrelenmisListe;
        }
    }
}