using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_structures.Structures
{
    public class MyQueue
    {
        private DoublyLinkedList<object> list { get; }

        public MyQueue()
        { 
            list = new DoublyLinkedList<object>();
        }

        public void Enqueue(object item)
        {
            list.AddLast(item);
        }

        public void Dequeue()
        {
            if (!IsEmpty())
            {
                object item = list.getHead().Data;
                list.Remove(item);
            }
        }

        public object? GetFirst()
        {
            if (!IsEmpty())
            {
                return list.getHead().Data;
            }
            return null;
        }

        public bool IsEmpty()
        {
            return list.Size() == 0;
        }

        public void Print()
        {
            foreach (var item in list)
            {
                Console.WriteLine($"Element: {item}");
            }
        }
    }
}
