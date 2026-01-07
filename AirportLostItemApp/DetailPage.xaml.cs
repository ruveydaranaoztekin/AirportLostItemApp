namespace AirportLostItemApp;

public partial class DetailPage : ContentPage
{
    // Sayfaya gelen eşyayı hafızada tutmak için
    private LostItem _item;

    public DetailPage(LostItem item)
    {
        InitializeComponent();
        _item = item;
        BindingContext = _item; // Tasarıma veriyi gönderir
    }

    // Sadece "Bu Eşya Benim" butonu kaldı, onun kodu burada
    private async void OnClaimClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Talep Alındı", "Güvenlik birimi, eşya sahipliğini doğrulamak için sistemde kayıtlı numaranızdan size ulaşacaktır.", "Tamam");
    }
}