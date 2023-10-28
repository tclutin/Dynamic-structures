using Dynamic_structures.Structures;
using System.Collections;
using System.Collections.Generic;

namespace Dynamic_structures
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyQueue hello = new MyQueue();


            hello.Enqueue("wqewqweq");
            hello.Enqueue("цйу");
            hello.Enqueue(1);
            hello.Enqueue(1);
            hello.Enqueue(121231231);
            hello.Dequeue();
            hello.Dequeue();


            Console.WriteLine(hello.GetFirst());
            hello.Print();


        }
    }
}