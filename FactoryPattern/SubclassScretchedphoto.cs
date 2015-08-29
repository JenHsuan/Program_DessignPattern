using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FactoryPattern
{
    public class SubclassScretchedphoto : SuperclassImage
    {
        private IImage image;
        private IImage _image;
        private string description = "Unkown image";

        public SubclassScretchedphoto(IImage Image, string Description)
        {
            _image = Image;
            image = Image;
            description = Description;
        }
        public override string GetDescription()
        {
            return  description;
        }
        public override IImage GetImage()
        {
            return image;
        }
        public override IImage GetRecoveryImage()
        {
            return image;
        }
    }
}
