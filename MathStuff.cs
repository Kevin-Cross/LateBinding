using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    [SpecialClass(2)]
    public static class MathStuff
    {
        public static double CircleCircumference(double radius)
        {
            return radius*2*Math.PI;
        }
        public static double CircleArea(double radius)
        {
            return Math.Pow(radius, 2) * Math.PI;
        }
        public static double RightTriangleHypotenus(double a, double b)
        {
            return Math.Sqrt(Math.Pow(a, 2) * Math.Pow(b, 2));
        }

    }
}
