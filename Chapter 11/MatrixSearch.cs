using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_11
{
    // 11.6
    class MatrixSearch
    {
        public MatrixSearch()
        { }

        public static bool FindElement(int[,] matrix, int elem)
        {
            int row = 0, col = matrix.GetLength(1) - 1;
            while (row < matrix.GetLength(0) && col >= 0)
            {
                if (matrix[row,col] == elem)
                    return true;
                else if (matrix[row,col] > elem)
                    col--;
                else
                    row++;
            }
            return false;
        }
        public static void RunMatrixSearch()
        {
            int[,] matrix = new int[,] { { 15, 20, 40, 85 },
                                         { 20, 35, 80, 95 },
                                         { 30, 55, 95, 105 },
                                         { 40, 80, 100, 120 } };
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
            Console.Write("\n\n");
            Console.WriteLine(MatrixSearch.FindElement(matrix, 102));
        }
    }
}
