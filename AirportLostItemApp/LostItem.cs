namespace AirportLostItemApp;

public class LostItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string DateLost { get; set; }
    public string Priority { get; set; }
    public bool IsFound { get; set; }
    public string Icon { get; set; } 
    
    // YENİ: Fotoğrafın telefondaki dosya yolu
    public string PhotoPath { get; set; } 
}