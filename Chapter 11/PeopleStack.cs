using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_11
{
    // 11.7
    class PeopleStack
    {
        public PeopleStack()
        { }

        void LongestIncreasingSubsequence(ArrayList array, ArrayList[] solutions, int current_index)
        {
            if (current_index >= array.Count || current_index < 0)
                return;
            HtWt current_element = (HtWt)array[current_index];

            // Find longest sequence we can append current_element to
            ArrayList best_sequence = null;
            for (int i = 0; i < current_index; i++)
            {
                if (((HtWt)array[i]).IsBefore(current_element))
                    best_sequence = SeqWithMaxLength(best_sequence, solutions[i]);
            }

            // Append current_element
            ArrayList new_solution = new ArrayList();
            if (best_sequence != null)
                new_solution = ((ArrayList)(best_sequence.Clone()));
            new_solution.Add(current_element);

            // Add to list and recurse
            solutions[current_index] = new_solution;
            LongestIncreasingSubsequence(array, solutions, current_index + 1);
        }

        ArrayList GetIncreasingSequence(ArrayList items)
        {
            items.Sort();
            return LongestIncreasingSubsequence(items);
        }

        public ArrayList LongestIncreasingSubsequence(ArrayList array)
        {
            ArrayList[] solutions = new ArrayList[(array.Count)];
            LongestIncreasingSubsequence(array, solutions, 0);

            ArrayList best_sequence = null;
            foreach (ArrayList list in solutions)
                best_sequence = SeqWithMaxLength(best_sequence, list);

            return best_sequence;
        }

        ArrayList SeqWithMaxLength(ArrayList seq1, ArrayList seq2)
        {
            if (seq1 == null)
                return seq2;
            if (seq2 == null)
                return seq1;
            return seq1.Count > seq2.Count ? seq1 : seq2;
        }

        public static void RunPeopleStack()
        {
            PeopleStack stack = new PeopleStack();
            ArrayList people = new ArrayList();
            people.Add(new HtWt(56, 200));
            people.Add(new HtWt(62, 310));
            people.Add(new HtWt(45, 254));
            people.Add(new HtWt(54, 150));
            people.Add(new HtWt(56, 276));
            people.Add(new HtWt(67, 176));
            people.Add(new HtWt(49, 165));
            people.Add(new HtWt(60, 197));

            ArrayList result = stack.LongestIncreasingSubsequence(people);
            foreach (HtWt person in result)
            {
                Console.WriteLine(person.Ht + ", " + person.Wt);
            }
        }
    }

    public class HtWt : IComparable
    {
        public int Ht { get; set; }
        public int Wt { get; set; }

        public HtWt()
        { }

        public HtWt(int ht, int wt)
        {
            Ht = ht;
            Wt = wt;
        }

        public int CompareTo(object s)
        {
            HtWt second = (HtWt)s;
            if (this.Ht != second.Ht)
                return this.Ht.CompareTo(second.Ht);
            else
                return this.Wt.CompareTo(second.Wt);
        }

        public bool IsBefore(HtWt other)
        {
            if (this.Ht < other.Ht && this.Wt < other.Wt)
                return true;
            else
                return false;
        }
    }
}
