using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallMapKiosk.Models
{
    public class MapPin
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public string Category { get; set; }
        public string Name { get; set; }

        public string Label { get; set; }        
        public string Floor { get; set; }       
        public string WorkHours { get; set; }   
        public string Description { get; set; }        
    }
}
