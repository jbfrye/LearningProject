using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_2
{
    // 2.5
    class LinkedListAddition
    {
        public LinkedListAddition()
        { }

        public static void RunLinkedListAddition()
        {
            List<int> aNum = new List<int>();
            aNum.Add(6);
            aNum.Add(1);
            aNum.Add(7);
            List<int> bNum = new List<int>();
            bNum.Add(2);
            bNum.Add(9);
            bNum.Add(5);

            List<int> rNum = AddLists(aNum, bNum);
            aNum.PrintList();
            Console.WriteLine("+");
            bNum.PrintList();
            Console.WriteLine("=");
            rNum.PrintList();

            Console.WriteLine();

            List<int> cNum = new List<int>();
            cNum.Add(7);
            cNum.Add(1);
            cNum.Add(6);
            List<int> dNum = new List<int>();
            dNum.Add(5);
            dNum.Add(9);
            dNum.Add(2);

            List<int> r2Num = AddListsReverse(cNum, dNum);
            cNum.PrintList();
            Console.WriteLine("+");
            dNum.PrintList();
            Console.WriteLine("=");
            r2Num.PrintList();

        }

        public static List<int> AddLists(List<int> a, List<int> b)
        {
            Node<int> aHead = a.GetHead(), bHead = b.GetHead();
            string aStr = "", bStr = "", rStr = "";
            int aNum = 0, bNum = 0, rNum = 0;
            List<int> result = new List<int>();

            while (aHead != null)
            {
                aStr += aHead.data;
                aHead = aHead.next;
            }
            while (bHead != null)
            {
                bStr += bHead.data;
                bHead = bHead.next;
            }

            aNum = Convert.ToInt32(aStr);
            bNum = Convert.ToInt32(bStr);
            rNum = aNum + bNum;
            rStr = Convert.ToString(rNum);

            for (int i = 0; i < rStr.Length; i++)
            {
                result.Add((int)Char.GetNumericValue(rStr[i]));
            }

            return result;
        }

        public static List<int> AddListsReverse(List<int> a, List<int> b)
        {
            Node<int> aHead = a.GetHead(), bHead = b.GetHead();
            string aStr = "", bStr = "", rStr = "";
            int aNum = 0, bNum = 0, rNum = 0;
            List<int> result = new List<int>();

            while (aHead != null)
            {
                aStr += aHead.data;
                aHead = aHead.next;
            }
            Char[] aArr = aStr.ToCharArray();
            Array.Reverse(aArr);
            aStr = new string(aArr);
            while (bHead != null)
            {
                bStr += bHead.data;
                bHead = bHead.next;
            }
            Char[] bArr = bStr.ToCharArray();
            Array.Reverse(bArr);
            bStr = new string(bArr);

            aNum = Convert.ToInt32(aStr);
            bNum = Convert.ToInt32(bStr);
            rNum = aNum + bNum;
            rStr = Convert.ToString(rNum);
            char[] rArr = rStr.ToCharArray();
            Array.Reverse(rArr);
            rStr = new string(rArr);

            for (int i = 0; i < rStr.Length; i++)
            {
                result.Add((int)Char.GetNumericValue(rStr[i]));
            }

            return result;
        }
    }
}
