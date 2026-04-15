using MallMapKiosk.Models;
using MallMapKiosk.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallMapKiosk.Common.Utilities
{
    public sealed class DataLayer
    {
        public static List<MapPin> allPins = new();
        private static AppLanguage _selectedLanguage;

        public static void InitPins(AppLanguage SelectedLanguage)
        {
            _selectedLanguage = SelectedLanguage;

            allPins = new List<MapPin>
            {
                // STORES
                new MapPin { Id=1, X=0.5, Y=0.1, Category="Stores", Name="Apex Optics", Label=GetStoreCategoryByLanguage("Eyewear"), Floor=GetFloorByLanguage("Floor 1 - A1"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=2, X=0.55, Y=0.15, Category="Stores", Name="Zara", Label=GetStoreCategoryByLanguage("Fashion / Clothing"), Floor=GetFloorByLanguage("Floor 2 - B1"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=3, X=0.57, Y=0.1, Category="Stores", Name="H&M", Label=GetStoreCategoryByLanguage("Fashion / Clothing"), Floor=GetFloorByLanguage("Floor 2 - B2"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=4, X=0.61, Y=0.1, Category="Stores", Name="Nike Store", Label=GetStoreCategoryByLanguage("Sportswear"), Floor=GetFloorByLanguage("Floor 2 - C1"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=5, X=0.2, Y=0.1, Category="Stores", Name="Adidas", Label=GetStoreCategoryByLanguage("Sportswear"), Floor=GetFloorByLanguage("Floor 2 - C2"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=6, X=0.15, Y=0.1, Category="Stores", Name="Puma", Label=GetStoreCategoryByLanguage("Sportswear"), Floor=GetFloorByLanguage("Floor 2 - C3"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=7, X=0.12, Y=0.19, Category="Stores", Name="LC Waikiki", Label=GetStoreCategoryByLanguage("Fashion / Clothing"), Floor=GetFloorByLanguage("Floor 2 - B3"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=8, X=0.29, Y=0.05, Category="Stores", Name="Defacto", Label=GetStoreCategoryByLanguage("Fashion / Clothing"), Floor=GetFloorByLanguage("Floor 2 - B4"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=9, X=0.1, Y=0.3, Category="Stores", Name="Mavi Jeans", Label=GetStoreCategoryByLanguage("Fashion / Clothing"), Floor=GetFloorByLanguage("Floor 2 - B5"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=10, X=0.27, Y=0.3, Category="Stores", Name="Levi’s", Label=GetStoreCategoryByLanguage("Fashion / Clothing"), Floor=GetFloorByLanguage("Floor 2 - B6"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=11, X=0.30, Y=0.25, Category="Stores", Name="Pull & Bear", Label=GetStoreCategoryByLanguage("Fashion / Clothing"), Floor=GetFloorByLanguage("Floor 2 - B7"), WorkHours="10:00 - 22:00" }, 
                new MapPin { Id=12, X=0.33, Y=0.31, Category="Stores", Name="Boyner", Label=GetStoreCategoryByLanguage("Fashion / Clothing"), Floor=GetFloorByLanguage("Floor 2 - D1"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=13, X=0.37, Y=0.26, Category="Stores", Name="Vakko", Label=GetStoreCategoryByLanguage("Fashion / Clothing"), Floor=GetFloorByLanguage("Floor 2 - L1"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=14, X=0.34, Y=0.049, Category="Stores", Name="Teknosa", Label=GetStoreCategoryByLanguage("Electronics"), Floor=GetFloorByLanguage("Floor 1 - E1"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=15, X=0.67, Y=0.05, Category="Stores", Name="MediaMarkt", Label=GetStoreCategoryByLanguage("Electronics"), Floor=GetFloorByLanguage("Floor 1 - E2"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=16, X=0.74, Y=0.05, Category="Stores", Name="Apple Store", Label=GetStoreCategoryByLanguage("Electronics"), Floor=GetFloorByLanguage("Floor 1 - E3"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=17, X=0.79, Y=0.15, Category="Stores", Name="Samsung Store", Label=GetStoreCategoryByLanguage("Electronics"), Floor=GetFloorByLanguage("Floor 1 - E4"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=18, X=0.72, Y=0.147, Category="Stores", Name="Xiaomi Store", Label=GetStoreCategoryByLanguage("Electronics"), Floor=GetFloorByLanguage("Floor 1 - E5"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=19, X=0.75, Y=0.20, Category="Stores", Name="Watsons", Label=GetStoreCategoryByLanguage("Health & Beauty"), Floor=GetFloorByLanguage("Floor 1 - H1"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=20, X=0.83, Y=0.21, Category="Stores", Name="Gratis", Label=GetStoreCategoryByLanguage("Health & Beauty"), Floor=GetFloorByLanguage("Floor 1 - H2"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=21, X=0.37, Y=0.10, Category="Stores", Name="Rolex Boutique", Label=GetStoreCategoryByLanguage("Luxury Watches"), Floor=GetFloorByLanguage("Floor 2 - L2"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=22, X=0.40, Y=0.157, Category="Stores", Name="Cartier", Label=GetStoreCategoryByLanguage("Fashion / Clothing"), Floor=GetFloorByLanguage("Floor 2 - L3"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=23, X=0.40, Y=0.32, Category="Stores", Name="Koton", Label=GetStoreCategoryByLanguage("Fashion / Clothing"), Floor=GetFloorByLanguage("Floor 2 - B8"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=24, X=0.1, Y=0.5, Category="Stores", Name="Colin’s", Label=GetStoreCategoryByLanguage("Fashion / Clothing"), Floor=GetFloorByLanguage("Floor 2 - B9"), WorkHours="10:00 - 22:00" },
                new MapPin { Id=25, X=0.12, Y=0.62, Category="Stores", Name="Decathlon", Label=GetStoreCategoryByLanguage("Sports Equipment"), Floor="Floor 1 - S1", WorkHours="10:00 - 22:00" },
                new MapPin { Id=26, X=0.15, Y=0.54, Category="Stores", Name="Toyzz Shop", Label=GetStoreCategoryByLanguage("Toys"), Floor=GetFloorByLanguage("Floor 1 - T1"), WorkHours="10:00 - 22:00" },

                // ENTERTAINMENT
                new MapPin { Id=50, X=0.75, Y=0.42, Category="Leisure", Name=GetCinemaRoomByLanguage(), Label=GetCinemaRoomByLanguage(), Floor=GetFloorByLanguage("Floor 3"), WorkHours="10:00 - 00:00" },
                new MapPin { Id=51, X=0.8, Y=0.5, Category="Leisure", Name=GetGamingRoomByLanguage(), Label=GetGamingRoomByLanguage(), Floor=GetFloorByLanguage("Floor 3"), WorkHours="10:00 - 23:00" },

                new MapPin { Id=70, X=0.25, Y=0.67, Category="DiningRoom", Name="Kebab Spot", Label=GetLabelByLanguage("Turkish Cuisine"), Floor=GetLabelByLanguage("Food Court"), WorkHours="10:00 - 23:00" },
                new MapPin { Id=71, X=0.29, Y=0.75, Category="DiningRoom", Name="Crunchy Chicken", Label=GetLabelByLanguage("Fast Food"), Floor=GetLabelByLanguage("Food Court"), WorkHours="10:00 - 23:00" },
                new MapPin { Id=72, X=0.33, Y=0.67, Category="DiningRoom", Name="Starbucks", Label=GetLabelByLanguage("Cafe"), Floor=GetLabelByLanguage("Food Court"), WorkHours="08:00 - 23:00" },
                new MapPin { Id=73, X=0.37, Y=0.73, Category="DiningRoom", Name="Rusty Pub", Label=GetLabelByLanguage("Restaurant"), Floor=GetLabelByLanguage("Food Court"), WorkHours="12:00 - 00:00" },
                new MapPin { Id=74, X=0.48, Y=0.7, Category="DiningRoom", Name="PizzaHot", Label=GetLabelByLanguage("Pizza"), Floor=GetLabelByLanguage("Food Court"), WorkHours="10:00 - 23:00" },
                new MapPin { Id=75, X=0.51, Y=0.77, Category="DiningRoom", Name="Popeyes", Label=GetLabelByLanguage("Fast Food"), Floor=GetLabelByLanguage("Food Court"), WorkHours="10:00 - 23:00" },
                new MapPin { Id=76, X=0.54, Y=0.7, Category="DiningRoom", Name="KFC", Label=GetLabelByLanguage("Fast Food"), Floor=GetLabelByLanguage("Food Court"), WorkHours="10:00 - 23:00" },
                new MapPin { Id=77, X=0.59, Y=0.7, Category="DiningRoom", Name="McDonalds", Label=GetLabelByLanguage("Fast Food"), Floor=GetLabelByLanguage("Food Court"), WorkHours="10:00 - 23:00" },
                new MapPin { Id=78, X=0.63, Y=0.77, Category="DiningRoom", Name="Dennis Dines", Label=GetLabelByLanguage("Restaurant"), Floor=GetLabelByLanguage("Food Court"), WorkHours="10:00 - 23:00" },

                // RESTROOMS
                new MapPin { Id=90, X=0.85, Y=0.04, Category="RestRoom", Name=GetRestRoomByLanguage(), Label=GetFacilityByLanguage(), Floor=$"{GetFacilityByLanguage()} 1", WorkHours="24/7" },
                new MapPin { Id=91, X=0.83, Y=0.6, Category="RestRoom", Name=GetRestRoomByLanguage(), Label=GetFacilityByLanguage(), Floor=$"{GetFacilityByLanguage()} 2", WorkHours="24/7" },
                new MapPin { Id=92, X=0.75, Y=0.8, Category="RestRoom", Name=GetRestRoomByLanguage(), Label=GetFacilityByLanguage(), Floor=$"{GetFacilityByLanguage()} 3", WorkHours="24/7" },
                new MapPin { Id=93, X=0.21, Y=0.35, Category="RestRoom", Name=GetRestRoomByLanguage(), Label=GetFacilityByLanguage(), Floor=$"{GetFacilityByLanguage()} 2", WorkHours="24/7" },
                new MapPin { Id=94, X=0.14, Y=0.4, Category="RestRoom", Name=GetRestRoomByLanguage(), Label=GetFacilityByLanguage(), Floor=$"{GetFacilityByLanguage()} 3", WorkHours="24/7" },

                // EXITS
                new MapPin { Id=100, X=0.45, Y=0.05, Category="EmergencyExit", Name=GetExitRoomByLanguage()+" 1", Label=GetExitRoomByLanguage(), Floor=GetFloorByLanguage("Ground Floor"), WorkHours=GetAlwaysOpenByLanguage() },
                new MapPin { Id=101, X=0.21, Y=0.68, Category="EmergencyExit", Name=GetExitRoomByLanguage()+" 2", Label=GetExitRoomByLanguage(), Floor=GetFloorByLanguage("Ground Floor"), WorkHours=GetAlwaysOpenByLanguage() },
                new MapPin { Id=102, X=0.69, Y=0.76, Category="EmergencyExit", Name=GetExitRoomByLanguage()+" 3", Label=GetExitRoomByLanguage(), Floor=GetFloorByLanguage("Ground Floor"), WorkHours=GetAlwaysOpenByLanguage() }
            };
        }


        #region translation helpers

        private static string GetLabelByLanguage(string label)
        {
            return _selectedLanguage switch
            {
                AppLanguage.EN => label,

                AppLanguage.TR => label switch
                {
                    "Turkish Cuisine" => "Türk Mutfağı",
                    "Fast Food" => "Fast Food",
                    "Cafe" => "Kafe",
                    "Restaurant" => "Restoran",
                    "Pizza" => "Pizza",
                    "Food Court" => "Yemek Alanı",
                    _ => label
                },

                AppLanguage.AR => label switch
                {
                    "Turkish Cuisine" => "المطبخ التركي",
                    "Fast Food" => "وجبات سريعة",
                    "Cafe" => "مقهى",
                    "Restaurant" => "مطعم",
                    "Pizza" => "بيتزا",
                    "Food Court" => "منطقة الطعام",
                    _ => label
                },

                _ => label
            };
        }

        private static string GetStoreCategoryByLanguage(string category)
        {
            return _selectedLanguage switch
            {
                AppLanguage.EN => category,

                AppLanguage.TR => category switch
                {
                    "Sportswear" => "Spor Giyim",
                    "Electronics" => "Elektronik",
                    "Fashion / Clothing" => "Moda / Giyim",
                    "Luxury Watches" => "Lüks Saatler",
                    "Sports Equipment" => "Spor Ekipmanları",
                    "Toys" => "Oyuncaklar",
                    "Eyewear" => "Gözlük",
                    "Food Court" => "Yemek Alanı",
                    "Health & Beauty" => "Sağlık & Güzellik",
                    _ => category
                },

                AppLanguage.AR => category switch
                {
                    "Sportswear" => "ملابس رياضية",
                    "Electronics" => "إلكترونيات",
                    "Fashion / Clothing" => "أزياء / ملابس",
                    "Luxury Watches" => "ساعات فاخرة",
                    "Sports Equipment" => "معدات رياضية",
                    "Toys" => "ألعاب",
                    "Eyewear" => "نظارات",
                    "Food Court" => "منطقة الطعام",
                    "Health & Beauty" => "الصحة والجمال",
                    _ => category
                },



                _ => category
            };
        }

        private static string GetFacilityByLanguage()
        {
            return _selectedLanguage switch
            {
                AppLanguage.EN => "Facility",
                AppLanguage.TR => "Tesis",
                AppLanguage.AR => "مرفق",
                _ => "Facility"
            };
        }

        private static string GetAlwaysOpenByLanguage()
        {
            return _selectedLanguage switch
            {
                AppLanguage.EN => "Always Open",
                AppLanguage.TR => "Her Zaman Açık",
                AppLanguage.AR => "مفتوح دائمًا",
                _ => "Always Open"
            };
        }

        private static string GetFloorByLanguage(string floor)
        {
            return _selectedLanguage switch
            {
                AppLanguage.EN => floor,
                AppLanguage.TR => floor
                    .Replace("Floor", "Kat")
                    .Replace("Ground Floor", "Zemin Kat"),
                AppLanguage.AR => floor
                    .Replace("Floor", "الطابق")
                    .Replace("Ground Floor", "الطابق الأرضي"),
                _ => floor
            };
        }

        private static string GetRestRoomByLanguage()
        {
            return _selectedLanguage switch
            {
                AppLanguage.EN => "Restroom",
                AppLanguage.TR => "Tuvalet",
                AppLanguage.AR => "دورة مياه",
                _ => "Store"
            };
        }

        private static string GetExitRoomByLanguage()
        {
            return _selectedLanguage switch
            {
                AppLanguage.EN => "Exit",
                AppLanguage.TR => "Çıkış",
                AppLanguage.AR => "مخرج",
                _ => "Exit"
            };
        }

        private static string GetGamingRoomByLanguage()
        {
            return _selectedLanguage switch
            {
                AppLanguage.EN => "Gaming & Arcade",
                AppLanguage.TR => "Oyun Alanı",
                AppLanguage.AR => "منطقة ألعاب",
                _ => "Gaming & Arcade"
            };
        }

        private static string GetCinemaRoomByLanguage()
        {
            return _selectedLanguage switch
            {
                AppLanguage.EN => "Cinema",
                AppLanguage.TR => "Sinema",
                AppLanguage.AR => "سينما",
                _ => "Cinema"
            };
        }

        #endregion
    }
}
