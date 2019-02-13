using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_1
{
    // 1.4
    class SpaceReplace
    {
        public SpaceReplace()
        { }

        public static void RunSpaceReplace()
        {
            string str = "Mr John Smith   ";
            Console.WriteLine("Input String: " + str);

            string newStr = ReplaceStrSpaces(str);
            Console.WriteLine("Output String: " + newStr);
        }

        public static string ReplaceStrSpaces(string str)
        {
            char[] arr = str.Trim().ToCharArray();
            int spaceCount = 0, newLength = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == ' ')
                    spaceCount++;
            }

            newLength = arr.Length + spaceCount * 2;
            char[] newStr = new char[newLength];

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == ' ')
                {
                    newStr[newLength - 1] = '0';
                    newStr[newLength - 2] = '2';
                    newStr[newLength - 3] = '%';
                    newLength = newLength - 3;
                }
                else
                {
                    newStr[newLength - 1] = arr[i];
                    newLength--;
                }
            }

            return new String(newStr);
        }
    }
}
