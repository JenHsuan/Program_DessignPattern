using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FactoryPattern
{
    public abstract class SuperclassImage
    {
        public abstract string GetDescription();
        public abstract IImage GetImage();
        public abstract IImage GetRecoveryImage();
    }
}
