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
    public class SubclassWallpaper : SuperclassProductWallpaper
    {
        //private SuperclassImage imageTemp = null;
        //private SuperclassImage returnImage = null;
        public SubclassWallpaper(IImage frameP, ref SuperclassImage image)
        {
            frame = frameP;
            if (frame == null)
            {
                Console.WriteLine("null");
            }
            //image = new SubclassCanny(frame, "");
            image = new SubclassScretchedphoto(frame, "");
            image = new SubclassCanny(image, "");
            //imageTemp.GetImage();
            image = new SubclassCanny(image, "");
            Image<Gray, Byte> image1 = image.GetImage() as Image<Gray, Byte>;

            //Image<Rgb, Byte> image2 = new Image<Rgb, Byte>;
            //Image<Rgb, Byte> image3 = image.GetImage() as Image<Rgb, Byte>;
            //Image<Rgb, Byte> image4 = image.GetImage() as Image<Rgb, Byte>;
            //Image<Rgb, Byte> image5 = image.GetImage() as Image<Rgb, Byte>;
            Console.WriteLine("{0}", image1.Rows);
            Console.WriteLine("{0}", image1.Width);
            productImage = new Image<Bgr, Byte>(image1.Width * 2, image1.Height * 2);
            for (int i = 0; i < image1.Rows; i++)
            {
                for (int j = 0; j < image1.Cols; j++)
                {
                    if ((image1.Data[i, j, 0] == 0))
                    {
                        for (int z = 0; z < 3; z++)
                        {
                            productImage.Data[i, j, z] = 0;
                            productImage.Data[i + image1.Rows, j, z] = 0;
                            productImage.Data[i + image1.Rows, j + image1.Cols, z] = 0;
                            productImage.Data[i, j + image1.Cols, z] = 0;
                        }
                        productImage.Data[i, j, 0] = 0;
                        productImage.Data[i, j, 1] = 106;
                        productImage.Data[i, j, 2] = 237;

                        productImage.Data[i + image1.Rows, j, 0] = 170;
                        productImage.Data[i + image1.Rows, j, 1] = 187;
                        productImage.Data[i + image1.Rows, j, 2] = 0;

                        productImage.Data[i + image1.Rows, j + image1.Cols, 0] = 83;
                        productImage.Data[i + image1.Rows, j + image1.Cols, 1] = 242;
                        productImage.Data[i + image1.Rows, j + image1.Cols, 2] = 255;

                        productImage.Data[i, j + image1.Cols, 0] = 237;
                        productImage.Data[i, j + image1.Cols, 1] = 180;
                        productImage.Data[i, j + image1.Cols, 2] = 0;

                        //image1.Data[i, j, 0] = 255;
                        //image2.Data[i, j, 1] = 255;
                        //image3.Data[i, j, 2] = 255;
                    }
                    else
                    {
                        productImage.Data[i, j, 0] = 255;
                        productImage.Data[i, j, 1] = 255;
                        productImage.Data[i, j, 2] = 255;
                    }
                    //for (int z = 0; z < 1; z++)
                    //{
                    //    productImage.Data[i, j, z] = image1.Data[i, j, z];
                    //    productImage.Data[i + image5.Rows / 2, j, z] = image2.Data[i, j, z];
                    //    productImage.Data[i + image5.Rows / 2, j + image5.Cols / 2, z] = image3.Data[i, j, z];
                    //    productImage.Data[i, j + image5.Cols / 2, z] = image4.Data[i, j, z];
                    //}
                }
            }
            image = new SubclassScretchedphoto(productImage, "");
            //frame = schetchPhotoObject.GetImage();
            //Image schetchPhoto2 = new Image();
            //product.Source = image;
            product = new Image();
            product.Source = BitmapSourceConvert.ToBitmapSource(productImage);
            product.Width = 500;
            product.Height = 500;
            //schetchPhotoToSave = schetchPhoto2;
            //Date = DateP;
            //this.takePhoto();
        }
    }
}
