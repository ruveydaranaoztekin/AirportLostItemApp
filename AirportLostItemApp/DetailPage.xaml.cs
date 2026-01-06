namespace AirportLostItemApp;

public partial class DetailPage : ContentPage
{
    private LostItem _item;

    // Sayfa açılırken veri (item) alacak şekilde ayarladık
    public DetailPage(LostItem item)
    {
        InitializeComponent();
        _item = item;
        
        // Ekrandaki {Binding ...} kodlarının bu 'item'dan veri çekmesini sağlar
        BindingContext = _item; 
    }

    // "TESLİM ETTİM" Butonuna Basılınca
    private async void OnFoundClicked(object sender, EventArgs e)
    {
        // Kutucuk boş mu kontrol et
        if (string.IsNullOrWhiteSpace(DeliveryLocationEntry.Text))
        {
            await DisplayAlert("Eksik Bilgi", "Lütfen eşyayı kime veya nereye teslim ettiğinizi yazın.", "Tamam");
            return;
        }

        // Kullanıcıya onay sor
        bool answer = await DisplayAlert("Onaylıyor musunuz?", 
            $"{_item.Name} adlı eşyayı '{DeliveryLocationEntry.Text}' konumuna bıraktığınızı onaylıyor musunuz?", 
            "Evet", "Hayır");
        
        if (answer)
        {
            // İŞLEM BAŞARILI
            await DisplayAlert("Teşekkürler! 👏", "Bildiriminiz kaydedildi. Eşya sahibi bilgilendirilecek.", "Tamam");
            
            // Ana sayfaya geri dön
            await Navigation.PopAsync();
        }
    }

    // "BU EŞYA BENİM" Linkine Basılınca
    private async void OnClaimClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Talep Alındı", "Güvenlik birimi, eşya sahipliğini doğrulamak için sistemde kayıtlı numaranızdan size ulaşacaktır.", "Tamam");
    }
}