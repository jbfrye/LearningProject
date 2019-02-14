using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_1
{
    // 1.8
    class IsStringRotation
    {
        public IsStringRotation()
        { }

        public static void RunIsStringRotation()
        {
            string s1 = "waterbottle";
            string s2 = "erbottlewat";
            Console.WriteLine("Input Strings: s1 - " + s1 + ", s2 - " + s2);
            Console.WriteLine("Is Rotation: " + StringRotation(s1, s2));
        }

        public static bool StringRotation(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
            else
            {
                string s1s1 = s1 + s1;
                return s1s1.Contains(s2);
            }
        }
    }
}
