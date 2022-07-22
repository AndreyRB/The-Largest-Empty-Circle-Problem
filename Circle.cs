using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG_kr_dz
{
    internal class Circle
    {
        public float X;
        public float Y;
        public double radius;
        public Circle()
        {
            X = 0;
            Y = 0;
            radius = 0;
        }
        public Circle(float X, float Y, double r)
        {
            this.X = X;
            this.Y = Y; 
            this.radius = r;
        }
    }
}
