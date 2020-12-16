using System;
using System.Collections.Generic;

namespace Validator
{
    public static class Extensions
    {
        public static void PrintToConsole<T>(this IEnumerable<T> input, string str = "")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\tBEGIN: " + str);
            Console.ResetColor();

            foreach (T item in input) Console.WriteLine(item.ToString());

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine('\t' + str + " END.\t(Press a key)");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
