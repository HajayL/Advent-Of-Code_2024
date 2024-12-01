using System;
using System.Collections.Generic;
using System.IO;

namespace Day_1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Number stores
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            // Total distance result of the two lists
            int distanceResult;

            // Total similarity result of the two lists
            int similarityResult;


            // file path to data
            string path = "";

            // Check if path is a valid file
            while (!ReadPath(ref path))
            {
                Display("Not a valid file path!");
            }

            // Parse data into lists
            ParseIntoLists(path, list1, list2);

            // Sort both lists, so the order of value is the same between the two lists
            Sort(list1);
            Sort(list2);

            // Get & Display total distance of the two lists
            distanceResult = GetDistance(list1, list2);
            Display("The resulting distance from your lists are: " + distanceResult.ToString());

            // Get & Display total similarity of the two lists
            similarityResult = GetSimilarity(list1, list2);
            Display("The resulting similarity from your lists are: " + similarityResult.ToString());

            Console.ReadKey();
        }

        //                                                                               Input/Output

        static void Display(string output, bool endLine = true)
        {
            int colorCount = 0; // Keep track of non-whitespace count

            for (int i = 0; i < output.Length; i++)
            {
                if (colorCount % 2 == 0) // Set alternating colors
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                if (!Char.IsWhiteSpace(output[i])) { colorCount++; } // Only change color if the character is not whitespace

                Console.Write(output[i]); // Display current character
            }

            if(endLine) Console.WriteLine();
        }

        static bool ReadPath(ref string filePath)
        {
            Display("Please enter file path to lists: ", false);    // Prompt for file path
            Console.ForegroundColor = ConsoleColor.White;           // Reset color for user
            filePath = Console.ReadLine();                          // Get path from user

            return File.Exists(filePath) && Path.GetExtension(filePath) == ".txt";  // Return if path is valid or not
        }

        static void ParseIntoLists(string filePath, List<int> list1, List<int> list2)
        {
            foreach (string line in File.ReadAllLines(filePath)) // Read each line in file
            {
                string[] data = line.Split(' ');        // Separate the numbers
                for(int i = 0; i < data.Length; i++)
                {
                    int parsed;

                    if (int.TryParse(data[i], out parsed))  // Parse number from text
                    {
                        if (i == 0)
                        {
                            list1.Add(parsed);  // If it is the first number, add to list one
                        }
                        else
                        {
                            list2.Add(parsed);  // If it is the second number, add to list two
                        }
                    }
                }
            }
        }

        //                                                                              Sorting
        
        // Swap numbers at the two indexes
        static void SwapItem(List<int> list, int indexA, int indexB)
        {
            int B = list[indexB];
            list[indexB] = list[indexA];
            list[indexA] = B;
        }

        // Bubble sort
        static void Sort(List<int> list)
        {
            bool listChanged;   // Sorted check

            do
            {
                listChanged = false;    // Reset sorted check

                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (list[i] > list[i + 1])  // Swap numbers if out of place
                    {
                        listChanged = true; // Set sorted check
                        SwapItem(list, i, i + 1);
                    }
                }

            } while (listChanged);  // Repeat until sorted
        }

        //                                                                               Distance calculation
        static int GetDistance(List<int> list1, List<int> list2)
        {
            int currentDistance = 0;

            for (int i = 0; i < Math.Min(list1.Count, list2.Count); i++)
            {
                currentDistance += Math.Max(list1[i], list2[i]) - Math.Min(list1[i], list2[i]); // Adds the distance of the two numbers to total
            }

            return currentDistance; // Return back total distance to caller
        }

        //                                                                              Similarity Calculation

        static int GetSimilarity(List<int> list1, List<int> list2)
        {
            int currentSimilarity = 0;

            for (int i = 0; i < list1.Count; i++)
            {
                for (int a = 0; a < list2.Count; a++)
                {
                    if (list1[i] == list2[a])
                    {
                        currentSimilarity += list1[i]; // Adds the similairty if the numbers match
                    }
                }
            }

            return currentSimilarity; // Returns back similarity 
        }
    }
}
