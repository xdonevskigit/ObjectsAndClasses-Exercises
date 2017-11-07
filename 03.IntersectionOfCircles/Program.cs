using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.IntersectionOfCircles
{
   public class Program
    {
        static void Main(string[] args)
        {
            int[] firstCircleInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondCircleInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Point firstCenter = new Point(firstCircleInput[0], firstCircleInput[1]);
            Point secondCenter = new Point(secondCircleInput[0], secondCircleInput[1]);

            Circle firstCircle = new Circle(firstCenter, firstCircleInput[2]);
            Circle secondCircle = new Circle(secondCenter, secondCircleInput[2]);

            if (Circle.Intersect(firstCircle, secondCircle))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            
        }       
    }
    public class Circle
    {
        public Point Center { get; set; }
        public int Radius { get; set; }

        public Circle(Point center, int radius)
        {
            Center = center;
            Radius = radius;
        }
        public static bool Intersect(Circle c1, Circle c2)
        {
            int result = Point.CalculateDistance(c1.Center, c2.Center);
            if (result <= c1.Radius + c2.Radius)
            {
                return true;
            }
            return false;
        }
    }
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point (int x, int y)
        {
            X = x;
            Y = y;
        }
        public static int CalculateDistance(Point p1, Point p2)
        {
            return (int)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
    }
}
