namespace AirportLostItemApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        // PÜF NOKTA: Buraya AppShell yerine LoginPage yazıyoruz.
        // Böylece uygulama direkt Login ekranıyla başlıyor.
        return new Window(new LoginPage());
    }
}