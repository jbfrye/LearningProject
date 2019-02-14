using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_1
{
    // 1.6
    class RotateMatrix
    {
        public RotateMatrix()
        { }

        public static void RunRotateMatrix()
        {
            int[,] matrix = new int[4, 4] { { 1, 2, 3, 4 }, { 1, 2, 3, 4 }, { 1, 2, 3, 4 }, { 1, 2, 3, 4 } };
            
            Console.WriteLine("Input: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            MatrixRotation(matrix);
            Console.WriteLine("Output: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void MatrixRotation(int[,] arr)
        {
            int N = arr.GetLength(0);
            for (int i = 0; i < N / 2; i++)
            {
                for (int j = i; j < N - i - 1; j++)
                {
                    int temp = arr[i, j];
                    arr[i, j] = arr[N - 1 - j, i];
                    arr[N - 1 - j, i] = arr[N - 1 - i, N - 1 - j];
                    arr[N - 1 - i, N - 1 - j] = arr[j, N - 1 - i];
                    arr[j, N - 1 - i] = temp;
                }
            }
        }
    }
}
