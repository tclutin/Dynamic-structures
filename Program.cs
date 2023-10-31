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
            doublyLinkedList.AddLast("56");
            doublyLinkedList.AddLast(7);
            doublyLinkedList.AddLast(1);

            doublyLinkedList.SwapElements(1, 7);

            foreach (var item in doublyLinkedList)
            {
                Console.Write(item);
            }
            //GUI gui = new GUI();
            //gui.Start();
        }
    }
}