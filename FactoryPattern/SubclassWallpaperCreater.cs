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

namespace FactoryPattern
{
    public class SubclassWallpaperCreater :SuperclassCreatorWallpaper
    {
        public SubclassWallpaperCreater(IImage frameP)
        {
            frame = frameP;
           // Date = DateP;
        }
        public override void designWallpaper()
        {
            WallpaperProduct = new SubclassWallpaper(frame, ref Wallpaper);
            //WallpaperProduct.
            //Wallpaper = new SubclassWallpaper(frame);
            //SuperclassImage wallPaper= new SubclassCanny(Wallpaper, "");
        }
    }
}
