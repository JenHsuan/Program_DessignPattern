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
using System.Windows.Shapes;
using System.Windows.Media.Media3D;
using Emgu.CV;
using Emgu.CV.Structure;

namespace AdapterPattern
{
    public class Image3DFacade
    {
        private Capture cap;
        private GeometryModel3D mGeometry;
        private SuperclassCreatorWallpaper wallPaper; 
        private Image3D image3D;
        public Image3DFacade(SuperclassCreatorWallpaper wallPaperP, Image3D image3DP)
        {
            wallPaper = wallPaperP;
                image3D=image3DP;
        }
        public GeometryModel3D Create3DImage()
        {
            cap = new Capture(0);
            IImage frame = cap.QueryFrame();

            wallPaper = new SubclassWallpaperCreater(frame);
            wallPaper.designWallpaper();
            IImage pic = wallPaper.WallpaperImage;
            
            image3D = new Image3D();
            image3D.BuildSolid(pic, ref mGeometry);
            cap = null;
            return mGeometry;
        }
    }
}
