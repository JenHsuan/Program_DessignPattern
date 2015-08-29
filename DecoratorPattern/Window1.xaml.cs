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



namespace DecoratorPattern
{
    /// <summary>
    /// Window1.xaml 的互動邏輯
    /// </summary>
    public partial class Window1 : Window
    {
        private Capture cap = null;
        private Image schetchPhoto = null;
        private IImage frame = null;
        private bool photoFlag = true;
        private SuperclassImage schetchPhotoObject = null;
        private Canvas myCanvas;
        //private SuperclassImage schetchPhotoRotate = null;
        public Window1()
        {
            InitializeComponent();
            CAM.Header = "CAM";
        }
        public void Application_Idle(object sender, EventArgs e)
        {
            if (photoFlag == true)
            {
                frame = cap.QueryFrame(); // 去query該畫面

                schetchPhoto = new Image();
                myCanvas = new Canvas();
                schetchPhoto.Width = 500;
                schetchPhoto.Height = 500;
                schetchPhoto.Source = BitmapSourceConvert.ToBitmapSource(frame);
                Canvas.SetTop(schetchPhoto, 0);
                Canvas.SetLeft(schetchPhoto, 150);
                
                myCanvas.Children.Add(schetchPhoto);
                grid1.Children.Add(myCanvas);
            }
             //pictureBox1.Image = frame.ToBitmap(); // 把畫面轉換成bitmap型態，在餵給pictureBox元件
    
        }
        public static class BitmapSourceConvert
        {
            [DllImport("gdi32")]
            private static extern int DeleteObject(IntPtr o);

            public static BitmapSource ToBitmapSource(IImage image)
            {
                if (image != null)
                {
                    using (System.Drawing.Bitmap source = image.Bitmap)
                    {
                        IntPtr ptr = source.GetHbitmap();

                        BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                            ptr,
                            IntPtr.Zero,
                            Int32Rect.Empty,
                            System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

                        DeleteObject(ptr);
                        return bs;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public void DescriptionChange(SuperclassImage Image)
        {

            textBlock1.Text = Image.GetDescription();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cap = new Capture(0); // 連結到攝影機0，如果你有兩台攝影機，第二台就是1
            System.Windows.Interop.ComponentDispatcher.ThreadIdle += new EventHandler(Application_Idle); // 在Idle的event下，把畫面設定到
            
            
        }

        private void Photo_Click(object sender, RoutedEventArgs e)
        {
            string Date = DateTime.Now.ToString("MM/dd/yyyy");
            photoFlag = false;
            schetchPhotoObject = new SubclassScretchedphoto(frame, "The photo taken on" + Date);
            DescriptionChange(schetchPhotoObject);
        }

        private void Video_Click(object sender, RoutedEventArgs e)
        {
            photoFlag = true;
        }

        private void RotatePhoto_Click(object sender, RoutedEventArgs e)
        {
            if (schetchPhotoObject != null)
            {
                schetchPhotoObject = new SubclassRotate(schetchPhotoObject, 90, "rotate 1 time");
                DescriptionChange(schetchPhotoObject);
                frame = schetchPhotoObject.GetImage();
                Image schetchPhoto2 = new Image();
                schetchPhoto2.Source = BitmapSourceConvert.ToBitmapSource(frame);
                schetchPhoto2.Width = 500;
                schetchPhoto2.Height = 500;
                Canvas.SetTop(schetchPhoto2, 0);
                Canvas.SetLeft(schetchPhoto2, 150);
                Canvas myCanvas2 = new Canvas();
                myCanvas2.Children.Add(schetchPhoto2);
                grid1.Children.Add(myCanvas2);
            }
        }

        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if (schetchPhotoObject != null)
            {
                schetchPhotoObject = new SubclassZoomOut(schetchPhotoObject, 0.7, "fozzy 1 time");
                DescriptionChange(schetchPhotoObject);
                frame = schetchPhotoObject.GetImage();
                Image schetchPhoto2 = new Image();
                schetchPhoto2.Source = BitmapSourceConvert.ToBitmapSource(frame);
                schetchPhoto2.Width = 500;
                schetchPhoto2.Height = 500;
                Canvas.SetTop(schetchPhoto2, 0);
                Canvas.SetLeft(schetchPhoto2, 150);
                Canvas myCanvas2 = new Canvas();
                myCanvas2.Children.Add(schetchPhoto2);
                grid1.Children.Add(myCanvas2);
            }
        }

        private void Canny_Click(object sender, RoutedEventArgs e)
        {
            if (schetchPhotoObject != null)
            {
                schetchPhotoObject = new SubclassCanny(schetchPhotoObject, "canny 1 time");
                DescriptionChange(schetchPhotoObject);
                frame = schetchPhotoObject.GetImage();
                Image schetchPhoto2 = new Image();
                schetchPhoto2.Source = BitmapSourceConvert.ToBitmapSource(frame);
                schetchPhoto2.Width = 500;
                schetchPhoto2.Height = 500;
                Canvas.SetTop(schetchPhoto2, 0);
                Canvas.SetLeft(schetchPhoto2, 150);
                Canvas myCanvas2 = new Canvas();
                myCanvas2.Children.Add(schetchPhoto2);
                grid1.Children.Add(myCanvas2);
            }
        }

        private void GrayValue_Click(object sender, RoutedEventArgs e)
        {
            if (schetchPhotoObject != null)
            {
                schetchPhotoObject = new SubclassGrayvalue(schetchPhotoObject, "alter to gray value 1 time");
                DescriptionChange(schetchPhotoObject); 
                frame = schetchPhotoObject.GetImage();
                Image schetchPhoto2 = new Image();
                schetchPhoto2.Source = BitmapSourceConvert.ToBitmapSource(frame);
                schetchPhoto2.Width = 500;
                schetchPhoto2.Height = 500;
                Canvas.SetTop(schetchPhoto2, 0);
                Canvas.SetLeft(schetchPhoto2, 150);
                Canvas myCanvas2 = new Canvas();
                myCanvas2.Children.Add(schetchPhoto2);
                grid1.Children.Add(myCanvas2);
            }
        }

        
    }
}
