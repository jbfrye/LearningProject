using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject
{
    public class Map
    {
        const int DEFAULT_SIZE = 16;
        int size;
        Entry[] entries = new Entry[DEFAULT_SIZE];

        public Map()
        {
            size = 0;
        }

        public int Get(string k)
        {
            for (int i = 0; i < size; i++)
                if (entries[i].GetKey() == k)
                    return entries[i].GetValue();
            return -1;
        }

        public void Put(string k, int v)
        {
            bool insert = true;
            for (int i = 0; i < size; i++)
            {
                if (entries[i].GetKey() == k)
                {
                    entries[i].SetValue(v);
                    insert = false;
                    break;
                }
            }
            if (insert)
            {
                if (size == entries.Length)
                {
                    int newSize = entries.Length * 2;
                    Entry[] temp = entries;
                    entries = new Entry[newSize];
                    temp.CopyTo(entries, 0);
                }
                entries[size] = new Entry(k, v);
                size++;
            }
        }

        public bool Remove(string k)
        {
            for (int i = 0; i < size; i++)
            {
                if (entries[i].GetKey() == k)
                {
                    entries[i] = null;
                    size--;
                    for (int j = i; j < size; j++)
                    {
                        entries[j] = entries[j + 1];
                    }
                    return true;
                }
            }
            return false;
        }

        public int GetSize()
        {
            return size;
        }
    }

    public class Entry
    {
        readonly string key;
        int value;

        public Entry()
        {
            key = "";
            value = 0;
        }

        public Entry(string k, int v)
        {
            key = k;
            value = v;
        }

        public string GetKey()
        {
            return key;
        }

        public int GetValue()
        {
            return value;
        }

        public void SetValue(int v)
        {
            value = v;
        }
    }
}
