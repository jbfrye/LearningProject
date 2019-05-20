using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_9
{
    // 9.11
    class BooleanExpression
    {
        public BooleanExpression()
        { }

        public static int F(string exp, bool result, int s, int e, Dictionary<string, int> q)
        {
            string key = "" + result + s + e;
            if (q.ContainsKey(key))
                return q[key];

            if (s == e)
            {
                if (exp[s] == '1' && result)
                    return 1;
                else if (exp[s] == '0' && !result)
                    return 1;
                return 0;
            }

            int c = 0;
            if (result)
            {
                for (int i = s + 1; i <= e; i += 2)
                {
                    char op = exp[i];
                    if (op == '&')
                        c += F(exp, true, s, i - 1, q) * F(exp, true, i + 1, e, q);
                    else if (op == '|')
                    {
                        c += F(exp, true, s, i - 1, q) * F(exp, false, i + 1, e, q);
                        c += F(exp, false, s, i - 1, q) * F(exp, true, i + 1, e, q);
                        c += F(exp, true, s, i - 1, q) * F(exp, true, i + 1, e, q);
                    }
                    else if (op == '^')
                    {
                        c += F(exp, true, s, i - 1, q) * F(exp, false, i + 1, e, q);
                        c += F(exp, false, s, i - 1, q) * F(exp, true, i + 1, e, q);
                    }
                }
            }
            else
            {
                for (int i = s + 1; i <= e; i += 2)
                {
                    char op = exp[i];
                    if (op == '&')
                    {
                        c += F(exp, false, s, i - 1, q) * F(exp, true, i + 1, e, q);
                        c += F(exp, true, s, i - 1, q) * F(exp, false, i + 1, e, q);
                        c += F(exp, false, s, i - 1, q) * F(exp, false, i + 1, e, q);
                    }
                    else if (op == '|')
                        c += F(exp, false, s, i - 1, q) * F(exp, false, i + 1, e, q);
                    else if (op == '^')
                    {
                        c += F(exp, true, s, i - 1, q) * F(exp, true, i + 1, e, q);
                        c += F(exp, false, s, i - 1, q) * F(exp, false, i + 1, e, q);
                    }
                }
            }

            q.Add(key, c);
            return c;
        }

        public static void RunBooleanExpression()
        {

        }
    }
}
