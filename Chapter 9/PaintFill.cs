using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_9
{
    // 9.7
    class PaintFill
    {
        Color[,] screen;
        int xlength, ylength;

        public PaintFill(int x, int y)
        {
            screen = new Color[x, y];
            xlength = x;
            ylength = y;
            RandomPaintScreen();
            PaintScreen();
        }

        void RandomPaintScreen()
        {
            Random random = new Random();
            for (int i = 0; i < xlength; i++)
            {
                for (int j = 0; j < ylength; j++)
                {
                    int color = random.Next(0, 7);

                    switch (color)
                    {
                        case 0:
                            screen[i, j] = Color.Red;
                            break;
                        case 1:
                            screen[i, j] = Color.Blue;
                            break;
                        case 2:
                            screen[i, j] = Color.Green;
                            break;
                        case 3:
                            screen[i, j] = Color.Black;
                            break;
                        case 4:
                            screen[i, j] = Color.White;
                            break;
                        case 5:
                            screen[i, j] = Color.Yellow;
                            break;
                        case 6:
                            screen[i, j] = Color.Purple;
                            break;
                    }
                }
            }
        }

        public void PaintScreen()
        {
            for (int i = 0; i < xlength; i++)
            {
                for (int j = 0; j < ylength; j++)
                {
                    if (screen[i, j] == Color.Red)
                        Console.Write("Red   ");
                    else if (screen[i, j] == Color.Blue)
                        Console.Write("Blue  ");
                    else if (screen[i, j] == Color.Green)
                        Console.Write("Green ");
                    else if (screen[i, j] == Color.Black)
                        Console.Write("Black ");
                    else if (screen[i, j] == Color.White)
                        Console.Write("White ");
                    else if (screen[i, j] == Color.Yellow)
                        Console.Write("Yella ");
                    else if (screen[i, j] == Color.Purple)
                        Console.Write("Purp  ");
                }
                Console.WriteLine();
            }
        }

        public void FillHelper(int x, int y, Color oldColor, Color newColor)
        {
            // Don't do anything if the colors don't match
            if (x < 0 || x >= xlength || y < 0 || y >= ylength)
                return;
            if (screen[y, x] != oldColor)
                return;
            else
                screen[y, x] = newColor;
            FillHelper(x - 1, y, oldColor, newColor); // Check left
            FillHelper(x + 1, y, oldColor, newColor); // Check right
            FillHelper(x, y - 1, oldColor, newColor); // Check down
            FillHelper(x, y + 1, oldColor, newColor); // Check up
        }

        public bool Fill(int x, int y, Color color)
        {
            if (x < 0 || x >= xlength || y < 0 || y >= ylength)
                return false;
            else
            {
                FillHelper(x, y, screen[y, x], color);
                PaintScreen();
                return true;
            }
        }

        public static void RunPaintFill()
        {
            PaintFill screen = new PaintFill(8, 8);

            bool again = true;
            while (again)
            {
                Console.WriteLine("Where do you want to Fill?");
                Console.Write("X: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Y: ");
                int y = int.Parse(Console.ReadLine());
                Console.WriteLine("What Color? (1: Red 2: Blue 3: Green 4: Black 5: White 6: Yellow 7: Purple");
                int colNum = int.Parse(Console.ReadLine());
                Color color = Color.Red;
                switch (colNum)
                {
                    case 1:
                        color = Color.Red;
                        break;
                    case 2:
                        color = Color.Blue;
                        break;
                    case 3:
                        color = Color.Green;
                        break;
                    case 4:
                        color = Color.Black;
                        break;
                    case 5:
                        color = Color.White;
                        break;
                    case 6:
                        color = Color.Yellow;
                        break;
                    case 7:
                        color = Color.Purple;
                        break;
                }
                if (!screen.Fill(x, y, color))
                    Console.WriteLine("Invalid Input");
            }
        }
    }
}
