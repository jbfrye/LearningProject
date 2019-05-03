using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_7
{
    // 7.5
    class LineDivide
    {
        public LineDivide()
        { }

        public static void RunLineDivide()
        {

        }
    }

    public class Square
    {
        Point topLeft, topRight, botLeft, botRight;
        double left, right, top, bottom, size;

        public Square(Point tl, Point tr, Point bl, Point br, double s)
        {
            topLeft = tl;
            topRight = tr;
            botLeft = bl;
            botRight = br;
            left = topLeft.x;
            right = topRight.x;
            top = topLeft.y;
            bottom = botLeft.y;
            size = s;
        }

        public Point Middle()
        {
            return new Point((this.left + this.right) / 2.0,
                (this.top + this.bottom) / 2.0);
        }

        // Return the point where the line segment connecting mid1 and mid2
        // intercepts the edge of square 1. That is, draw a line from mid2 to
        // mid1, and continue it out until the edge o the square.
        public Point Extend(Point mid1, Point mid2, double size)
        {
            // Find what direction the line mid2 -> mid1 goes.
            double xdir = mid1.x < mid2.x ? -1 : 1;
            double ydir = mid1.y < mid2.y ? -1 : 1;

            // If mid1 and mid2 have the same x vlaue, then the slope calculation
            // will throw a divide by 0 exception. So, we compute this specially.
            if (mid1.x == mid2.x)
                return new Point(mid1.x, mid1.y + ydir * size / 2.0);

            double slope = (mid1.y - mid2.y) / (mid1.x - mid2.x);
            double x1 = 0;
            double y1 = 0;

            // Calculate slope using the equation (y1 - y2) / (x1 - x2).
            // Note: if the slpe is "steep" (>1) then the end of the line
            // segment will hit size / 2 units away from the middle on the
            // y zxis. If the slope is "shallow" (<1) the end of the line
            // segment will hit size / 2 units away from the middle on the
            // x axis.
            if (Math.Abs(slope) == 1)
            {
                x1 = mid1.x + xdir * size / 2.0;
                y1 = mid1.y + ydir * size / 2.0;
            }
            else if (Math.Abs(slope) > 1)
            {
                x1 = mid1.x + xdir * size / 2.0;
                y1 = slope * (x1 - mid1.x) + mid1.y;
            }
            else
            {
                y1 = mid1.y + ydir * size / 2.0;
                x1 = (y1 - mid1.y) / slope + mid1.x;
            }

            return new Point(x1, y1);
        }

        public Line2 Cut(Square other)
        {
            // Calculate where a line between each middle woudl collide with
            // the edges of the squares
            Point p1 = Extend(this.Middle(), other.Middle(), this.size);
            Point p2 = Extend(other.Middle(), other.Middle(), -1 * this.size);
            Point p3 = Extend(other.Middle(), this.Middle(), other.size);
            Point p4 = Extend(other.Middle(), this.Middle(), -1 * other.size);

            // Of above points, find start and end of lines. Start is farthest
            // left (with top most as a tie breaker) and end is farthest right
            // (with bottom most as a tie breaker.
            Point start = p1;
            Point end = p1;
            Point[] points = { p2, p3, p4 };
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i].x < start.x || (points[i].x == start.x && points[i].y < start.y))
                    start = points[i];
                else if (points[i].x > end.x || (points[i].x == end.x && points[i].y > end.y))
                    end = points[i];
            }

            return new Line2(start, end);
        }
    }

    public class Point
    {
        public double x, y;
        public Point(double a, double b)
        {
            x = a;
            y = b;
        }
    }

    public class Line2
    {
        public Point start, end;

        public Line2(Point s, Point e)
        {
            start = s;
            end = e;
        }
    }
}
