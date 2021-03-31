using System;
using System.Collections.Generic;

namespace restsharptest
{
    public static class Helpers
    {
        public static int GetIntInput(int maxValue = int.MaxValue,
            int minValue = int.MinValue, string message = null)
        {
            while (true)
            {
                Console.Write(message != null ? message : "Only enter a whole number:");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input >= minValue && input <= maxValue)
                    {
                        return input;
                    }
                }
            }
        }

        public static void PrintItems<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
