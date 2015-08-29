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
    /// <summary>
    /// Window2.xaml 的互動邏輯
    /// </summary>
    public partial class Window2 : Window
    {
        private GeometryModel3D mGeometry;
		private bool mDown;
		private Point mLastPos;
        private Image product;
        //private Image3D image3D;
        private Capture cap;
        private SuperclassCreatorWallpaper wallPaper;
        private Image3D image3D;

        public Window2()
        {
            InitializeComponent();

            Image3DFacade Image3D = new Image3DFacade(wallPaper, image3D);
            mGeometry = Image3D.Create3DImage();
        
            group.Children.Add(mGeometry);
		}

        
		private void Grid_MouseWheel(object sender, MouseWheelEventArgs e) {
			camera.Position = new Point3D(camera.Position.X, camera.Position.Y, camera.Position.Z - e.Delta / 250D);
		}

		private void Button_Click(object sender, RoutedEventArgs e) {
			camera.Position = new Point3D(camera.Position.X, camera.Position.Y, 5);
			mGeometry.Transform = new Transform3DGroup();
		}

		private void Grid_MouseMove(object sender, MouseEventArgs e) {
			if(mDown) {
				Point pos = Mouse.GetPosition(viewport);
				Point actualPos = new Point(pos.X - viewport.ActualWidth / 2, viewport.ActualHeight / 2 - pos.Y);
				double dx = actualPos.X - mLastPos.X, dy = actualPos.Y - mLastPos.Y;

				double mouseAngle = 0;
				if(dx != 0 && dy != 0) {
					mouseAngle = Math.Asin(Math.Abs(dy) / Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)));
					if(dx < 0 && dy > 0) mouseAngle += Math.PI / 2;
					else if(dx < 0 && dy < 0) mouseAngle += Math.PI;
					else if(dx > 0 && dy < 0) mouseAngle += Math.PI * 1.5;
				}
				else if(dx == 0 && dy != 0) mouseAngle = Math.Sign(dy) > 0 ? Math.PI / 2 : Math.PI * 1.5;
				else if(dx != 0 && dy == 0) mouseAngle = Math.Sign(dx) > 0 ? 0 : Math.PI;

				double axisAngle = mouseAngle + Math.PI / 2;

				Vector3D axis = new Vector3D(Math.Cos(axisAngle) * 4, Math.Sin(axisAngle) * 4, 0);

				double rotation = 0.01 * Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

				Transform3DGroup group = mGeometry.Transform as Transform3DGroup;
				QuaternionRotation3D r = new QuaternionRotation3D(new Quaternion(axis, rotation * 180 / Math.PI));
				group.Children.Add(new RotateTransform3D(r));

				mLastPos = actualPos;
			}
		}

		private void Grid_MouseDown(object sender, MouseButtonEventArgs e) {
			if(e.LeftButton != MouseButtonState.Pressed) return;
			mDown = true;
			Point pos = Mouse.GetPosition(viewport);
			mLastPos = new Point(pos.X - viewport.ActualWidth / 2, viewport.ActualHeight / 2 - pos.Y);
		}

		private void Grid_MouseUp(object sender, MouseButtonEventArgs e) {
			mDown = false;
		}


    }
}
