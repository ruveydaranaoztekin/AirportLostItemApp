namespace AirportLostItemApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        // BURASI BOŞ KALSIN. 
        // MainPage ataması yapmıyoruz çünkü aşağıda Window oluşturuyoruz.
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        // Uygulama direkt Menülü Yapı (AppShell) ile başlasın
        return new Window(new AppShell());
    }
}