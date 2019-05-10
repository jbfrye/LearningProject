using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_8
{
    // 8.8
    class Othello
    {
        OthelloBoard board;
        OthelloPlayer player1, player2;
        OthelloPlayer activePlayer;
        public OthelloPlayer ActivePlayer
        {
            get { return activePlayer; }
        }

        public Othello(string p1, string p2)
        {
            board = new OthelloBoard();
            player1 = new OthelloPlayer(p1, OthelloPiece.Side.Black);
            player2 = new OthelloPlayer(p2, OthelloPiece.Side.White);
            activePlayer = player1;
            Console.WriteLine("Welcome to Othello.");
            AskForInput();
        }

        private void DrawBoard()
        {
            Console.WriteLine("It is " + activePlayer.Name + "'s turn.");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board.GetPiece(i, j) != null)
                        Console.Write(board.GetPiece(i, j).Up + " ");
                    else
                        Console.Write("_____ ");
                }
                Console.WriteLine();
            }
        }

        public bool MakeMove(int x, int y)
        {
            if (x > 7 || y > 7 || x < 0 || y < 0)
                return false;
            if (board.PlacePiece(new OthelloPiece(activePlayer.Color), x, y))
            {
                if (activePlayer == player1)
                    activePlayer = player2;
                else
                    activePlayer = player1;
                AskForInput();
                Console.WriteLine();
                return true;
            }
            else
                return false;
        }

        private void AskForInput()
        {
            DrawBoard();
            bool again = true;
            while (again)
            {
                again = false;
                Console.Write("X: ");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.Write("Y: ");
                int y = Convert.ToInt32(Console.ReadLine());
                if (!MakeMove(x, y))
                {
                    Console.WriteLine("Invalid Input.");
                    again = true;
                }
            }
        }

        public static void RunOthello()
        {
            Othello game = new Othello("Jeremy", "John");
        }
    }

    class OthelloBoard
    {
        OthelloPiece[,] board;

        public OthelloBoard()
        {
            board = new OthelloPiece[8, 8];
        }

        public bool PlacePiece(OthelloPiece piece, int x, int y)
        {
            if (board[x, y] == null)
            {
                if (CheckForCaptures(piece, x, y))
                {
                    board[x, y] = piece;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool CheckForCaptures(OthelloPiece piece, int x, int y)
        {
            OthelloPiece.Side side = piece.Up, tempSide = piece.Up;
            int tempY = y-1;
            /*
            while (side == tempSide)
            {
                if (tempY >= 0)
                {
                    if (board[x, tempY].Up == side)
                    {

                    }
                    tempY--;
                }
                else
                    break;
            }
            */
            return true;
        }

        public OthelloPiece GetPiece(int x, int y)
        {
            return board[x, y];
        }
    }

    class OthelloPlayer
    {
        public string Name { get; }
        public OthelloPiece.Side Color { get; }

        public OthelloPlayer(string name, OthelloPiece.Side side)
        {
            Name = name;
            Color = side;
        }
    }

    class OthelloPiece
    {
        public enum Side { Black, White };

        public Side Up { get; set; }

        public OthelloPiece(Side u)
        {
            Up = u;
        }
    }
}
