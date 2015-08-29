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
    public class Image3D
    {
        public void BuildSolid(IImage frame, ref GeometryModel3D mGeometry)
        {
            // Define 3D mesh object
            MeshGeometry3D mesh = new MeshGeometry3D();

            mesh.Positions.Add(new Point3D(-1, -1, -1));
            //mesh.Normals.Add(new Vector3D(0, 0, -1));
            mesh.Positions.Add(new Point3D(1, -1, -1));
            //mesh.Normals.Add(new Vector3D(0, 0, -1));
            mesh.Positions.Add(new Point3D(1, 1, -1));
            //mesh.Normals.Add(new Vector3D(0, 0, -1));
            mesh.Positions.Add(new Point3D(-1, 1, -1));
            //mesh.Normals.Add(new Vector3D(0, 0, -1));

            mesh.Positions.Add(new Point3D(-1, -1, 1));
            //mesh.Normals.Add(new Vector3D(0, 0, -1));
            mesh.Positions.Add(new Point3D(1, -1, 1));
            //mesh.Normals.Add(new Vector3D(0, 0, -1));
            mesh.Positions.Add(new Point3D(1, 1, 1));
            //mesh.Normals.Add(new Vector3D(0, 0, -1));
            mesh.Positions.Add(new Point3D(-1, 1, 1));

            // Front face
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(0);

            // Back face
            mesh.TriangleIndices.Add(6);
            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(7);
            mesh.TriangleIndices.Add(6);

            // Right face
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(6);
            mesh.TriangleIndices.Add(2);

            // Top face
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(6);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(6);
            mesh.TriangleIndices.Add(7);

            // Bottom face
            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(5);

            // Right face
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(7);
            mesh.TriangleIndices.Add(4);

            mesh.TextureCoordinates.Add(new Point(1, 1));
            mesh.TextureCoordinates.Add(new Point(-1, 1));
            mesh.TextureCoordinates.Add(new Point(-1, -1));
            mesh.TextureCoordinates.Add(new Point(1, -1));


            //schetchPhoto2.Source = BitmapSourceConvert.ToBitmapSource(frame);

            // ImageBrush imgBrush = new ImageBrush(new BitmapImage(new Uri("c:\\1.bmp")));
            //GeometryModel3D geometry = new GeometryModel3D(mesh, new DiffuseMaterial(new ImageBrush(schetchPhoto2.Source)));  // this line works without the TextureCoordinates
            //mGeometry = new GeometryModel3D(mesh, new DiffuseMaterial(imgBrush));
            mGeometry = new GeometryModel3D(mesh, new DiffuseMaterial(new ImageBrush(BitmapSourceConvert.ToBitmapSource(frame))));

            //mGeometry = new GeometryModel3D(mesh, new DiffuseMaterial(Brushes.YellowGreen));
            mGeometry.Transform = new Transform3DGroup();
        }

    }
}
