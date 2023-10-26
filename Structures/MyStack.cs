using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_structures.Structures
{
    public class MyStack
    {
        private DoublyLinkedList<object> stack = new DoublyLinkedList<object>();
        private Node<object> top = null;

        public object Top()
        {
            return top.Data;
        }
        public void Push(object item)
        {
            stack.AddFirst(item);
            top = stack.getHead();
        }
        public object Pop()
        {
            Node<object> item = top;
            top = top.Next;
            stack.Remove(item.Data);
            return item.Data;
        }
        public bool IsEmpty()
        {
            return stack.Size() == 0;
        }
        public void Print()
        {
            Console.WriteLine(CreateStackView());
        }
        
        public StringBuilder CreateStackView()
        {
            StringBuilder builder= new StringBuilder();
            int columnWidth = FindColumnWidth();
            int countLines = 0;
            builder.AppendLine("┌" + new string('─', columnWidth + 2) + "┐");
            foreach (object item in stack)
            {
                countLines++;
                builder.AppendLine("│ " + item.ToString().PadLeft(columnWidth) + " │");
                if(countLines == stack.Size()) { break;}
                builder.AppendLine("├" + new string('─', columnWidth + 2) + "┤");
            }
            builder.AppendLine("└" + new string('─', columnWidth + 2) + "┘");
            return builder;
        }

        public int FindColumnWidth()
        {
            int width = 0;
            foreach(object item in stack)
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
