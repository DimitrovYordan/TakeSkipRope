using System;
using System.Collections.Generic;
using System.Linq;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Receiving string
            string rope = Console.ReadLine();
            List<int> numbers = new List<int>();
            List<string> letters = new List<string>();
            // 2. Take digits in array and delete them from input
            for (int i = 0; i < rope.Length; i++)
            {
                string currLetter = rope[i].ToString();
                int temp;
                if (int.TryParse(currLetter, out temp))
                {
                    numbers.Add(int.Parse(currLetter));
                }
                else
                {
                    letters.Add(currLetter);
                }

            }
            // 3. From digit array by index separate odd and even 
            List<int> takeChar = new List<int>();
            List<int> skipChar = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 1)
                {
                    skipChar.Add(numbers[i]);
                }
                else
                {
                    takeChar.Add(numbers[i]);
                }

            }
            // 4. Odd digits show how many chars to take input, even show how many to skip
            List<string> hiddenMessage = new List<string>();
            for (int i = 0; i < takeChar.Count; i++)
            {
                if (takeChar[i] > 0)
                {
                    if (takeChar[i] > letters.Count)
                    {
                        letters.Add(" ");
                    }
                    for (int j = 0; j < takeChar[i]; j++)
                    {
                        hiddenMessage.Add(letters[0]);
                        letters.Remove(letters[0]);
                    }
                    for (int d = 0; d < skipChar[i]; d++)
                    {
                        if (takeChar[i] > letters.Count)
                        {
                            letters.Add(" ");
                        }
                        letters.Remove(letters[0]);
                    }

                }
                else
                {
                    for (int k = 0; k < skipChar[i]; k++)
                    {
                        letters.Remove(letters[i]);
                    }

                }

            }
            // 5. Print result
            Console.WriteLine(string.Join("", hiddenMessage));
        }
    }
}
