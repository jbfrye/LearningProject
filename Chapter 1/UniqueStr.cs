using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_1
{
    // 1.1
    class UniqueStr
    {
        string str;
        bool[] alphabet = new bool[26];
        Sort sort;

        public UniqueStr()
        {
            str = "";
            sort = new Sort();
        }

        public UniqueStr(string s)
        {
            str = s;
            sort = new Sort();
        }

        public static void RunUniqueStr()
        {
            UniqueStr input1 = new UniqueStr("Jeremy");
            UniqueStr input2 = new UniqueStr("Nice");

            // Using an array
            Console.WriteLine("Using a seperate Array to keep track:");
            if (input1.IsUniqueStr())
                Console.WriteLine(input1 + " has all unique characters.");
            else
                Console.WriteLine(input1 + " does not have all unique characters");
            if (input2.IsUniqueStr())
                Console.WriteLine(input2 + " has all unique characters.");
            else
                Console.WriteLine(input2 + " does not have all unique characters");

            Console.WriteLine();

            // Sorting the str
            Console.WriteLine("Sorting the string with Quicksort:");
            if (input1.IsUniqueStrImproved())
                Console.WriteLine(input1 + " has all unique characters.");
            else
                Console.WriteLine(input1 + " does not have all unique characters");
            if (input2.IsUniqueStrImproved())
                Console.WriteLine(input2 + " has all unique characters.");
            else
                Console.WriteLine(input2 + " does not have all unique characters");
        }

        // Use an array to keep track if each character is unique
        public bool IsUniqueStr()
        {
            // Check first thing if it is possible to be unique
            if (str.Length > 26)
                return false;

            string tempStr = str.ToLower();

            for (int i = 0; i < str.Length; i++)
            {
                int letterIndex = tempStr[i] % 'a';
                if (alphabet[letterIndex])
                    return false;
                else
                    alphabet[letterIndex] = true;
            }
            return true;
        }

        // Sort the string and then compare each neighbor to check if it is unique
        public bool IsUniqueStrImproved()
        {
            // Check first thing if it is possible to be unique
            if (str.Length > 26)
                return false;

            char[] tempStr = str.ToLower().ToCharArray();

            sort.QuickSort(tempStr);

            for (int i = 0; i < tempStr.Length-1; i++)
            {
                if (tempStr[i] == tempStr[i + 1])
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            return str;
        }
    }
}