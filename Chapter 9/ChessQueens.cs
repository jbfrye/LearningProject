using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_9
{
    // 9.9
    class ChessQueens
    {
        int GRID_SIZE = 8;

        public ChessQueens()
        { }

        public void PlaceQueens(int row, int[] columns, ArrayList results)
        {
            if (row == GRID_SIZE)
                results.Add(columns.Clone());
            else
            {
                for (int col = 0; col < GRID_SIZE; col++)
                {
                    if (CheckValid(columns, row, col))
                    {
                        columns[row] = col; // Place queen
                        PlaceQueens(row + 1, columns, results);
                    }
                }
            }
        }

        /* Check if (row1, column1) is a valid spot for a queen by checking if there is a
         * queen in the same column or diagonal. We don't need to check it for queens in the
         * same row because the calling PlaceQueen only attempts to place one queen at a time.
         * We know this row is empty. */
        bool CheckValid(int[] columns, int row1, int column1)
        {
            for (int row2 = 0; row2 < row1; row2++)
            {
                // Check if (row2, column2) invalidates (row1, column1) as a queen spot
                int column2 = columns[row2];

                // Check if rows have a queen in the same column
                if (column1 == column2)
                    return false;

                /* Check diagonals: if the distance between the columns equals the distance
                 * between the rows, then they're in the same diagonal. */
                int columnDistance = Math.Abs(column2 - column1);

                // row1 > row2, so no need for abs
                int rowDistance = row1 - row2;
                if (columnDistance == rowDistance)
                    return false;
            }
            return true;
        }

        public static void RunChessQueens()
        {
            ChessQueens queens = new ChessQueens();
            int[] columns = new int[8];
            ArrayList results = new ArrayList();
            queens.PlaceQueens(0, columns, results);

            Console.WriteLine(results.Count);
        }
    }
}
