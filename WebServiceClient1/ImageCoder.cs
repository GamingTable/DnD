using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DnDServicePlayer
{
    class ImageCoder
    {
        //public static object WebOperationContext { get; private set; }

        // A vérifier
        static public Image BytesToImage(byte[] image)
        {
            MemoryStream oMemoryStream = new MemoryStream(image);

            Image oImage = Image.FromStream(oMemoryStream);

            return oImage;
        }

        //A vérifier
        static public byte[] ImageToBytes(Image image)
        {
            MemoryStream oMemoryStream = new MemoryStream();
            // ImageFormat could be other formats like bmp,gif,icon,png etc.

            image.Save(oMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            return oMemoryStream.ToArray();
        }

        static public BitmapSource BytesToSource(byte[] image)
        {
            BitmapImage bmpImage = new System.Windows.Media.Imaging.BitmapImage();
            bmpImage.BeginInit();
            bmpImage.StreamSource = new MemoryStream(image);
            bmpImage.EndInit();

            return bmpImage;

        }
    }
}
