using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_structures.Structures
{
    public class MyStack : IStructureV1
    {
        public DoublyLinkedList<object> List { get; }
        private Node<object> top = null;
        public int Size()
        {
            return List.Size();
        }
        public MyStack() 
        {
            List = new DoublyLinkedList<object>();
        }

        public object? Top()
        {
            if (IsEmpty())
            {
                return null;
            }
            return top.Data;
        }
        public void Push(object item)
        {
            List.AddFirst(item);
            top = List.getHead();
        }
        public object? Pop()
        {
            if (IsEmpty())
            {
                return null;
            }
            Node<object> item = top;
            top = top.Next;
            List.Remove(item.Data);
            return item.Data;
        }
        public bool IsEmpty()
        {
            return List.Size() == 0;
        }
        public void Print()
        {
            foreach(object item in List)
            {
                Console.WriteLine(item.ToString()); 
            }
        }
    }
}
