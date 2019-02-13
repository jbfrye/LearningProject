using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_1
{
    // 1.5
    class StringCompression
    {
        public StringCompression()
        { }

        public static void RunStringCompression()
        {
            string str = "aabccccaaa";
            Console.WriteLine("Input String: " + str);

            string newStr = CompressString(str);
            Console.WriteLine("Output String: " + newStr);

            str = "abcdefg";
            Console.WriteLine("Input String: " + str);

            newStr = CompressString(str);
            Console.WriteLine("Output String: " + newStr);
        }

        public static string CompressString(string str)
        {
            // Check if the compressed string will actually be smaller
            int size = CountCompressedStr(str);
            if (size >= str.Length)
                return str;

            int dupCount = 0;
            char dupChar = '\0';
            StringBuilder newStr = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != dupChar)
                {
                    if (dupCount == 0)
                    {
                        dupCount = 1;
                        dupChar = str[i];
                    }
                    else
                    {
                        newStr.Append(dupChar);
                        newStr.Append(dupCount);
                        dupCount = 1;
                        dupChar = str[i];
                    }
                }
                else
                {
                    dupCount++;
                }
            }
            newStr.Append(dupChar);
            newStr.Append(dupCount);
            return newStr.ToString();
        }

        static int CountCompressedStr(string str)
        {
            int size = 0;
            char dupChar = '\0';

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != dupChar)
                {
                    if (i == 0)
                        dupChar = str[i];
                    else
                    {
                        size = size + 2;
                        dupChar = str[i];
                    }
                }
            }
            size = size + 2;
            return size;
        }
    }
}
