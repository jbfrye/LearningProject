using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_1
{
    // 1.7
    class ZeroMatrixSection
    {
        public ZeroMatrixSection()
        { }

        public static void RunZeroMatrixSection()
        {
            int[,] arr = new int[5, 4] { { 1, 2, 3, 4 }, { 1, 2, 3, 4 }, { 1, 2, 3, 4 }, { 1, 2, 3, 0 }, { 1, 2, 3, 4 } };
            Console.WriteLine("Input Matrix: ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            ZeroMatrix(arr);
            Console.WriteLine("Output Matrix: ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void ZeroMatrix(int[,] arr)
        {
            int M = arr.GetLength(0), N = arr.GetLength(1);
            bool[] rowZero = new bool[M];
            bool[] colZero = new bool[N];

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (arr[i, j] == 0)
                    {
                        rowZero[i] = true;
                        colZero[j] = true;
                    }
                }
            }

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (rowZero[i] || colZero[j])
                        arr[i, j] = 0;
                }
            }
        }
    }
}
