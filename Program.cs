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
            DoublyLinkedList<object> doublyLinkedList= new DoublyLinkedList<object>();
            doublyLinkedList.AddLast(1);
            doublyLinkedList.AddLast(2);
            doublyLinkedList.AddLast(3);
            doublyLinkedList.AddLast(4);
            doublyLinkedList.AddFirst("cat");

            doublyLinkedList.MoveLastToStart();

            foreach (var item in doublyLinkedList)
            {
                Console.Write(item);
            }
            //GUI gui = new GUI();
            //gui.Start();
        }
    }
}