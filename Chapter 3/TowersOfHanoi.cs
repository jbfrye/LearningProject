using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_3
{
    // 3.4
    class TowersOfHanoi
    {
        const int NUMBER_OF_TOWERS = 3;
        Stack<int>[] towers = new Stack<int>[NUMBER_OF_TOWERS];
        int numOfDisks;

        public TowersOfHanoi(int n)
        {
            numOfDisks = n;
            for (int i = 0; i < NUMBER_OF_TOWERS; i++)
                towers[i] = new Stack<int>();
            for (int i = numOfDisks; i >= 1; i--)
            {
                towers[0].Push(i);
            }
        }

        public void CompleteTowers()
        {
            Move(numOfDisks, 0, 2, 1);
        }

        void Move(int n, int current, int destination, int buffer)
        {
            // Check if the Moves are complete
            if (n > 0)
            {
                Move(n - 1, current, buffer, destination);
                towers[destination].Push(towers[current].Pop());
                Move(n - 1, buffer, destination, current);
            }
        }

        public void PrintTowers()
        {
            Console.Write("Tower 1: ");
            for (int i = 0; i < towers[0].Count; i++)
            {
                Console.Write(towers[0].ElementAt(i));
                if (i < towers[0].Count - 1)
                    Console.Write(", ");
            }
            Console.WriteLine();
            Console.Write("Tower 2: ");
            for (int i = 0; i < towers[1].Count; i++)
            {
                Console.Write(towers[1].ElementAt(i));
                if (i < towers[1].Count - 1)
                    Console.Write(", ");
            }
            Console.WriteLine();
            Console.Write("Tower 3: ");
            for (int i = 0; i < towers[2].Count; i++)
            {
                Console.Write(towers[2].ElementAt(i));
                if (i < towers[2].Count - 1)
                    Console.Write(", ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void RunTowerOfHanoi()
        {
            Console.WriteLine("Hanoi with 1 Disk");
            TowersOfHanoi hanoi1 = new TowersOfHanoi(1);
            hanoi1.PrintTowers();
            hanoi1.CompleteTowers();
            hanoi1.PrintTowers();

            Console.WriteLine("Hanoi with 2 Disks");
            TowersOfHanoi hanoi2 = new TowersOfHanoi(2);
            hanoi2.PrintTowers();
            hanoi2.CompleteTowers();
            hanoi2.PrintTowers();

            Console.WriteLine("Hanoi with 3 Disks");
            TowersOfHanoi hanoi3 = new TowersOfHanoi(3);
            hanoi3.PrintTowers();
            hanoi3.CompleteTowers();
            hanoi3.PrintTowers();

            Console.WriteLine("hanoi with 4 Disks");
            TowersOfHanoi hanoi4 = new TowersOfHanoi(4);
            hanoi4.PrintTowers();
            hanoi4.CompleteTowers();
            hanoi4.PrintTowers();
        }
    }
}
