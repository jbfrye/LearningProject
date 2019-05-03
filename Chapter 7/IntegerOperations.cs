using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_7
{
    //7.4

    class IntegerOperations
    {
        public IntegerOperations()
        { }

        public static int Negate(int a)
        {
            int neg = 0;
            int d = a < 0 ? 1 : -1;
            while (a != 0)
            {
                neg += d;
                a += d;
            }
            return neg;
        }

        public static int Abs(int a)
        {
            if (a < 0)
                return Negate(a);
            else
                return a;
        }

        public static int Subtract(int a, int b)
        {
            return a + Negate(b);
        }

        public static int Multiply(int a, int b)
        {
            // Algorithm is faster if b < a
            if (a < b)
                return Multiply(b, a);
            int sum = 0;
            for (int i = Abs(b); i > 0; i--)
            {
                sum += a;
            }
            if (b < 0)
                sum = Negate(sum);
            return sum;
        }

        public static int Divide(int a, int b)
        {
            if (b == 0)
                return -1;
            int absa = Abs(a);
            int absb = Abs(b);

            int product = 0;
            int x = 0;
            // Don't go past a
            while (product + absb <= absa)
            {
                product += absb;
                x++;
            }

            if ((a < 0 && b < 0) || (a > 0 && b > 0))
                return x;
            else
                return Negate(x);
        }

        public static void RunIntegerOperations()
        {
            int num1 = 15, num2 = 3;
            Console.WriteLine(Divide(num1, num2));
        }
    }
}
