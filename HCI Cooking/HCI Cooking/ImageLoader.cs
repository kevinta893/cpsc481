using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Media;
using System.Windows.Media.Imaging;

/*
 *  Static class used to load an image into a WPF container.
 */


namespace HCI_Cooking
{
    public static class ImageLoader
    {
        /*
         * function from NeoKenshinX
         * source: http://social.msdn.microsoft.com/Forums/en-US/a6f74675-77f2-4dac-a7d9-971c77b0b5bf/convert-systemdrawingimage-to-systemwindowscontrolsimage
         * 
         * Function creates a bitmap Image, loads the map with the bitmap
         * 
         */
        public static BitmapImage ToWPFImage(System.Drawing.Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Position = 0;
            BitmapImage bmpImg = new BitmapImage();
            bmpImg.BeginInit();
            bmpImg.CacheOption = BitmapCacheOption.OnLoad;
            bmpImg.StreamSource = ms;
            bmpImg.EndInit();


            return bmpImg;
        }
    }
}
