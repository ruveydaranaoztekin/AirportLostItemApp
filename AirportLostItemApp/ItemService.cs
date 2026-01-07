using System.Collections.ObjectModel;

namespace AirportLostItemApp
{
    public static class ItemService
    {
        // Tüm uygulama bu listeyi kullanacak
        public static ObservableCollection<LostItem> Items { get; set; } = new ObservableCollection<LostItem>
        {
            // 1. İLAN
            new LostItem 
            { 
                Name = "Peluş Ayıcık", 
                Location = "Dış Hatlar Bekleme Salonu", 
                Date = "Bugün 09:00", 
                Status = "Normal", 
                StatusColor = Colors.Orange, 
                ImageUrl = "https://images.unsplash.com/photo-1559454403-b8fb88521f11?w=200", 
                Category = "Diğer",
                Description = "Kahverengi, yaklaşık 30cm boyunda, sol kulağında küçük bir sökük var. Üzerinde kırmızı bir papyon takılı.",
                NoteToFinder = "Oğlumun en sevdiği uyku arkadaşı, bulursanız lütfen danışmaya bırakın, çok üzgünüz."
            },

            // 2. İLAN
            new LostItem 
            { 
                Name = "MacBook Pro 14\"", 
                Location = "Starbucks (Gate A3 Yanı)", 
                Date = "Dün 14:30", 
                Status = "ACİL", 
                StatusColor = Colors.Red, 
                ImageUrl = "https://images.unsplash.com/photo-1517336714731-489689fd1ca4?w=200", 
                Category = "Elektronik",
                Description = "Uzay grisi, 14 inç, kapağında 'NASA' ve 'GitHub' çıkartmaları var. İngilizce klavye düzenine sahip.",
                NoteToFinder = "İçinde tezim ve yedeklenmemiş proje dosyalarım var. Bulan kişiye nakit ödül vereceğim!"
            },

            // 3. İLAN
            new LostItem 
            { 
                Name = "Yeşil Pasaport", 
                Location = "Pasaport Kontrol Noktası 5", 
                Date = "Dün 18:00", 
                Status = "ACİL", 
                StatusColor = Colors.Red, 
                ImageUrl = "https://images.unsplash.com/photo-1544084944-152696a63f72?w=200", 
                Category = "Pasaport",
                Description = "Yeşil hususi pasaport. Ahmet Yılmaz adına kayıtlı. Pasaport kılıfı siyah deri ve üzerinde baş harflerim (A.Y.) yazıyor.",
                NoteToFinder = "Uçağımı kaçırmak üzereyim, bulan kişi lütfen acilen anons ettirsin veya polise versin."
            },

            // 4. İLAN
            new LostItem 
            { 
                Name = "RayBan Güneş Gözlüğü", 
                Location = "Erkekler Tuvaleti (Terminal 1)", 
                Date = "04.01 12:15", 
                Status = "Normal", 
                StatusColor = Colors.Orange, 
                ImageUrl = "https://images.unsplash.com/photo-1572635196237-14b3f281503f?w=200", 
                Category = "Diğer",
                Description = "Siyah çerçeveli klasik Wayfarer model. Sağ camında ışığa tutunca belli olan çok ufak bir çizik var.",
                NoteToFinder = "Lavabonun kenarında ellerimi yıkarken unutmuşum."
            },

            // 5. İLAN
            new LostItem 
            { 
                Name = "Siyah Deri Cüzdan", 
                Location = "Duty Free Kasa", 
                Date = "Bugün 10:00", 
                Status = "ACİL", 
                StatusColor = Colors.Red, 
                ImageUrl = "https://images.unsplash.com/photo-1627123424574-724758594e93?w=200", 
                Category = "Cüzdan/Çanta",
                Description = "Markası Tommy Hilfiger. İçinde ehliyetim, kredi kartlarım ve bir miktar nakit para vardı.",
                NoteToFinder = "Parayı alabilirsiniz ama lütfen kimliklerimi güvenliğe teslim edin."
            },

            // 6. İLAN
            new LostItem 
            { 
                Name = "Samsung S24 Ultra", 
                Location = "Otopark P3 - Kırmızı Alan", 
                Date = "Dün 22:45", 
                Status = "ACİL", 
                StatusColor = Colors.Red, 
                ImageUrl = "https://images.unsplash.com/photo-1610945265078-3858a0b5d8f4?w=200", 
                Category = "Elektronik",
                Description = "Siyah renkli, şeffaf kılıf takılı. Kilit ekranında kedi fotoğrafı var.",
                NoteToFinder = "Şarjı bitmek üzereydi, kapanmış olabilir. Lütfen benimle iletişime geçin."
            },

            // 7. İLAN
            new LostItem 
            { 
                Name = "Kırmızı Kabin Valizi", 
                Location = "Bagaj Bandı 4", 
                Date = "05.01 08:30", 
                Status = "Normal", 
                StatusColor = Colors.Orange, 
                ImageUrl = "https://images.unsplash.com/photo-1565538810643-b5bdb714032a?w=200", 
                Category = "Bavul",
                Description = "Sert kapaklı, 4 tekerlekli. Tekerleklerinden biri hafif yalpalıyor. Sapına bağlı mavi bir kurdele var.",
                NoteToFinder = "Banttan almayı unuttum, kayıp eşya ofisine baktım ama yoktu."
            },

            // 8. İLAN
            new LostItem 
            { 
                Name = "Canon Fotoğraf Makinesi", 
                Location = "Banklar (Gate B12)", 
                Date = "Dün 16:20", 
                Status = "ACİL", 
                StatusColor = Colors.Red, 
                ImageUrl = "https://images.unsplash.com/photo-1516035069371-29a1b244cc32?w=200", 
                Category = "Elektronik",
                Description = "Canon EOS 250D model. Siyah askısı var. Lens kapağı takılı değildi.",
                NoteToFinder = "İçinde tatil fotoğraflarımın olduğu SD kart çok önemli."
            },

            // 9. İLAN
            new LostItem 
            { 
                Name = "Mavi Şemsiye", 
                Location = "Giriş Kapısı 2 (X-Ray)", 
                Date = "Bugün 07:45", 
                Status = "Normal", 
                StatusColor = Colors.Orange, 
                ImageUrl = "https://images.unsplash.com/photo-1535498730771-e735b998cd64?w=200", 
                Category = "Diğer",
                Description = "Büyük boy, baston tipi şemsiye. Sapı ahşap.",
                NoteToFinder = "Güvenlikten geçerken cihazın içinde unuttum."
            },

            // 10. İLAN
            new LostItem 
            { 
                Name = "Bebek Arabası", 
                Location = "Asansör Önü (Giden Yolcu)", 
                Date = "Dün 11:00", 
                Status = "ACİL", 
                StatusColor = Colors.Red, 
                ImageUrl = "https://images.unsplash.com/photo-1519689680058-324335c77eba?w=200", 
                Category = "Diğer",
                Description = "Chicco marka, gri renkli puset. Alt sepetinde bebek çantası asılıydı.",
                NoteToFinder = "Diğer bavullarla uğraşırken dalgınlığıma geldi."
            },

            // 11. İLAN
            new LostItem 
            { 
                Name = "AirPods Pro", 
                Location = "Mescit", 
                Date = "Bugün 13:20", 
                Status = "Normal", 
                StatusColor = Colors.Orange, 
                ImageUrl = "https://images.unsplash.com/photo-1603351154351-5cf13519a52d?w=200", 
                Category = "Elektronik",
                Description = "Beyaz şarj kutusuyla birlikte. Kutunun üzerinde 'Elif' yazıyor.",
                NoteToFinder = "Abdest alırken kenara koymuştum."
            },

            // 12. İLAN
            new LostItem 
            { 
                Name = "Kot Ceket", 
                Location = "Burger King", 
                Date = "Dün 19:50", 
                Status = "Normal", 
                StatusColor = Colors.Orange, 
                ImageUrl = "https://images.unsplash.com/photo-1576871337622-98d48d1cf531?w=200", 
                Category = "Giyim",
                Description = "Mavi renkli, M beden. Sırtında işlemeli bir kuş deseni var.",
                NoteToFinder = "Sandalyenin arkasına asmıştım."
            }
        };
    }
}