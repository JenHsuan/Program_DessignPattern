using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;
using Microsoft.Win32;

namespace AdapterPattern
{
    public abstract class SuperclassCreatorWallpaper
    {
        protected IImage frame = null;
        protected string Date = null;
        protected Image returnImage = null;
        protected SuperclassImage Wallpaper = null;
        protected SuperclassProductWallpaper WallpaperProduct = null;
        public IImage WallpaperImage = null;

        public Image CreateWallpaper()
        {
            //由product取得原始影像
            //WallpaperProduct = new SubclassWallpaper(frame);
            //Wallpaper = WallpaperProduct.takePhoto();
            designWallpaper();
            returnImage = new Image();
            returnImage.Source = BitmapSourceConvert.ToBitmapSource(Wallpaper.GetImage());
            return returnImage;
        }
        public abstract void designWallpaper();
    }
}
