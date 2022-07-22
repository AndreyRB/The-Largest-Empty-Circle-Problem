using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace VG_kr_dz
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Bitmap background;
        Graphics g;
        public Form1()
        {
            InitializeComponent();

            pb.AutoSize = true;
            bitmap = new Bitmap(512, 512);

            background = new Bitmap(512, 512);
            Graphics g2 = Graphics.FromImage(background);
            g2.Clear(Color.White);
            g2 = null;

            g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Color.White);
            pb.Image = bitmap;
            this.AutoSize = true;
        }
        List<GraphEdge> ge;
        List<PointF> points = new List<PointF>();
        List<PointF> hull;
        Circle result;
        public int N;


        private void JarvisScan_Click(object sender, EventArgs e)
        {
            hull = Jarvis.GetSolution(points);

            for (int i = 0; i < points.Count; i++)
            {
                g.FillEllipse(Brushes.Blue, (float)points[i].X - 1.5f, (float)points[i].Y - 1.5f, 3, 3);
            }
            for (int i = 0; i < hull.Count-1; i++)
            {
                g.DrawLine(Pens.Red, (float)hull[i].X, (float)hull[i].Y, (float)hull[i+1].X, (float)hull[i+1].Y);
            }
            g.DrawLine(Pens.Red, (float)hull[0].X, (float)hull[0].Y, (float)hull[hull.Count-1].X, (float)hull[hull.Count - 1].Y);
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            double[] xVal = new double[points.Count], yVal = new double[points.Count];
            for (int i = 0; i < points.Count; i++)
            {           
                xVal[i] = points[i].X;
                yVal[i] = points[i].Y;
            }
            int width = bitmap.Width;
            int height = bitmap.Height;
            int minY = 1000, minX = 1000;
            for (int i = 0;i < points.Count; i++)
            {
                if(points[i].Y < minY) minY = (int)points[i].Y;
                if(points[i].X < minX) minX = (int)points[i].X;
            }
            Voronoi voroObject = new Voronoi(0.1);
            ge = voroObject.generateVoronoi(xVal, yVal, 0, width, 0, height);

           
            for (int i = 0; i < ge.Count; i++)
            {
                try
                {
                    PointF p1 = new PointF((float)ge[i].x1, (float)ge[i].y1); // Можно явно приводить к int, результат не изменит
                    PointF p2 = new PointF((float)ge[i].x2, (float)ge[i].y2);
                    g.DrawLine(Pens.Black, (float)p1.X, (float)p1.Y, (float)p2.X, (float)p2.Y);
                }
                catch
                {
                    string s = "\nP " + i + ": " + ge[i].x1 + ", " + ge[i].y1 + " || " + ge[i].x2 + ", " + ge[i].y2;
                    MessageBox.Show(s);
                }
            }
            pb.Image = bitmap;
        }

        private bool ComparePoints(PointF point1) // Чтобы не добавлять такую же точку
        {
            foreach (var p in points)
            {
                if (point1 == p) return false;
            }
            return true;
        }
        
        private bool FindPoint(List<PointF> hull, PointF point)
        {
            for (int i = 0; i < hull.Count; i++)
            {
                if (hull[i].X == point.X && hull[i].Y == point.Y) return true;
            }
            return false;
        }

        private void SolveTask_Click(object sender, EventArgs e)
        {
            FindLargestEmptyCircle();
            PointF bestPoint;
            double R = result.radius;
            bestPoint = new PointF(result.X, result.Y);
            g.FillEllipse(Brushes.Green, (float)(bestPoint.X) - 5f, (float)bestPoint.Y - 5f, 10, 10);
            for (double i = -R; i < R; i+=0.1)
            {
                double y = Math.Sqrt(Math.Pow(R, 2)- Math.Pow(i, 2));
                g.DrawEllipse(new Pen(Brushes.Green), (float)(bestPoint.X + i -1.5f), (float)(bestPoint.Y + y - 1.5f), 3, 3);
                g.DrawEllipse(new Pen(Brushes.Green), (float)(bestPoint.X + i - 1.5f), (float)(bestPoint.Y + -y - 1.5f), 3, 3);

            }
            
            pb.Image = bitmap;
        }
        public float Distance(PointF p1, PointF p2)
            => (float)Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));

        private void RandomPolygon_Click(object sender, EventArgs e)
        {
            ClearBox_Click(sender, e);
            if (int.TryParse(NtextBox.Text, out N))
            {
                Random random = new Random();
                float x, y;
                PointF point;
                for (int i = 0; i < N; i++)
                {
                    do {
                        x = (float)(random.NextDouble() * 512);
                        y = (float)(random.NextDouble() * 512);
                        point = new PointF(x, y);
                    } while (!ComparePoints(point));

                    points.Add(point);
                }
                JarvisScan_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Координаты должны быть типа int");
            }
        }

        public void FindLargestEmptyCircle()
        {
            List<Circle> circles = new List<Circle>();
            for (int i = 0; i < ge.Count; i++)
            {
                double x = ge[i].x1,
                    y = ge[i].y1;
                if (IsPointInPolygon(hull, new PointF(x, y))) 
                { 
                    double radius = 1000;
                    for (int j = 0; j < points.Count; j++)
                    {
                        double tmpRadius = Math.Sqrt(Math.Pow(points[j].X - x, 2) + Math.Pow(points[j].Y - y, 2));
                        if (tmpRadius < radius) radius = tmpRadius;
                    }
                    circles.Add(new Circle((float)x, (float)y, radius));
                }
            }
            
            int index = 0;
            double maxRadius = 0;
            for (int i = 0; i < circles.Count; i++)
            {
                if (circles[i].radius > maxRadius)
                {
                    index = i;
                    maxRadius = circles[i].radius;
                }
            }
            result = circles[index];
        }

        public static bool IsPointInPolygon(List<PointF>polygon, PointF testPoint)
        {
            bool result = false;
            int j = polygon.Count() - 1;
            for (int i = 0; i < polygon.Count(); i++)
            {
                if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
                {
                    if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
        //////////////
        private void ClearBox_Click(object sender, EventArgs e)
        {
            points.Clear();
            g.Clear(Color.White);
            
        }

    }
}
