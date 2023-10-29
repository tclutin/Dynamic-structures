using Dynamic_structures.Structures;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace Dynamic_structures
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var x = Parser.Parse("input.txt");

            //MyQueue queue = new MyQueue();
            //queue.Draw(x);
            //StructureDisplayer displayer = new StructureDisplayer(x, new MyStack());
            //displayer.Invoke();
            var list = Parser.ParseExpression("postfix.txt");
            PostfixCalculator calculator = new PostfixCalculator();
            Console.WriteLine();
            calculator.Calculate(list, true);
        }
    }
}