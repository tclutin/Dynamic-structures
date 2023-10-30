using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_structures.Structures
{
    public class MyQueue : IStructureV2
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


        public void Draw(List<Operation> operations)
        {
            MyQueue queue = new MyQueue();

            foreach (var item in operations)
            {
                switch (item.Number)
                {
                    case 1:
                        queue.Enqueue(item.Data);
                        Console.WriteLine($"Enqueued: {item.Data}");
                        break;
                    case 2:
                        if (!queue.IsEmpty())
                        {
                            queue.Dequeue();
                            Console.WriteLine("Dequeued.");
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty. Cannot dequeue.");
                        }
                        break;
                    case 3:
                        var firstItem = queue.GetFirst();
                        if (firstItem != null)
                        {
                            Console.WriteLine($"First item: {firstItem}");
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty.");
                        }
                        break;
                    case 4:
                        Console.WriteLine($"Is Empty: {queue.IsEmpty()}");
                        break;
                    case 5:
                        queue.Print();
                        break;
                    default:
                        break;
                }
            }
            queue.Print();
        }
    }
}
