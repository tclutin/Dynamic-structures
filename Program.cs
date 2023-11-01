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
            DoublyLinkedList<object> q = new DoublyLinkedList<object>();
            q.AddLast(1);
            q.AddLast(1);
            q.AddLast(1);
            q.AddLast(11);
            q.AddLast(17);
            q.AddLast(1213);
            q.AddLast(1213);
            q.AddLast("wqe");
            q.AddLast("wqe");
            q.RemoveNonUniqueElements();

            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
            //GUI gui = new GUI();
            //gui.Start();
        }
    }
}