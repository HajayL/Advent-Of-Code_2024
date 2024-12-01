using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_1
{
    internal class Program
    {
        static Random rnd = new Random();
        

        static void Main(string[] args)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            string path = "";
            int result;

            while (!ReadPath(ref path))
            {
                Display("Not a valid file path!");
            }

            ParseIntoLists(path, list1, list2);

            Sort(list1);
            Sort(list2);
            
            result = GetDistance(list1, list2);
            Display("The resulting distance from your lists are: " + result.ToString());

            Console.ReadKey();
        }

        static bool ReadList()
        {
            bool success = false;

            

            return success;
        }

        static void Display(string output, bool endLine = true)
        {
            int colorCount = 0;

            for (int i = 0; i < output.Length; i++)
            {
                if (colorCount % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                if (!Char.IsWhiteSpace(output[i])) { colorCount++; }

                Console.Write(output[i]);
            }

            if(endLine) Console.WriteLine();
        }

        static bool ReadPath(ref string filePath)
        {
            Display("Please enter file path to lists: ", false);
            Console.ForegroundColor = ConsoleColor.White;
            filePath = Console.ReadLine();

            return File.Exists(filePath);
        }

        static void ParseIntoLists(string filePath, List<int> list1, List<int> list2)
        {
            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] data = line.Split(' ');
                for(int i = 0; i < data.Length; i++)
                {
                    int parsed;

                    if (int.TryParse(data[i], out parsed))
                    {
                        if (i == 0)
                        {
                            list1.Add(parsed);
                        }
                        else
                        {
                            list2.Add(parsed);
                        }
                    }
                }
            }
        }

        static void GetRandom(List<int> list, int length, int max)
        {
            for (int i = 0; i < length; i++)
            {
                list.Add(rnd.Next(max + 1));
            }
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

        static int GetDistance(List<int> list1, List<int> list2)
        {
            int currentDistance = 0;

            for (int i = 0; i < Math.Min(list1.Count, list2.Count); i++)
            {
                currentDistance += Math.Max(list1[i], list2[i]) - Math.Min(list1[i], list2[i]);
            }

            return currentDistance;
        }
    }
}
