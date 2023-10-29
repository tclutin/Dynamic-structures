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
            StringBuilder view = StructureDisplayer.CreateView(this);
            Console.WriteLine(view);
        }
        
        public StringBuilder CreateStackView()
        {
            StringBuilder builder= new StringBuilder();
            int columnWidth = StructureDisplayer.FindColumnWidth(this);
            int countLines = 0;
            builder.AppendLine("┌" + new string('─', columnWidth + 2) + "┐");
            foreach (object item in List)
            {
                countLines++;
                builder.AppendLine("│ " + item.ToString().PadLeft(columnWidth) + " │");
                if(countLines == List.Size()) { break;}
                builder.AppendLine("├" + new string('─', columnWidth + 2) + "┤");
            }
            builder.AppendLine("└" + new string('─', columnWidth + 2) + "┘");
            return builder;
        }

        public int FindColumnWidth()
        {
            int width = 0;
            foreach(object item in List)
            {
                if (item.ToString().Length > width)
                {
                    width = item.ToString().Length; 
                }
            }
            return width;
        }
    }
}
