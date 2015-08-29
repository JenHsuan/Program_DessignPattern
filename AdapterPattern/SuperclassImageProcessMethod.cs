using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.Structure;

namespace AdapterPattern
{
    public abstract class SuperclassImageProcessMethod : SuperclassImage
    {
        public abstract IImage ImageMethod(IImage oldimage);
       // private Image<Bgr, Byte> _image;
        private IImage image; 
        private IImage _image;
        private string description = "Unkown image";

        public SuperclassImageProcessMethod(SuperclassImage Image, string Description)
        {
            _image = Image.GetImage();
            image = Image.GetImage();
            description = Description;
        }

        public override IImage GetImage()
        {
            return image;
        }
        public override IImage GetRecoveryImage()
        {
            return _image;
        }
    }
}
