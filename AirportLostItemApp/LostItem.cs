using Microsoft.Maui.Graphics;

namespace AirportLostItemApp
{
    public class LostItem
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Date { get; set; }
        public string? Status { get; set; }
        public Color? StatusColor { get; set; }
        public string? ImageUrl { get; set; }
        public string? Category { get; set; }
        
        // YENİ EKLENEN DETAYLAR
        public string? Description { get; set; } // "Yırtık mı, kırık mı?" detayları için
        public string? NoteToFinder { get; set; } // "Bulan kişiye not"
    }
}