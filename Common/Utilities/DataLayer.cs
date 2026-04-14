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
                new MapPin { X = 0.5, Y = 0.1, Category = "Stores", Name = "Apex Optics" },
                new MapPin { X = 0.55, Y = 0.15, Category = "Stores", Name = "Zara" },
                new MapPin { X = 0.57, Y = 0.1, Category = "Stores", Name = "H&M" },
                new MapPin { X = 0.61, Y = 0.1, Category = "Stores", Name = "Nike Store" },
                new MapPin { X = 0.2, Y = 0.1, Category = "Stores", Name = "Adidas" },
                new MapPin { X = 0.15, Y = 0.1, Category = "Stores", Name = "Puma" },
                new MapPin { X = 0.12, Y = 0.19, Category = "Stores", Name = "LC Waikiki" },
                new MapPin { X = 0.29, Y = 0.05, Category = "Stores", Name = "Defacto" },
                new MapPin { X = 0.1, Y = 0.3, Category = "Stores", Name = "Mavi Jeans" },
                new MapPin { X = 0.27, Y = 0.3, Category = "Stores", Name = "Levi’s" },
                new MapPin { X = 0.30, Y = 0.25, Category = "Stores", Name = "Pull & Bear" },
                new MapPin { X = 0.33, Y = 0.31, Category = "Stores", Name = "Boyner" },
                new MapPin { X = 0.37, Y = 0.26, Category = "Stores", Name = "Vakko" },
                new MapPin { X = 0.34, Y = 0.049, Category = "Stores", Name = "Teknosa" },
                new MapPin { X = 0.67, Y = 0.05, Category = "Stores", Name = "MediaMarkt" },
                new MapPin { X = 0.74, Y = 0.05, Category = "Stores", Name = "Apple Store" },
                new MapPin { X = 0.79, Y = 0.15, Category = "Stores", Name = "Samsung Store" },
                new MapPin { X = 0.72, Y = 0.147, Category = "Stores", Name = "Xiaomi Store" },
                new MapPin { X = 0.75, Y = 0.20, Category = "Stores", Name = "Watsons" },
                new MapPin { X = 0.83, Y = 0.21, Category = "Stores", Name = "Gratis" },
                new MapPin { X = 0.37, Y = 0.10, Category = "Stores", Name = "Rolex Boutique" },
                new MapPin { X = 0.40, Y = 0.157, Category = "Stores", Name = "Cartier" },
                new MapPin { X = 0.40, Y = 0.32, Category = "Stores", Name = "Koton" },

                new MapPin { X = 0.1, Y = 0.5, Category = "Stores", Name = "Colin’s" },
                new MapPin { X = 0.12, Y = 0.62, Category = "Stores", Name = "Decathlon" },
                new MapPin { X = 0.15, Y = 0.54, Category = "Stores", Name = "Toyzz Shop" },

                // Others
                new MapPin { X = 0.75, Y = 0.42, Category = "Leisure", Name = GetCinemaRoomByLanguage() },
                new MapPin { X = 0.8, Y = 0.5, Category = "Leisure", Name = GetGamingRoomByLanguage() },

                // DINING 
                new MapPin { X = 0.25, Y = 0.67, Category = "DiningRoom", Name = "Kebab spot" },
                new MapPin { X = 0.29, Y = 0.75, Category = "DiningRoom", Name = "Crunchy Chicken" },
                new MapPin { X = 0.33, Y = 0.67, Category = "DiningRoom", Name = "Starbucks" },
                new MapPin { X = 0.37, Y = 0.73, Category = "DiningRoom", Name = "Rusty Pub" },
                new MapPin { X = 0.48, Y = 0.7, Category = "DiningRoom", Name = "PizzaHot" },
                new MapPin { X = 0.51, Y = 0.77, Category = "DiningRoom", Name = "Popeyes" },
                new MapPin { X = 0.54, Y = 0.7, Category = "DiningRoom", Name = "KFC" },
                new MapPin { X = 0.59, Y = 0.7, Category = "DiningRoom", Name = "McDonalds" },
                new MapPin { X = 0.63, Y = 0.77, Category = "DiningRoom", Name = "Dennis Dines" },
                                 
                // RESTROOMS 
                new MapPin { X = 0.85, Y = 0.04, Category = "RestRoom", Name = GetRestRoomByLanguage() },
                new MapPin { X = 0.83, Y = 0.6, Category = "RestRoom", Name =  GetRestRoomByLanguage() },
                new MapPin { X = 0.75, Y = 0.8, Category = "RestRoom", Name = GetRestRoomByLanguage() },
                new MapPin { X = 0.21, Y = 0.35, Category = "RestRoom", Name = GetRestRoomByLanguage()  },
                new MapPin { X = 0.14, Y = 0.4, Category = "RestRoom", Name =  GetRestRoomByLanguage()  },
                new MapPin { X = 0.16, Y = 0.71, Category = "RestRoom", Name = GetRestRoomByLanguage() },

                // EXITS 
                new MapPin { X = 0.45, Y = 0.05, Category = "EmergencyExit", Name = GetExitRoomByLanguage() + " 1" },
                new MapPin { X = 0.21, Y = 0.68, Category = "EmergencyExit", Name = GetExitRoomByLanguage() + " 2" },
                new MapPin { X = 0.69, Y = 0.76, Category = "EmergencyExit", Name = GetExitRoomByLanguage() + " 3"}
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
