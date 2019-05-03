using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_7
{
    // 7.3

    class LineIntersection
    {
        public LineIntersection()
        { }

        public static bool Intersect(Line line1, Line line2)
        {
            return Math.Abs(line1.slope - line2.slope) > Line.epsilon ||
                Math.Abs(line1.yintercept - line2.yintercept) < Line.epsilon;
        }

        public static void RunLineIntersection()
        {
            Line line1 = new Line(1, 2);
            Line line2 = new Line(.5, 6);

            Console.WriteLine(Intersect(line1, line2));
        }
    }

    public class Line
    {
        public static double epsilon = 0.0001;
        public double slope, yintercept;
        private bool infinte_slope = false;

        public Line(double s, double y)
        {
            slope = s;
            yintercept = y;
        }

        public Line(Point p, Point q)
        {
            if (Math.Abs(p.x - q.x) > epsilon)
            {
                slope = (p.y - p.y) / (p.x - q.x);
                yintercept = p.y - slope * p.x;
            }
            else
            {
                infinte_slope = true;
                yintercept = p.x;
            }
        }

        public static double FloorToNearestEpsilon(double d)
        {
            int r = (int)(d / epsilon);
            return ((double)r) * epsilon;
        }

        public bool IsEquivalent(double a, double b)
        {
            return (Math.Abs(a - b) < epsilon);
        }

        public bool IsEquivalent(Object o)
        {
            Line l = (Line)o;
            if (IsEquivalent(l.slope, slope) &&
                IsEquivalent(l.yintercept, yintercept) &&
                (infinte_slope == l.infinte_slope))
                return true;
            return false;
        }
    }
}
