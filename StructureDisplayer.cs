using Dynamic_structures.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_structures
{
    public class StructureDisplayer
    {
        public List<Operation> commands;
        private MyStack stack;
        private MyQueue queue;
        private DoublyLinkedList<object> list;
        private int cursorPositionX = -8;
        private int cursorPositionY = 0;

        public StructureDisplayer(List<Operation> commands, MyStack structure)
        {
            this.commands = commands;
            this.stack = structure;
        }
        public StructureDisplayer(List<Operation> commands, MyQueue queue)
        {
            this.commands = commands;
            this.queue = queue;
        }
        public StructureDisplayer(MyStack stack)
        {
            this.stack = stack;
            cursorPositionY = 3;
        }

        public void Invoke()
        {
            int iteration = 0;
            while (commands.Count > 0 && iteration < commands.Count)
            {
                DoOperationStack(commands[iteration]);
                iteration++;
            }
        }

        public void InvokeQueue()
        {
            for (int i = 0; i < commands.Count; i++)
            {
                DoOperationQueue(commands[i]);
            }
        }
        private void DoOperationStack(Operation operation)
        {
            switch (operation.Number)
            {
                case 1:
                    stack.Push(operation.Data);
                    PrintStack("Push " + operation.Data);
                    break;
                case 2:
                    object pop = stack.Pop();
                    if (pop == null)
                    {
                        throw new Exception("The stack is empty, cannot Pop");
                    }
                    PrintStack("Pop = " + pop);
                    break;
                case 3:
                    object top = stack.Top();
                    PrintStack("Top = " + top);
                    break;
                case 4:
                    bool isEmpty = stack.IsEmpty();
                    PrintStack("IsEmpty: " + isEmpty);
                    break;
                case 5:
                    PrintStack("Print");
                    break;
            }
        }
        private void DoOperationQueue(Operation operation)
        {
            switch (operation.Number)
            {
                case 1:
                    queue.Enqueue(operation.Data);
                    PrintQueue("Enqueue " + operation.Data);
                    break;
                case 2:
                    queue.Dequeue();
                    PrintQueue("Dequeue");
                    break;
                case 3:
                    object first = queue.GetFirst();
                    PrintQueue("GetFirst : " + first);
                    break;
                case 4:
                    bool isEmpty = queue.IsEmpty();
                    PrintQueue("IsEmpty : " + isEmpty);
                    break;
                case 5:
                    PrintQueue("Print");
                    break;
                default:
                    break;
            }
        }

        private void PrintStack(string operationName)
        {
            string stackView = CreateStackView().ToString();
            Console.WriteLine(operationName);
            Console.WriteLine(stackView);
        }
        private void PrintQueue(string operationName)
        {
            string[] queueView = CreateQueueView().ToString().Split('\n');
            Console.WriteLine(queueView[0]);
            Console.Write(queueView[1].Replace('\r', ' '));
            Console.WriteLine(" <------ " + operationName);
            Console.WriteLine(queueView[2]);
        }

        private void PrintLinkedList()
        {
            StringBuilder top = new StringBuilder();
            StringBuilder mid = new StringBuilder();
            StringBuilder botton = new StringBuilder();
            int width = 0;
            int count = 0;
            foreach (object item in list)
            {
                count++;
                width = item.ToString().Length;
                top.Append("┌" + new string('─', width + 2) + "┐     ");
                mid.Append("│ " + item + " │ ");
                if (count < list.Size()) { mid.Append("<-> "); }
                botton.Append("└" + new string('─', width + 2) + "┘     ");
            }
            Console.WriteLine(top.ToString());
            Console.WriteLine(mid.ToString());
            Console.WriteLine(botton.ToString());
        }

        public StringBuilder CreateStackView()
        {
            StringBuilder builder = new StringBuilder();
            int columnWidth = FindColumnWidth();
            int countLines = 0;
            builder.AppendLine("┌" + new string('─', columnWidth + 2) + "┐");
            foreach (object item in stack.List)
            {
                countLines++;
                builder.AppendLine("│ " + item.ToString().PadLeft(columnWidth) + " │");
                if (countLines == stack.Size()) { break; }
                builder.AppendLine("├" + new string('─', columnWidth + 2) + "┤");
            }
            builder.AppendLine("└" + new string('─', columnWidth + 2) + "┘");
            return builder;
        }

        private StringBuilder CreateQueueView()
        {
            StringBuilder builder = new StringBuilder();
            int width = FindQueueLength();
            if (width < 0) width = 5;

            builder.AppendLine("┌" + new string('─', width) + "┐");
            builder.Append("│ ");
            foreach (object item in queue.List)
            {
                builder.Append(item + " │ ");
            }
            builder.Remove(builder.Length - 1, 1);
            builder.AppendLine();
            builder.Append("└" + new string('─', width) + "┘");
            return builder;
        }

        private int FindColumnWidth()
        {
            int width = 0;
            foreach (object item in stack.List)
            {
                if (item.ToString().Length > width)
                {
                    width = item.ToString().Length;
                }
            }
            return width;
        }
        private int FindQueueLength()
        {
            int length = queue.List.Size() - 1;
            foreach (object item in queue.List)
            {
                length += item.ToString().Length + 2;
            }
            return length;
        }
    }
}
