namespace AirportLostItemApp;

public partial class FoundItemPage : ContentPage
{
    private LostItem _item;

    public FoundItemPage(LostItem item)
    {
        InitializeComponent();
        _item = item;
        BindingContext = _item; // Eşya bilgilerini (Resim, İsim) ekrana bağla
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        // Basit bir kontrol
        if (string.IsNullOrWhiteSpace(FoundLocationEntry.Text) || string.IsNullOrWhiteSpace(DeliveredLocationEntry.Text))
        {
            await DisplayAlert("Eksik Bilgi", "Lütfen nerede bulduğunuzu ve nereye teslim ettiğinizi yazın.", "Tamam");
            return;
        }

        // Başarılı Mesajı
        await DisplayAlert("Teşekkürler! 👏", 
            $"{_item.Name} eşyası için bildiriminiz alındı.\n\n" +
            $"Teslim Yeri: {DeliveredLocationEntry.Text}\n" +
            $"Durum: {ConditionPicker.SelectedItem ?? "Belirtilmedi"}", 
            "Tamam");

        // Ana sayfaya dön
        await Navigation.PopAsync();
    }
}