namespace AirportLostItemApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // MainPage = new AppShell(); // ESKİSİ BUYDU (Bunu sil veya yorum satırı yap)
        MainPage = new LoginPage();   // YENİSİ BU (Artık Login ile başlayacak)
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}