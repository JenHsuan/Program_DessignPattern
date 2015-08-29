using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;

namespace AdapterPattern
{
    public class SubclassZoomOut : SuperclassImageProcessMethod
    {
        private SuperclassImage classImage;
        //private IImage _image;
        private IImage image;
        private double _size;
        private string description = "Unkown image";

        public SubclassZoomOut(SuperclassImage Image, double size, string Description)
            : base(Image, Description)
        {
            classImage = Image;
            //_image = Image;
            _size = size;
            image = ImageMethod(Image.GetImage());
            description = Description;
        }

        public override string GetDescription()
        {
            return classImage.GetDescription() + "," + description + "\n";
        }
        public override IImage GetImage()
        {
            return image;
        }
        public override IImage GetRecoveryImage()
        {
            return classImage.GetImage();
        }
        public override IImage ImageMethod(IImage oldimage)
        {
            if (oldimage is Image<Bgr, byte>)
            {
                Image<Bgr, byte> img = oldimage as Image<Bgr, byte>;
                img = img.Resize(_size, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
                return img;
            }
            else if (oldimage is Image<Gray, byte>)
            {
                Image<Gray, byte> img = oldimage as Image<Gray, byte>;
                img = img.Resize(_size, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
                return img;
            }
            else
            {
                return null;
            }
        }
    }
}
