using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_structures.Structures
{
    public class MyQueue
    {
        public DoublyLinkedList<object> List { get; }

        public MyQueue()
        {
            List = new DoublyLinkedList<object>();
        }

        public void Enqueue(object item)
        {
            List.AddLast(item);
        }

        public void Dequeue()
        {
            if (!IsEmpty())
            {
                object item = List.getHead().Data;
                List.Remove(item);
            }
        }

        public object? GetFirst()
        {
            if (!IsEmpty())
            {
                return List.getHead().Data;
            }
            return null;
        }

        public bool IsEmpty()
        {
            return List.Size() == 0;
        }

        public void Print()
        {
            foreach (var item in List)
            {
                Console.WriteLine($"[ {item} ]");
            }
        }
    }
}
