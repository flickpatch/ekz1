using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GlazAlmaz.Actions
{
    public class ImageConvert
    {
        public static BitmapImage ImageConverter(byte[] array)
        {
            using (var i = new MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = i;
                image.EndInit();
                return image;
            }
        }
    }
}
