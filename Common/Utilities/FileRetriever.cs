using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallMapKiosk.Common.Utilities
{
    public sealed class FileRetriever
    {
        public static Func<string, string, string> GetFile = (string folder, string filename) =>
        {
             var mediaBase = AppDomain.CurrentDomain.BaseDirectory;
             var mediaPath = Path.Combine(mediaBase, folder, filename);

             return mediaPath; 
        };
    }
}
