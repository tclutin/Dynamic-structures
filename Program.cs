using Dynamic_structures.Structures;
using System.Collections;
using System.Collections.Generic;

namespace Dynamic_structures
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyStack stack = new MyStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push("cotik");
            stack.Push("hhhhhhhhh");
            stack.Push(99);
            stack.Print();
        }
    }
}