using System;

namespace restsharptest
{
    public static class Helpers
    {
        public static int GetIntInput(int maxValue = int.MaxValue,
            int minValue = int.MinValue, string message = null)
        {
            while (true)
            {
                Console.WriteLine(message != null ? message : "Only enter a whole number");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input >= minValue && input <= maxValue)
                    {
                        return input;
                    }
                }
            }
        }
    }
}
