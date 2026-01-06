using System.Collections.ObjectModel;

namespace AirportLostItemApp
{
    public static class ItemService
    {
        // Tüm uygulama bu listeyi kullanacak
        public static ObservableCollection<LostItem> Items { get; set; } = new ObservableCollection<LostItem>
        {
            // Başlangıç verileri burada dursun
            new LostItem { Name = "Peluş Ayıcık", Location = "Dış Hatlar", Date = "09:00", Status = "Normal", StatusColor = Colors.Orange, ImageUrl = "https://images.unsplash.com/photo-1559454403-b8fb88521f11?w=200", Category = "Diğer" },
            new LostItem { Name = "MacBook Pro", Location = "Starbucks", Date = "Dün", Status = "ACİL", StatusColor = Colors.Red, ImageUrl = "https://images.unsplash.com/photo-1517336714731-489689fd1ca4?w=200", Category = "Elektronik" },
            new LostItem { Name = "Yeşil Pasaport", Location = "Gümrük", Date = "Dün", Status = "ACİL", StatusColor = Colors.Red, ImageUrl = "https://images.unsplash.com/photo-1544084944-152696a63f72?w=200", Category = "Pasaport" },
        };
    }
}