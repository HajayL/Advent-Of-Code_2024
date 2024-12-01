using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_1
{
    internal class Program
    {

        static Random rnd = new Random();
        

        static void Main(string[] args)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            int result;

            Console.ReadKey();
        }

        static void SwapItem(List<int> list, int indexA, int indexB)
        {
            int B = list[indexB];
            list[indexB] = list[indexA];
            list[indexA] = B;
        }

        static void Sort(List<int> list)
        {
            bool listChanged;

            do
            {
                listChanged = false;

                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        listChanged = true;
                        SwapItem(list, i, i + 1);
                    }
                }

            } while (listChanged);
        }
    }
}
