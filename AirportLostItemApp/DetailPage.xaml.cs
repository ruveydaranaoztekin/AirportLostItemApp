namespace AirportLostItemApp;

public partial class DetailPage : ContentPage
{
    private LostItem _item;

    public DetailPage(LostItem item)
    {
        InitializeComponent();
        _item = item;
        BindingContext = item;
    }

    // TESLİM ETME BUTONU
    private async void OnFoundClicked(object sender, EventArgs e)
    {
        // Boş kontrolü
        if (string.IsNullOrWhiteSpace(DeliveryLocationEntry.Text))
        {
            await DisplayAlert("Eksik Bilgi", "Lütfen teslim ettiğiniz yeri yazın.", "Tamam");
            return;
        }

        string yer = DeliveryLocationEntry.Text;
        await DisplayAlert("Teşekkürler!", $"'{_item.Name}' adlı eşyanın '{yer}' noktasına bırakıldığı kaydedildi.", "Süper");
        
        // Geri dön
        await Navigation.PopAsync();
    }

    // TALEP ETME BUTONU
    private async void OnClaimClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Talep Alındı", "Doğrulama için lütfen Güvenlik Noktasına gidiniz.", "Tamam");
    }
}