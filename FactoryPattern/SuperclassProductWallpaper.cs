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
    public abstract class SuperclassProductWallpaper
    {
        public IImage frame = null;
        //protected string Date = null;
       // public SuperclassImage image = null;
        public Image product = null;
        
        //public void takePhoto()
        //{
        //    image = new SubclassScretchedphoto(frame, "" );
        //}
    }
}
