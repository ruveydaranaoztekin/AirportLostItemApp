using System;

namespace AirportLostItemApp;


public class LostItem
{
    public int Id { get; set; }             
    public string Name { get; set; }        
    public string Description { get; set; } 
    public string DateLost { get; set; }    
    public string Location { get; set; }    
    public string Priority { get; set; }    
    public bool IsFound { get; set; }       
    
    
    public string StatusColor => IsFound ? "Green" : (Priority == "ACİL" ? "Red" : "Gray");
    public string StatusText => IsFound ? "BULUNDU" : "ARANIYOR";
}