using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_7
{
    // 7.6
    class BestLine
    {
        public BestLine()
        { }

        public Line FindBestLine(Point[] points)
        {
            Line bestLine = null;
            int bestCount = 0;
            Dictionary<Double, ArrayList> linesBySlope = new Dictionary<double, ArrayList>();

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    Line line = new Line(points[i], points[j]);
                    InsertLine(linesBySlope, line);
                    int count = CountEquivalentLines(linesBySlope, line);
                    if (count > bestCount)
                    {
                        bestLine = line;
                        bestCount = count;
                    }
                }
            }
            return bestLine;
        }

        int CountEquivalentLines(ArrayList lines, Line line)
        {
            if (lines == null)
                return 0;
            int count = 0;
            foreach (Line parrallelLine in lines)
                if (parrallelLine.IsEquivalent(line))
                    count++;
            return count;
        }

        int CountEquivalentLines(Dictionary<Double, ArrayList> linesBySlope, Line line)
        {
            double key = Line.FloorToNearestEpsilon(line.slope);
            double eps = Line.epsilon;
            int count = 0;
            if (linesBySlope.ContainsKey(key))
                count += CountEquivalentLines(linesBySlope[key], line);
            if (linesBySlope.ContainsKey(key - eps))
                count += CountEquivalentLines(linesBySlope[key - eps], line);
            if (linesBySlope.ContainsKey(key + eps))
                count += CountEquivalentLines(linesBySlope[key + eps], line);

            return count;
        }

        void InsertLine(Dictionary<Double, ArrayList> linesBySlope, Line line)
        {
            ArrayList lines = null;
            double key = Line.FloorToNearestEpsilon(line.slope);
            if (!linesBySlope.ContainsKey(key))
            {
                lines = new ArrayList();
                linesBySlope[key] = lines;
            }
            else
                lines = linesBySlope[key];
            lines.Add(line);
        }

        public static void RunBestLine()
        {
            Point[] points = {new Point (0, 0), new Point(1, 4),
                new Point(5, 3), new Point(2, 9)};
            BestLine best = new BestLine();
            Line bestLine = best.FindBestLine(points);

            Console.WriteLine("Slope: " + bestLine.slope);
            Console.WriteLine("Y-Intercept: " + bestLine.yintercept);
        }
    }
}
