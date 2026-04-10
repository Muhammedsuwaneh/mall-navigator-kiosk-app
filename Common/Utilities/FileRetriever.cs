using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallMapKiosk.Common.Utilities
{
    public class FileRetriever
    {
        public static Func<string, string, string> GetFile = (string fokder, string filename) =>
        {
             var mediaBase = AppDomain.CurrentDomain.BaseDirectory;
             var mediaPath = Path.Combine(mediaBase, filename);

             return mediaPath; 
        };
    }
}
