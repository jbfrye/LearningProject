using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_9
{
    // 9.2
    class Robot
    {
        Point[] blocked;

        public Robot(Point[] points)
        {
            blocked = points;
        }

        public bool GetPath(int x, int y, ArrayList path, Hashtable cache)
        {
            Point p = new Point(x, y);
            if (cache.ContainsKey(p)) // Already visited this cell
                return (bool)cache[p];
            if (x == 0 && y == 0) // Found a Path
                return true;

            bool success = false;
            if (x >= 1 && IsFree(x - 1, y))// Try right
                success = GetPath(x - 1, y, path, cache); // Free! Go right
            if (!success && y >= 1 && IsFree(x, y - 1)) // Try down
                success = GetPath(x, y - 1, path, cache); // Free! Go down
            if (success)
                path.Add(p); // Right way! Add to path
            cache.Add(p, success); // Cache result
            return success;
        }

        bool IsFree(int x, int y)
        {
            for (int i = 0; i < blocked.Length; i++)
            {
                if (blocked[i].X == x && blocked[i].Y == y)
                    return false;
            }
            return true;
        }

        public static void RunRobot()
        {
            Point[] blocked = new Point[] { new Point(3, 4), new Point(2, 2) };
            Robot robot = new Robot(blocked);
            ArrayList path = new ArrayList();
            Hashtable cache = new Hashtable();
            robot.GetPath(8, 8, path, cache);
        }
    }
}
