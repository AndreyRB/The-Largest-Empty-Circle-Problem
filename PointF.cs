using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG_kr_dz
{
    public class PointF
    {
        public double X { get; set; }
        public double Y { get; set; }
        public PointF() { }
        public PointF(double x, double y)
        {
            X = x;
            Y = y;
        }
        public static PointF operator +(PointF a, PointF b)
        {
            return new PointF(a.X + b.X, a.Y + b.Y);
        }

        public static PointF operator -(PointF a, PointF b)
        {
            return new PointF(a.X - b.X, a.Y - b.Y);
        }

    }
}

