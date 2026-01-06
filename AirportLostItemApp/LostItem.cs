namespace AirportLostItemApp;

public class LostItem
{
    // Eşittir (=) işaretiyle varsayılan değerler atadık.
    // Artık sistem "boş kalırsa" diye hata vermeyecek.
    
    public string Icon { get; set; } = "❓";
    public string Name { get; set; } = "İsimsiz Eşya";
    public string Location { get; set; } = "Konum Yok";
    public string DateLost { get; set; } = "-";
    public string Priority { get; set; } = "Normal";
    public string Category { get; set; } = "Diğer";
}