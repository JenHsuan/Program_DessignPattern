using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FactoryPattern
{
    public class SubclassGrayvalue: SuperclassImageProcessMethod
    {
        private SuperclassImage classImage;
        //private IImage _image;
        private IImage image;
        private string description = "Unkown image";

        public SubclassGrayvalue(SuperclassImage Image, string Description)
            : base(Image, Description)
        {
            classImage = Image;
           // _image = Image.GetImage();
            image = ImageMethod(Image.GetImage());
            description = Description;
        }
        public override string GetDescription()
        {
            return classImage.GetDescription() + "," + description+"\n";
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
                Image<Gray, Byte> grayImage = img.Convert<Gray, Byte>();
                Image<Gray, Byte> gray1 = grayImage.ThresholdToZero(new Gray(45));

                return gray1;
            }
            else if (oldimage is Image<Gray, byte>)
            {
                Image<Gray, byte> img = oldimage as Image<Gray, byte>;
                Image<Gray, Byte> gray1 = img.ThresholdToZero(new Gray(45));
                return gray1;
            }
            else
            {
                return null;
            }
        }
    }
}
