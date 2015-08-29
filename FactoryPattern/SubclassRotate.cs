using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;


namespace FactoryPattern
{
    public class SubclassRotate : SuperclassImageProcessMethod
    {
        private SuperclassImage classImage;
        //private IImage _image;
        private IImage image;
        private int _degree;
        private string description = "Unkown image";

        public SubclassRotate(SuperclassImage Image, int degree, string Description)
            : base(Image, Description)
        {
            classImage = Image;
            //classImage.GetImage = Image.GetImage();
            //_image = Image.GetImage();
            _degree = degree;
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
                img = img.Rotate(_degree, new Bgr());
                return img;
            }
            else if (oldimage is Image<Gray, byte>)
            {
                Image<Gray, byte> img = oldimage as Image<Gray, byte>;
                img = img.Rotate(_degree, new Gray(255));
                return img;
            }
            else
            {
                return null;
            }
        }
    }
}
