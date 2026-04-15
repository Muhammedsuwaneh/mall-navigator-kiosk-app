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
                new MapPin { Id=1, X=0.5, Y=0.1, Category="Stores", Name="Apex Optics", Label="Eyewear", Floor="Floor 1 - A1", WorkHours="10:00 - 22:00", Description="Premium optical store with glasses and sunglasses." },
                new MapPin { Id=2, X=0.55, Y=0.15, Category="Stores", Name="Zara", Label="Fashion / Clothing", Floor="Floor 2 - B1", WorkHours="10:00 - 22:00", Description="Trendy fashion for men, women and kids." },
                new MapPin { Id=3, X=0.57, Y=0.1, Category="Stores", Name="H&M", Label="Fashion / Clothing", Floor="Floor 2 - B2", WorkHours="10:00 - 22:00", Description="Affordable fashion and accessories." },
                new MapPin { Id=4, X=0.61, Y=0.1, Category="Stores", Name="Nike Store", Label="Sportswear", Floor="Floor 2 - C1", WorkHours="10:00 - 22:00", Description="Official Nike store for sportswear and sneakers." },
                new MapPin { Id=5, X=0.2, Y=0.1, Category="Stores", Name="Adidas", Label="Sportswear", Floor="Floor 2 - C2", WorkHours="10:00 - 22:00", Description="Sportswear, shoes and accessories." },
                new MapPin { Id=6, X=0.15, Y=0.1, Category="Stores", Name="Puma", Label="Sportswear", Floor="Floor 2 - C3", WorkHours="10:00 - 22:00", Description="Athletic apparel and footwear." },
                new MapPin { Id=7, X=0.12, Y=0.19, Category="Stores", Name="LC Waikiki", Label="Fashion / Clothing", Floor="Floor 2 - B3", WorkHours="10:00 - 22:00", Description="Affordable family fashion brand." },
                new MapPin { Id=8, X=0.29, Y=0.05, Category="Stores", Name="Defacto", Label="Fashion / Clothing", Floor="Floor 2 - B4", WorkHours="10:00 - 22:00", Description="Casual fashion for everyday wear." },
                new MapPin { Id=9, X=0.1, Y=0.3, Category="Stores", Name="Mavi Jeans", Label="Denim / Fashion", Floor="Floor 2 - B5", WorkHours="10:00 - 22:00", Description="Premium denim and casualwear." },
                new MapPin { Id=10, X=0.27, Y=0.3, Category="Stores", Name="Levi’s", Label="Denim / Fashion", Floor="Floor 2 - B6", WorkHours="10:00 - 22:00", Description="Iconic denim brand with timeless style." },
                new MapPin { Id=11, X=0.30, Y=0.25, Category="Stores", Name="Pull & Bear", Label="Fashion / Clothing", Floor="Floor 2 - B7", WorkHours="10:00 - 22:00", Description="Youth fashion and streetwear." },
                new MapPin { Id=12, X=0.33, Y=0.31, Category="Stores", Name="Boyner", Label="Department Store", Floor="Floor 2 - D1", WorkHours="10:00 - 22:00", Description="Multi-brand fashion and lifestyle store." },
                new MapPin { Id=13, X=0.37, Y=0.26, Category="Stores", Name="Vakko", Label="Luxury Fashion", Floor="Floor 2 - L1", WorkHours="10:00 - 22:00", Description="Luxury fashion and accessories." },
                new MapPin { Id=14, X=0.34, Y=0.049, Category="Stores", Name="Teknosa", Label="Electronics", Floor="Floor 1 - E1", WorkHours="10:00 - 22:00", Description="Electronics and tech products." },
                new MapPin { Id=15, X=0.67, Y=0.05, Category="Stores", Name="MediaMarkt", Label="Electronics", Floor="Floor 1 - E2", WorkHours="10:00 - 22:00", Description="Wide range of electronics and appliances." },
                new MapPin { Id=16, X=0.74, Y=0.05, Category="Stores", Name="Apple Store", Label="Electronics", Floor="Floor 1 - E3", WorkHours="10:00 - 22:00", Description="Apple products and services." },
                new MapPin { Id=17, X=0.79, Y=0.15, Category="Stores", Name="Samsung Store", Label="Electronics", Floor="Floor 1 - E4", WorkHours="10:00 - 22:00", Description="Samsung devices and accessories." },
                new MapPin { Id=18, X=0.72, Y=0.147, Category="Stores", Name="Xiaomi Store", Label="Electronics", Floor="Floor 1 - E5", WorkHours="10:00 - 22:00", Description="Smart devices and gadgets." },
                new MapPin { Id=19, X=0.75, Y=0.20, Category="Stores", Name="Watsons", Label="Health & Beauty", Floor="Floor 1 - H1", WorkHours="10:00 - 22:00", Description="Beauty and personal care products." },
                new MapPin { Id=20, X=0.83, Y=0.21, Category="Stores", Name="Gratis", Label="Health & Beauty", Floor="Floor 1 - H2", WorkHours="10:00 - 22:00", Description="Cosmetics and skincare." },
                new MapPin { Id=21, X=0.37, Y=0.10, Category="Stores", Name="Rolex Boutique", Label="Luxury Watches", Floor="Floor 2 - L2", WorkHours="10:00 - 22:00", Description="Luxury Swiss watches." },
                new MapPin { Id=22, X=0.40, Y=0.157, Category="Stores", Name="Cartier", Label="Luxury Jewelry", Floor="Floor 2 - L3", WorkHours="10:00 - 22:00", Description="Luxury jewelry and watches." },
                new MapPin { Id=23, X=0.40, Y=0.32, Category="Stores", Name="Koton", Label="Fashion / Clothing", Floor="Floor 2 - B8", WorkHours="10:00 - 22:00", Description="Casual and trendy fashion." },
                new MapPin { Id=24, X=0.1, Y=0.5, Category="Stores", Name="Colin’s", Label="Fashion / Clothing", Floor="Floor 2 - B9", WorkHours="10:00 - 22:00", Description="Denim and casualwear." },
                new MapPin { Id=25, X=0.12, Y=0.62, Category="Stores", Name="Decathlon", Label="Sports Equipment", Floor="Floor 1 - S1", WorkHours="10:00 - 22:00", Description="Sports gear and equipment." },
                new MapPin { Id=26, X=0.15, Y=0.54, Category="Stores", Name="Toyzz Shop", Label="Toys", Floor="Floor 1 - T1", WorkHours="10:00 - 22:00", Description="Toys and games for kids." },

                // ENTERTAINMENT
                new MapPin { Id=50, X=0.75, Y=0.42, Category="Leisure", Name=GetCinemaRoomByLanguage(), Label="Cinema", Floor="Floor 3", WorkHours="10:00 - 00:00", Description="Modern cinema with multiple screens." },
                new MapPin { Id=51, X=0.8, Y=0.5, Category="Leisure", Name=GetGamingRoomByLanguage(), Label="Gaming / Arcade", Floor="Floor 3", WorkHours="10:00 - 23:00", Description="Arcade games and VR experiences." },

                new MapPin { Id=70, X=0.25, Y=0.67, Category="DiningRoom", Name="Kebab Spot", Label="Turkish Cuisine", Floor="Food Court", WorkHours="10:00 - 23:00", Description="Traditional Turkish kebabs." },
                new MapPin { Id=71, X=0.29, Y=0.75, Category="DiningRoom", Name="Crunchy Chicken", Label="Fast Food", Floor="Food Court", WorkHours="10:00 - 23:00", Description="Fried chicken meals." },
                new MapPin { Id=72, X=0.33, Y=0.67, Category="DiningRoom", Name="Starbucks", Label="Cafe", Floor="Food Court", WorkHours="08:00 - 23:00", Description="Coffee and beverages." },
                new MapPin { Id=73, X=0.37, Y=0.73, Category="DiningRoom", Name="Rusty Pub", Label="Restaurant", Floor="Food Court", WorkHours="12:00 - 00:00", Description="Casual dining and drinks." },
                new MapPin { Id=74, X=0.48, Y=0.7, Category="DiningRoom", Name="PizzaHot", Label="Pizza", Floor="Food Court", WorkHours="10:00 - 23:00", Description="Fresh pizzas and sides." },
                new MapPin { Id=75, X=0.51, Y=0.77, Category="DiningRoom", Name="Popeyes", Label="Fast Food", Floor="Food Court", WorkHours="10:00 - 23:00", Description="Famous fried chicken." },
                new MapPin { Id=76, X=0.54, Y=0.7, Category="DiningRoom", Name="KFC", Label="Fast Food", Floor="Food Court", WorkHours="10:00 - 23:00", Description="Chicken meals and combos." },
                new MapPin { Id=77, X=0.59, Y=0.7, Category="DiningRoom", Name="McDonalds", Label="Fast Food", Floor="Food Court", WorkHours="10:00 - 23:00", Description="Burgers and fries." },
                new MapPin { Id=78, X=0.63, Y=0.77, Category="DiningRoom", Name="Dennis Dines", Label="Restaurant", Floor="Food Court", WorkHours="10:00 - 23:00", Description="Family dining restaurant." },

                // RESTROOMS
                new MapPin { Id=90, X=0.85, Y=0.04, Category="RestRoom", Name=GetRestRoomByLanguage(), Label="Facility", Floor="Floor 1", WorkHours="24/7", Description="Public restroom." },
                new MapPin { Id=91, X=0.83, Y=0.6, Category="RestRoom", Name=GetRestRoomByLanguage(), Label="Facility", Floor="Floor 2", WorkHours="24/7", Description="Public restroom." },
                new MapPin { Id=92, X=0.75, Y=0.8, Category="RestRoom", Name=GetRestRoomByLanguage(), Label="Facility", Floor="Floor 3", WorkHours="24/7", Description="Public restroom." },
                new MapPin { Id=93, X=0.21, Y=0.35, Category="RestRoom", Name=GetRestRoomByLanguage(), Label="Facility", Floor="Floor 2", WorkHours="24/7", Description="Public restroom." },
                new MapPin { Id=94, X=0.14, Y=0.4, Category="RestRoom", Name=GetRestRoomByLanguage(), Label="Facility", Floor="Floor 2", WorkHours="24/7", Description="Public restroom." },
                new MapPin { Id=95, X=0.16, Y=0.71, Category="RestRoom", Name=GetRestRoomByLanguage(), Label="Facility", Floor="Floor 1", WorkHours="24/7", Description="Public restroom." },

                // EXITS
                new MapPin { Id=100, X=0.45, Y=0.05, Category="EmergencyExit", Name=GetExitRoomByLanguage()+" 1", Label="Exit", Floor="Ground Floor", WorkHours="Always Open", Description="Emergency exit." },
                new MapPin { Id=101, X=0.21, Y=0.68, Category="EmergencyExit", Name=GetExitRoomByLanguage()+" 2", Label="Exit", Floor="Ground Floor", WorkHours="Always Open", Description="Emergency exit." },
                new MapPin { Id=102, X=0.69, Y=0.76, Category="EmergencyExit", Name=GetExitRoomByLanguage()+" 3", Label="Exit", Floor="Ground Floor", WorkHours="Always Open", Description="Emergency exit." }
            };
        }


        #region helpers

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
