using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_9
{
    // 9.6
    class Parentheses
    {
        public Parentheses()
        { }

        public static HashSet<string> GenerateParens(int remaining)
        {
            HashSet<string> set = new HashSet<string>();
            if (remaining == 0)
                set.Add("");
            else
            {
                HashSet<string> prev = GenerateParens(remaining - 1);
                foreach (string str in prev)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] == '(')
                        {
                            string s = InsertInside(str, i);
                            set.Add(s); // Add s to set if it's not already in there
                        }
                    }
                    if (!set.Contains("()" + str))
                        set.Add("()" + str);
                }
            }
            return set;
        }

        public static string InsertInside(string str, int leftIndex)
        {
            string left = str.Substring(0, leftIndex + 1);
            string right = str.Substring(leftIndex + 1, str.Length - 1);
            return left + "()" + right;
        }

        public static void AddParen(ArrayList list, int leftRem, int rightRem, char[] str, int count)
        {
            if (leftRem < 0 || rightRem < leftRem) // Invalid state
                return;
            if (leftRem == 0 && rightRem == 0) // No more parentheses left
            {
                string s = new string(str);
                list.Add(s);
            }
            else
            {
                // Add left paren, if there are any left parens remaining.
                if (leftRem > 0)
                {
                    str[count] = '(';
                    AddParen(list, leftRem - 1, rightRem, str, count + 1);
                }
                // Add right paren, if expression is valid
                if (rightRem > leftRem)
                {
                    str[count] = ')';
                    AddParen(list, leftRem, rightRem - 1, str, count + 1);
                }
            }
        }

        public static ArrayList GenerateParens2(int count)
        {
            char[] str = new char[count * 2];
            ArrayList list = new ArrayList();
            AddParen(list, count, count, str, 0);
            return list;
        }

        public static void RunParentheses()
        {
            int count = 2;
            HashSet<string> paren1 = GenerateParens(count);
            ArrayList paren2 = GenerateParens2(count);

            foreach (string str in paren1)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();
            Console.WriteLine();
            foreach (string str in paren2)
            {
                Console.WriteLine(str.ToString());
            }
        }
    }
}
