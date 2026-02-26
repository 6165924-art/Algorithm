using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    internal class Question2
    {
        struct V
        {
            public int val;
            public int time;
        }
        Dictionary<int, V> T = new Dictionary<int, V>();
        int saveSetAll;
        int time;
        public void Set(int key, int value)
        {
            V v = new V();
            v.val = value;
            v.time = time + 1;
            T[key] = v;
        }
        public int Get(int key)
        {
            if (!T.ContainsKey(key))
                return int.MinValue;
            V v = T[key];
            if (v.time <= time)
                return saveSetAll;
            return v.val;
        }
        public void SetAll(int value)
        {
            saveSetAll = value;
            time++;
        }
    }
}
