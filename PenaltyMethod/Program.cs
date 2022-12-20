using System;
using System.Linq;

namespace PenaltyMethod
{
    partial class Program
    {
        private static void Main(string[] args)
        {
            const double eps = 1e-5;
            
            var newPoint = new[] { 0.0, 0.0 };
            while (true)
            {
                var point = new double[2];
                newPoint.CopyTo(point, 0);

                var tmp = GradientMethod(point[0], point[1], eps);
                tmp.CopyTo(newPoint, 0);

                if (Math.Sqrt(
                        Math.Pow(newPoint[0] - point[0], 2) + 
                        Math.Pow(newPoint[1] - point[1], 2)
                        ) < 1e-3
                    )
                    break;

                R *= 10;
            }
            
            Console.WriteLine("Point: ({0:0.000}, {1:0.000})", newPoint[0], newPoint[1]);
            Console.WriteLine("Function: {0:0.000}", F(newPoint[0], newPoint[1]));
        }
    }
}