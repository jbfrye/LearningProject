using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_5
{
    // 5.2

    class BinaryDecimal
    {
        public BinaryDecimal()
        { }

        public static String PrintBinary(double num)
        {
            if (num >= 1 || num <= 0)
                return "ERROR";

            StringBuilder binary = new StringBuilder();
            binary.Append(".");
            
            while (num > 0)
            {
                // Setting a limit on length: 32 characters
                if (binary.Length >= 32)
                    return "ERROR";

                double r = num * 2;
                if (r >= 1)
                {
                    binary.Append(1);
                    num = r - 1;
                }
                else
                {
                    binary.Append(0);
                    num = r;
                }
            }
            return binary.ToString();
        }

        public static void RunBinaryDecimal()
        {
            Console.WriteLine(PrintBinary(0.1));
        }
    }
}
