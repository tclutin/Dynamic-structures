using Dynamic_structures.Structures;
using System.Collections;
using System.Collections.Generic;

namespace Dynamic_structures
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var x = Parser.Parse("input.txt");

            foreach (var item in x)
            {
                Console.WriteLine($"{item.Number} {item.Data}");
            }
        }
    }
}