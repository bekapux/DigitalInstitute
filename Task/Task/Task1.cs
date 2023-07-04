using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class Task1
    {
        public static List<int> GenerateList(Random random, int count)
        {
            List<int> myList = new List<int>(count);
            for (int i = 0; i < count; i++)
            {
                myList.Add(random.Next());
            }
            return myList;
        }


        public static int SortAndFirst(List<int> list)
        {
            list.Sort();
            return list.Last();
        }

        public static int PrebuildMax(List<int> list)
        {
            return list.Max();
        }

        public static int CustomSort(List<int> list)
        {
            int maxValue = list[0];
            foreach (int l in list)
            {
                if (l > maxValue)
                    maxValue = l;
            }
            return maxValue;
        }
    }
}
